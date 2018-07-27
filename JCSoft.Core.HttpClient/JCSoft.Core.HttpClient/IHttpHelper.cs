using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.Core.HttpClient
{
    public interface IHttpHelper
    {
        Task<string> GetAsync(string url, object requestParams = null, Dictionary<string, string> headers = null);
        
        Task<T> GetAsync<T>(string url, object requestParams = null, Dictionary<string, string> headers = null);

        Task<string> PostAsync(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null);

        Task<T> PostAsync<T>(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null);

        Task<string> PutAsync(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null);

        Task<T> PutAsync<T>(string url, object data = null, Dictionary<string, string> headers = null, Encoding coding = null);
        Task<string> DeleteAsync(string url, object requestParams = null, Dictionary<string, string> headers = null);

        Task<T> DeleteAsync<T>(string url, object requestParams = null, Dictionary<string, string> headers = null);
    }
}