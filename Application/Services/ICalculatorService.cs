using System.Threading.Tasks;
using Application.DTO;
using Application.Models;

namespace Application.Services
{
    public interface ICalculatorService
    {
        Task<ResultModel<CalculateValute>> ExchangeRateAsync(CalculateValute calculateValute);
    }
}