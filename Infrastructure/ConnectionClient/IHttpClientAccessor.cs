using System.Net.Http;

namespace Infrastructure.ConnectionClient
{
    public interface IHttpClientAccessor
    {
        HttpClient HttpClient { get; }
    }
}