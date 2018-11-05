using System;
using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Infrastructure.ConnectionClient
{
    public class Client : IClient
    {
        private readonly HttpClient _httpClient;

        public Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetupConnection(string url)
        {
            _httpClient.BaseAddress = new Uri(url);
        }
        
        public async Task<string> GetStringAsync(string url)
        {
            return await _httpClient.GetStringAsync(url);
        }
    }
}