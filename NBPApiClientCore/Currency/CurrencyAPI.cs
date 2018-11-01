using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NBPApiClientCore
{
    public class CurrencyAPI
    {
        private static readonly HttpClient Client = new HttpClient();

        private const string ClientBaseStringUri = "https://api.nbp.pl";
        private const string ApiLink = "/api/exchangerates/tables/A/";

        static CurrencyAPI()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.BaseAddress = new Uri(ClientBaseStringUri);
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static IEnumerable<ICurrencyRate> GetCurrenciesFromApi()
        {
            return RunAsync().GetAwaiter().GetResult();
        }

        public static IDictionary<DateTime, List<ICurrencyRate>> GetCurrenciesFromApi(DateTime fromDate, DateTime toDate)
        {
            return RunAsync(fromDate, toDate).GetAwaiter().GetResult();
        }

        private static async Task<TableA[]> GetProductAsync(string path)
        {
            using (var response = await Client.GetAsync(path))
            {
                if (!response.IsSuccessStatusCode) return null;
                var str = await response.Content.ReadAsStringAsync();
                var tableAArray = JsonConvert.DeserializeObject<TableA[]>(str);

                return tableAArray;
            }
        }

        private static async Task<List<ICurrencyRate>> RunAsync()
        {
            var rates = new List<ICurrencyRate>();
            try
            {
                var tableAArray = await GetProductAsync(ApiLink);

                tableAArray.ToList()
                    .ForEach(x => x.rates
                    .ForEach(r =>
                  {
                      rates.Add(new CurrencyRate { Waluta = r.currency, Kurs = r.mid, Kod = r.code });
                  }));

                return rates;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        private static async Task<IDictionary<DateTime, List<ICurrencyRate>>> RunAsync(DateTime fromDate, DateTime toDate)
        {
            IDictionary<DateTime, List<ICurrencyRate>> rates = new ConcurrentDictionary<DateTime, List<ICurrencyRate>>();
            try
            {
                var tableAArray = await GetProductAsync(string.Format(ApiLink + "/" + fromDate.ToString("yyyy-MM-dd") + "/" + toDate.ToString("yyyy-MM-dd")));
                var currencyRateList = new List<ICurrencyRate>();

                foreach (var tableA in tableAArray)
                {
                    
                    foreach (var rates1 in tableA.rates)
                    {
                        currencyRateList.Add(new CurrencyRate()
                        {
                            Kurs = rates1.mid,
                            Waluta = rates1.currency,
                            Kod = rates1.code
                        });
                    }

                    rates.Add(DateTime.Parse(tableA.effectiveDate), currencyRateList);
                    currencyRateList.Clear();
                }


                return rates;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
