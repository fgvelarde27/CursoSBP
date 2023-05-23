using CursoSBP.Common.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace CursoSBP.Common.Services
{
    public class ApiService : IApiService
    {
        private readonly JsonSerializerSettings options = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        /// <summary>
        /// Get List Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlBase"></param>
        /// <param name="servicePrefix"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        public async Task<Response<object>> GetListAsync<T>(string urlBase, string servicePrefix, string controller)
        {
            HttpClient client = new() { BaseAddress = new Uri(urlBase) };
            try
            {
                client.BaseAddress = new Uri(urlBase);
                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result, options);
                if (list != null)
                {
                    return new Response<object>
                    {
                        IsSuccess = true,
                        Result = list
                    };
                }
                else
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Error deseralizing object <{T}>"
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
            finally { client.Dispose(); }
        }

        /// <summary>
        /// Get single object by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlBase"></param>
        /// <param name="servicePrefix"></param>
        /// <param name="controller"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response<object>> GetSingleAsync<T>(string urlBase, string servicePrefix, string controller, int id)
        {
            HttpClient client = new() { BaseAddress = new Uri(urlBase) };
            try
            {
                client.BaseAddress = new Uri(urlBase);
                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var single = JsonConvert.DeserializeObject<T>(result, options);
                if (single != null)
                {
                    return new Response<object>
                    {
                        IsSuccess = true,
                        Result = single
                    };
                }
                else
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Error deseralizing object <{T}>"
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
            finally { client.Dispose(); }
        }

        /// <summary>
        /// Create new object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlBase"></param>
        /// <param name="servicePrefix"></param>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        /// <returns>Response with object inserted.</returns>
        public async Task<Response<object>> PostAsync<T>(string urlBase, string servicePrefix, string controller, T model)
        {
            HttpClient client = new() { BaseAddress = new Uri(urlBase) };
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(urlBase);
                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }
                var obj = JsonConvert.DeserializeObject<T>(answer);
                if (obj != null)
                {
                    return new Response<object>
                    {
                        IsSuccess = true,
                        Result = obj,
                    };
                }
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = "No results in POST operation"
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            finally { client.Dispose(); }
        }

        /// <summary>
        /// Update an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlBase"></param>
        /// <param name="servicePrefix"></param>
        /// <param name="controller"></param>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Object updated.</returns>
        public async Task<Response<object>> PutAsync<T>(string urlBase, string servicePrefix, string controller, int id, T model)
        {
            HttpClient client = new() { BaseAddress = new Uri(urlBase) };
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri(urlBase);

                var url = $"{servicePrefix}{controller}/{id}";

                var response = await client.PutAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                var obj = JsonConvert.DeserializeObject<T>(answer);
                if (obj != null)
                {
                    return new Response<object>
                    {
                        IsSuccess = true,
                        Result = obj,
                    };
                }
                else
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = "No results in PUT operation"
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            finally { client.Dispose(); }
        }

        /// <summary>
        /// Delete an object by Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlBase"></param>
        /// <param name="servicePrefix"></param>
        /// <param name="controller"></param>
        /// <param name="id"></param>
        /// <returns>Response with True if success delete</returns>
        public async Task<Response<object>> DeleteAsync<T>(string urlBase, string servicePrefix, string controller, int id)
        {
            HttpClient client = new() { BaseAddress = new Uri(urlBase) };
            try
            {
                client.BaseAddress = new Uri(urlBase);
                var url = $"{servicePrefix}{controller}/{id}";
                var response = await client.DeleteAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response<object>
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                return new Response<object>
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new Response<object>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
            finally { client.Dispose(); }
        }
    }
}
