using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class ReceivedCurrencyModel
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public ReceivedRates[] rates { get; set; }
    }

    public class ReceivedRates
    {
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public double bid { get; set; }
        public double ask { get; set; }
    }


//    model {
//    "table": "C",
//    "currency": "dolar amerykański",
//    "code": "USD",
//    "rates": [
//        {
//            "no": "004/C/NBP/2019",
//            "effectiveDate": "2019-01-07",
//            "bid": 3.7455,
//            "ask": 3.8211
//        }
//    ]
//}
}
