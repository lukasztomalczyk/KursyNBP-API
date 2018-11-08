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

        public async Task<Currencies> CurrenciesAsync(string fromDate, string toDate)
        {
            var result = await _client.GetStringAsync(UrlWithDate(fromDate, toDate));
            return MapToCurrencies(result);
        }

        private string UrlWithDate(string from, string to)
        {
            return (String.IsNullOrWhiteSpace(from) && String.IsNullOrWhiteSpace(to)) 
                    ? _options.Currencies : _options.Currencies + "/" + from + "/" + to;
        }
    }
}