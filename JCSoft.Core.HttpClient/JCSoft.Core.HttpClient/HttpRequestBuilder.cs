using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.Http
{
    public class HttpRequestBuilder : IHttpRequestBuilder
    {
        private HttpMethod _method = null;
        private string _requestUri = "";
        private HttpContent _content = null;
        private string _bearerToken = "";
        private string _acceptHeader = "application/json";
        private  TimeSpan _timeout = new TimeSpan(0, 0, 15);
        private  Encoding _encoding = Encoding.UTF8;
        private Dictionary<string, string> _header = new Dictionary<string, string>();

        private static System.Net.Http.HttpClient _client = new System.Net.Http.HttpClient();
        static HttpRequestBuilder()
        {
            //_client.Timeout = _timeout;
        }

        public HttpRequestBuilder()
        {
            //_client.Timeout = _timeout;
        }

        public IHttpRequestBuilder AddMethod(HttpMethod method)
        {
            this._method = method;
            return this;
        }

        public IHttpRequestBuilder AddUri(string requestUri)
        {
            this._requestUri = requestUri;
            return this;
        }

        public IHttpRequestBuilder AddContent(HttpContent content)
        {
            this._content = content;
            return this;
        }

        public IHttpRequestBuilder AddBearerToken(string bearerToken)
        {
            this._bearerToken = bearerToken;
            return this;
        }

        public IHttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            this._acceptHeader = acceptHeader;
            return this;
        }

        public IHttpRequestBuilder AddTimeout(TimeSpan timeout)
        {
            this._timeout = timeout;
            return this;
        }

        public IHttpRequestBuilder AddHeader(Dictionary<string, string> header)
        {
            _header = header;

            return this;
        }

        public IHttpRequestBuilder AddEncoding(Encoding encoding)
        {
            _encoding = encoding;
            return this;
        }

        public async Task<HttpResponseMessage> SendAsync()
        {
            // Setup request
            var request = new HttpRequestMessage
            {
                Method = this._method,
                RequestUri = new Uri(this._requestUri)
            };

            if (this._content != null)
            {
                request.Content = this._content;
            }
                


            if (!string.IsNullOrEmpty(this._bearerToken))
                request.Headers.Authorization =
                  new AuthenticationHeaderValue("Bearer", this._bearerToken);

            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this._acceptHeader))
                request.Headers.Accept.Add(
                   new MediaTypeWithQualityHeaderValue(this._acceptHeader));

            if (_header != null && _header.Any())
            {
                foreach (var key in _header.Keys)
                {
                    request.Headers.Add(key, _header[key]);
                }
            }

           // _client.Timeout = this._timeout;

            return await _client.SendAsync(request);
        }
        
    }
}
