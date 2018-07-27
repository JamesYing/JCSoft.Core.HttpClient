using JCSoft.Core.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JCSoft.Core.HttpClient.Extensions;

namespace JCSoft.Core.HttpClient
{
    public static class HttpRequestHelper
    {
        public static async Task<HttpResponseMessage> Get(string requestUri,
            object requestParams = null,
            Dictionary<string, string> header = null)
        {
            if (requestParams != null)
            {
                requestUri = requestUri.JoinUrl(requestParams);
            }

            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Get)
                                .AddHeader(header)
                                .AddUri(requestUri);

            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Post(
           string requestUri, object value, Dictionary<string, string> header = null, Encoding encoding = null)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddUri(requestUri)
                                .AddContent(new JsonContent(value, encoding))
                                .AddHeader(header);


            return await builder.SendAsync();
        }

        public static async Task<HttpResponseMessage> Put(
           string requestUri, object value, Dictionary<string, string> header = null, Encoding encoding = null)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Put)
                                .AddUri(requestUri)
                                .AddContent(new JsonContent(value, null))
                                .AddHeader(header);

            return await builder.SendAsync();
        }


        public static async Task<HttpResponseMessage> Delete(string requestUri, object requestParams = null, Dictionary<string, string> header = null)
        {
            if (requestParams != null)
            {
                requestUri = requestUri.JoinUrl(requestParams);
            }
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Delete)
                                .AddHeader(header)
                                .AddUri(requestUri);

            return await builder.SendAsync();
        }
    }
}
