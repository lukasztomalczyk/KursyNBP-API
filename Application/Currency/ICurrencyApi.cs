using System;
using System.Collections.Generic;
using System.Text;

namespace NBPApiClientCore.Currency
{
    public interface ICurrencyApi
    {
        IDictionary<DateTime, IList<ICurrencyRate>> GetCurrenciesFromApi(DateTime fromDate, DateTime toDate);
    }
}
