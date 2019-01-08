using Application.Currency;
using Application.DTO;
using Application.Models;
using Infrastructure.ConnectionClient;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IDefaultHttpClientAccessor _client;
        private readonly IExchangeRateService _exchangeRateService;
        private readonly Urls _options;

        public CalculatorService(IDefaultHttpClientAccessor client, IOptions<Urls> options, IExchangeRateService exchangeRateService)
        {
            _client = client;
            this._exchangeRateService = exchangeRateService;
            _options = options.Value;
            _client.SetConnection(_options.MainURL);
        }

        public async Task<ResultModel<CalculateValute>> ExchangeRateAsync(CalculateValute calculateValute)
        {
            var actualyCurrency = await _exchangeRateService.CurrenciesAsync(default(DateTime), default(DateTime));
            var targetCurrencyList = actualyCurrency.Result.ToList();
            var targetCurrency = targetCurrencyList[0].rates;

            calculateValute.targetcurrency = targetCurrency.Where(a => a.code == calculateValute.targetcurrencycode)
                    .Select(a => a.mid).First();
            calculateValute.basiccurrency = targetCurrency.Where(a => a.code == calculateValute.basiccurrencycode)
                    .Select(a => a.mid).First();

            calculateValute.value = (calculateValute.basiccurrency * calculateValute.basiccurrencyinput) / calculateValute.targetcurrency;

            return new ResultModel<CalculateValute>()
            {
                Code = 200,
                Message = null,
                Result = calculateValute
            };
        }
    }

}
