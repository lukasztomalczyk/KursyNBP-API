using System;

namespace NBPApiClientCore
{
    public class CurrencyRate : ICurrencyRate
    {
        public string Waluta { get; set; }
        public decimal Kurs { get; set; }
        public string Kod { get; set; }
        public decimal PLN { get; set; }

        public decimal CalculateCurrency()
        {
            return Math.Round((PLN/Kurs),2);
        }
    }
}
