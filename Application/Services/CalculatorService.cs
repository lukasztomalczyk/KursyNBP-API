using Application.DTO;
using Application.Models;
using Infrastructure.ConnectionClient;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IDefaultHttpClientAccessor _client;
        private readonly Urls _options;

        public CalculatorService(IDefaultHttpClientAccessor client, IOptions<Urls> options)
        {
            _client = client;
            _options = options.Value;
            _client.SetConnection(_options.MainURL);
        }

        public async Task<ResultModel<ReceivedCurrencyModel[]>> ExchangeRateAsync(CalculateValute calculateValute)
        {
            var url1 = _options.ExchangeRateURL + calculateValute.basiccurrencycode+"/today/";
            var result1 = await _client.GetStringAsync(url1);
            var url2 = _options.ExchangeRateURL + calculateValute.targetcurrencycode + "/today/";
            var result2 = await _client.GetStringAsync(url2);

            var listReceivedModel = new ReceivedCurrencyModel[1];
            try
            {
                listReceivedModel[0] = MapToReceivedCurrencyModel(result1);
                listReceivedModel[1] = MapToReceivedCurrencyModel(result2);
                return new ResultModel<ReceivedCurrencyModel[]>()
                {
                    Code = 200,
                    Message = null,
                    Result = listReceivedModel
                };
            }
            catch (Exception)
            {
                return new ResultModel<ReceivedCurrencyModel[]>()
                {
                    Code = 400,
                    Message = "An error occurred while trying to read the current exchange rates",
                    Result = default(ReceivedCurrencyModel[])
                };
            }
   
        }

        private ReceivedCurrencyModel MapToReceivedCurrencyModel(string data)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<ReceivedCurrencyModel>(data);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Deserializacja niepowiaodła się", e);
            }
        }
    }

}
