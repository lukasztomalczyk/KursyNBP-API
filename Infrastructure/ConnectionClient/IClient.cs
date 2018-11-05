using System.Threading.Tasks;

namespace Infrastructure.ConnectionClient
{
    public interface IClient
    {
        void SetupConnection(string url);
        Task<string> GetStringAsync(string url);
    }
}