using System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.ConnectionClient
{
    public class DefaultHttpClientAccessor : IHttpClientAccessor, IDefaultHttpClientAccessor
    {
        public HttpClient HttpClient { get; }

        public DefaultHttpClientAccessor()
        {
            HttpClient = new HttpClient();
        }

        public void SetConnection(string url)
        {
            HttpClient.BaseAddress = new Uri(url);
        }
        
        public async Task<string> GetStringAsync(string url)
        {
            return await HttpClient.GetStringAsync(url);
        }
    }
}