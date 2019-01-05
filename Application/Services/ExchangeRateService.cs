using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Currency;
using Application.DTO;
using Infrastructure.ConnectionClient;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static Application.Helpers.ServicesHelper;

namespace Application.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IDefaultHttpClientAccessor _client;
        private readonly Urls _options;

        public ExchangeRateService(IDefaultHttpClientAccessor client, IOptions<Urls> options)
        {
            _client = client;
            _options = options.Value;
            _client.SetConnection(_options.MainURL);
        }

        public async Task<Currencies> CurrenciesAsync(DateTime fromDate, DateTime toDate)
        {
            var result = await _client.GetStringAsync(UrlWithDate(fromDate, toDate));
            return MapToCurrencies(result);
        }

        private string UrlWithDate(DateTime from, DateTime to)
        {
            if (from != default(DateTime) && to != default(DateTime))
            {
                return _options.Currencies + Convert.ToDateTime(from).ToString("yyyy-mm-dd") + "/" + Convert.ToDateTime(to).ToString("yyyy-mm-dd");
            }
            else
            {
                return _options.Currencies;
            }
        }
    }
}