using System;
using System.Threading.Tasks;
using Application.Currency;

namespace Application.Services
{
    public interface IExchangeRateService
    {
        Task<Currencies> CurrenciesAsync(string fromDate, string toDate);
    }
}