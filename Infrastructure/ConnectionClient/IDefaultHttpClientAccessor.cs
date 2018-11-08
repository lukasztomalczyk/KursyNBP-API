using System.Threading.Tasks;

namespace Infrastructure.ConnectionClient
{
    public interface IDefaultHttpClientAccessor
    {
        void SetConnection(string url);
        Task<string> GetStringAsync(string url);
    }
}