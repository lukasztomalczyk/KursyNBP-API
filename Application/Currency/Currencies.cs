using System.Collections.Generic;

namespace Application.Currency
{
    public class Currencies
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public List<Rates> rates { get; set; }
    }
}
