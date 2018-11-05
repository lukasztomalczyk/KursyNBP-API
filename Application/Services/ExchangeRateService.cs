using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using Infrastructure.ConnectionClient;
using Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Application.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IClient _client;
        private readonly Urls _options;

        public ExchangeRateService(IClient client, IOptions<Urls> options)
        {
            _client = client;
            _options = options.Value;
            _client.SetupConnection(_options.MainURL);
        }

        public async Task<Currencies> CurrenciesAsync(DateTime fromDate, DateTime toDate)
        {
            var result = await _client.GetStringAsync(_options.Currencies);

            return default(Currencies);
        }
    }
}