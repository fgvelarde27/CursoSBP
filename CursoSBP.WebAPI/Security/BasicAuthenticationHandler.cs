using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace CursoSBP.Api.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// Handle Basic Authentication Async
        /// </summary>
        /// <returns></returns>
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No header authorization found.");
            try
            {
                var headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var hBytes = Convert.FromBase64String(headerValue.Parameter!);
                var credentials = Encoding.UTF8.GetString(hBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];

                // Built a ticket for Success result.
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,username),
                    new Claim(ClaimTypes.Hash,password)
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                return await Task.Run(() => AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name)));
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
        }

    }
}