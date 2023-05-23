using CursoSBP.Common.Models.ViewModels;

namespace CursoSBP.Common.Services
{
    public interface IApiService
    {
        #region Unsecure calls
        Task<Response<object>> GetListAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller);

        Task<Response<object>> GetSingleAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            int id);

        Task<Response<object>> PostAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            T model);

        Task<Response<object>> PutAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            int id,
            T model);

        Task<Response<object>> DeleteAsync<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            int id);

        #endregion
    }
}