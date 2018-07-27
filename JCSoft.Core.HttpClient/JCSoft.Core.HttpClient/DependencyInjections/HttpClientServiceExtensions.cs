using JCSoft.Core.Http;
using JCSoft.Core.HttpClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HttpClientServiceExtensions
    {
        public static IServiceCollection AddHttpClientService(this IServiceCollection services)
        {
            //services.AddHttpClient();
            services.AddSingleton<IHttpRequestBuilder, HttpRequestBuilder>();
            services.AddSingleton<IHttpHelper, HttpHelper>();

            return services;
        }
    }
}