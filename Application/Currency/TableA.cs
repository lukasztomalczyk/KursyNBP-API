using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBPApiClientCore
{
    public class TableA
    {
        public string Table { get; set; }
        public string No { get; set; }
        public string effectiveDate { get; set; }
        public List<Rates> rates { get; set; }
    }
}
