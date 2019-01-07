using System;
using System.Threading.Tasks;
using Application.Currency;
using Application.DTO;

namespace Application.Services
{
    public interface IExchangeRateService
    {
        Task<ResultModel<Currencies[]>> CurrenciesAsync(DateTime fromDate, DateTime toDate);
    }
}