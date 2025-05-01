using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tech.Common.ViewModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace tech.Common.Helper
{
    public interface IApiHelper
    {
        //public ApiResponseModel PostAsync(string endpoint, string body, string jwtToken = null);

        public ApiResponseModel Get(string endpoint, string jwtToken = null);

        //public Task<ApiResponseModel> PostFormDataAsync(MultipartFormDataContent input, string endpoint, string jwtToken = null);

        //public ApiResponseModel DeleteAsync(string endpoint, string jwtToken = null);

        //public ApiResponseModel PostjsonAsync(string endpoint, string body, string jwtToken = null);
    }

    public class ApiHelper : IApiHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public ApiHelper(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;            
            _configuration = configuration;
        }

        //public ApiResponseModel PostAsync(string endpoint, string body, string jwtToken = null)
        //{
        //    if (body == null)
        //        body = string.Empty;

        //    try
        //    {
        //        string baseAddress = _configuration.GetSection("BaseUrl").Value;
        //        if (_httpClient.BaseAddress == null)
        //        {
        //            _httpClient.BaseAddress = new Uri(baseAddress);
        //        }
        //        if (jwtToken != null)
        //            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        //        var contentData = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = _httpClient.PostAsync(endpoint, contentData).Result;
        //        string output = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<ApiResponseModel>(output);
        //    }
        //    catch (Exception ex)
        //    {
        //        ApiResponseModel apiResponse = new ApiResponseModel
        //        {
        //            Message = ex.Message,
        //            Code = (int)HttpStatusCode.InternalServerError
        //        };
        //        return apiResponse;
        //    }
        //}
        //public ApiResponseModel PostjsonAsync(string endpoint, string body, string jwtToken = null)
        //{
        //    if (body == null)
        //        body = string.Empty;

        //    try
        //    {
        //        string baseAddress = _configuration.GetSection("BaseUrl").Value;
        //        if (_httpClient.BaseAddress == null)
        //        {
        //            _httpClient.BaseAddress = new Uri(baseAddress);
        //        }
        //        if (jwtToken != null)
        //            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        //        var contentData = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = _httpClient.PostAsJsonAsync(endpoint, contentData).Result;
        //        string output = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<ApiResponseModel>(output);
        //    }
        //    catch (Exception ex)
        //    {
        //        ApiResponseModel apiResponse = new ApiResponseModel
        //        {
        //            Message = ex.Message,
        //            Code = (int)HttpStatusCode.InternalServerError
        //        };
        //        _logger.LogError($"ApiHelper - {ex.Message}");
        //        return apiResponse;
        //    }
        //}

        //public async Task<ApiResponseModel> PostFormDataAsync(MultipartFormDataContent input, string endpoint, string jwtToken = null)
        //{
        //    ApiResponseModel model;

        //    try
        //    {
        //        var url = $"{_configuration.GetSection("WebApiBaseUrl").Value}/{endpoint}";

        //        using var httpClientHandler = new HttpClientHandler
        //        {
        //            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        //        };

        //        using var client = new HttpClient(httpClientHandler)
        //        {
        //            Timeout = TimeSpan.FromMinutes(30)
        //        };

        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

        //        var response = await client.PostAsync(url, input);
        //        var responseContent = await response.Content.ReadAsStringAsync();

        //        model = JsonConvert.DeserializeObject<ApiResponseModel>(responseContent);
        //        model.Code = (int)response.StatusCode;

        //        return model;
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        public ApiResponseModel Get(string endpoint, string jwtToken = null)
        {
            try
            {
                string baseAddress = _configuration.GetSection("BaseUrl").Value;
                _httpClient.Timeout = TimeSpan.FromMinutes(30);
                _httpClient.BaseAddress = new Uri(baseAddress);

                HttpResponseMessage response = _httpClient.GetAsync(endpoint).Result;
                string output = response.Content.ReadAsStringAsync().Result;
                ApiResponseModel apiResponse = new ApiResponseModel();


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    apiResponse = new ApiResponseModel
                    {
                        Message = "Success",
                        Code = (int)HttpStatusCode.OK,
                        Data = output
                    };
                }
                else {
                    apiResponse = new ApiResponseModel
                    {
                        Message = "Error",
                        Code = (int)HttpStatusCode.BadRequest,
                        Data = output
                    };
                }
                
                return apiResponse;
            }
            catch (Exception ex)
            {
                ApiResponseModel apiResponse = new ApiResponseModel
                {
                    Message = ex.Message,
                    Code = (int)HttpStatusCode.InternalServerError
                };
                return apiResponse;
            }
        }

        //public ApiResponseModel DeleteAsync(string endpoint, string jwtToken = null)
        //{
        //    try
        //    {
        //        string baseAddress = _configuration.GetSection("BaseUrl").Value;
        //        _httpClient.BaseAddress = new Uri(baseAddress);
        //        if (jwtToken != null)
        //            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        //        HttpResponseMessage response = _httpClient.DeleteAsync(endpoint).Result;
        //        string output = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<ApiResponseModel>(output);
        //    }
        //    catch (Exception ex)
        //    {
        //        ApiResponseModel apiResponse = new ApiResponseModel
        //        {
        //            Message = ex.Message,
        //            Code = (int)HttpStatusCode.InternalServerError
        //        };
        //        return apiResponse;
        //    }
        //}
    }
}
