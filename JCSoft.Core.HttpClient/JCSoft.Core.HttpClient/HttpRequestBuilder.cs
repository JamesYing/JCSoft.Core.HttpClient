using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JCSoft.Core.Http
{
    public class HttpRequestBuilder : IHttpRequestBuilder
    {
        private HttpMethod method = null;
        private string requestUri = "";
        private HttpContent content = null;
        private string bearerToken = "";
        private string acceptHeader = "application/json";
        private TimeSpan timeout = new TimeSpan(0, 0, 15);
        private Dictionary<string, string> _header = new Dictionary<string, string>();

        private static HttpClient _client = new HttpClient();
        static HttpRequestBuilder()
        {
            //_client.Timeout = timeout;
        }

        public HttpRequestBuilder()
        {
            _client.Timeout = timeout;
        }

        public IHttpRequestBuilder AddMethod(HttpMethod method)
        {
            this.method = method;
            return this;
        }

        public IHttpRequestBuilder AddUri(string requestUri)
        {
            this.requestUri = requestUri;
            return this;
        }

        public IHttpRequestBuilder AddContent(HttpContent content)
        {
            this.content = content;
            return this;
        }

        public IHttpRequestBuilder AddBearerToken(string bearerToken)
        {
            this.bearerToken = bearerToken;
            return this;
        }

        public IHttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            this.acceptHeader = acceptHeader;
            return this;
        }

        public IHttpRequestBuilder AddTimeout(TimeSpan timeout)
        {
            this.timeout = timeout;
            return this;
        }

        public IHttpRequestBuilder AddHeader(Dictionary<string, string> header)
        {
            _header = header;

            return this;
        }

        public async Task<HttpResponseMessage> SendAsync()
        {
            // Setup request
            var request = new HttpRequestMessage
            {
                Method = this.method,
                RequestUri = new Uri(this.requestUri)
            };

            if (this.content != null)
                request.Content = this.content;

            if (!string.IsNullOrEmpty(this.bearerToken))
                request.Headers.Authorization =
                  new AuthenticationHeaderValue("Bearer", this.bearerToken);

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this.acceptHeader))
                request.Headers.Accept.Add(
                   new MediaTypeWithQualityHeaderValue(this.acceptHeader));

            if (_header != null && _header.Any())
            {
                foreach (var key in _header.Keys)
                {
                    request.Headers.Add(key, _header[key]);
                }
            }

            _client.Timeout = this.timeout;

            return await _client.SendAsync(request);
        }
        
    }
}
