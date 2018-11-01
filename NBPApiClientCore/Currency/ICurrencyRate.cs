namespace NBPApiClientCore
{
    public interface ICurrencyRate
    {
        string Waluta { get; set; }
        decimal Kurs { get; set; }
        string Kod { get; set; }
        decimal CalculateCurrency();
    }
}
