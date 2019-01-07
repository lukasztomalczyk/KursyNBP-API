using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Currency;
using Application.DTO;
using Newtonsoft.Json;

namespace Application.Helpers
{
    public static class ServicesHelper
    {
        public static ResultModel<Currencies[]> MapToCurrencies(string data)
        {
            try
            {
                var json = JsonConvert.DeserializeObject<Currencies[]>(data);
                var result = new ResultModel<Currencies[]>() { Result = json,
                Code = 200,
                Message = null };
                return result;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}