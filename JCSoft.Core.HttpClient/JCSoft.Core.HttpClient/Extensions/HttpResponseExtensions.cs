using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.HttpClient.Extensions
{
    public static class HttpResponseExtensions
    {
        public static async Task<T> ContentToType<T>(this Task<HttpResponseMessage> msg)
        {
            var response = await msg;
            var data = await response.Content.ReadAsStringAsync();
            return !String.IsNullOrEmpty(data) ?
                JsonConvert.DeserializeObject<T>(data) :
                default(T);
        }

        public static async Task<string> ContentToString(this Task<HttpResponseMessage> message)
        {
            var response = await message;

            return await response.Content.ReadAsStringAsync();
        }

        public static string ObjectToQueryString(this object obj)
        {
            var result = new StringBuilder();
            if (obj != null)
            {
                var jsonString = JsonConvert.SerializeObject(obj);
                var dictObjct = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
                foreach (var key in dictObjct.Keys)
                {
                    result.Append($"{key}={dictObjct[key]}&");
                }
            }

            return result.ToString();
        }

        public static string JoinUrl(this string url, object obj)
        {
            //var isLastFlag = url.EndsWith("/");
            var queryString = obj.ObjectToQueryString();

            return $"{url}?{queryString}";
        }
    }
}
