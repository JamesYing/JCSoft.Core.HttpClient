using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JCSoft.Core.HttpClient
{
    public class HttpHelper : IHttpHelper
    {
        public async Task<string> GetAsync(string url, object requestParams = null, Dictionary<string, string> headers = null)
        {
            var response = await HttpRequestHelper.Get(url, requestParams, headers);

            return await ContentToString(response);
        }

        public async Task<T> GetAsync<T>(string url, object requestParams = null, Dictionary<string, string> headers = null)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(url, requestParams, headers));
        }

        public async Task<string> PostAsync(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null)
        {
            var response = await HttpRequestHelper.Post(url, data, headers, coding);

            return await ContentToString(response);
        }

        public async Task<T> PostAsync<T>(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null)
        {
            return JsonConvert.DeserializeObject<T>(await PostAsync(url, data, headers, coding));
        }

        public async Task<string> PutAsync(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null)
        {
            var response = await HttpRequestHelper.Put(url, data, headers, coding);

            return await ContentToString(response);
        }

        public async Task<T> PutAsync<T>(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null)
        {
            return JsonConvert.DeserializeObject<T>(await PutAsync(url, data, headers, coding));
        }

        public async Task<string> DeleteAsync(string url, object requestParams = null, Dictionary<string, string> headers = null)
        {
            var response = await HttpRequestHelper.Delete(url, requestParams, headers);

            return await ContentToString(response);
        }

        public async Task<T> DeleteAsync<T>(string url, object requestParams = null,
            Dictionary<string, string> headers = null)
        {
            return JsonConvert.DeserializeObject<T>(await DeleteAsync(url, requestParams, headers));
        }

        private async Task<String> ContentToString(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw  new HttpRequestException("request has program!");
            }

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw  new Exception($"connected remote server has a error, status code is {response.StatusCode}");
        }
    }
}