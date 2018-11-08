using System;
using System.Threading.Tasks;
using Application.Currency;
using Newtonsoft.Json;

namespace Application.Helpers
{
    public static class ServicesHelper
    {
        public static Currencies MapToCurrencies(string data)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<Currencies[]>(data);
                return result[0];
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}