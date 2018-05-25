using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.Http
{
    public interface IHttpRequestBuilder
    {
        IHttpRequestBuilder AddMethod(HttpMethod httpMethod);
        IHttpRequestBuilder AddUri(string requestUri);
        IHttpRequestBuilder AddContent(HttpContent httpContent);
        IHttpRequestBuilder AddBearerToken(string token);
        IHttpRequestBuilder AddAcceptHeader(string acceptHeader);
        IHttpRequestBuilder AddHeader(Dictionary<String, String> header);
        IHttpRequestBuilder AddTimeout(TimeSpan time);
        Task<HttpResponseMessage> SendAsync();
    }
}
