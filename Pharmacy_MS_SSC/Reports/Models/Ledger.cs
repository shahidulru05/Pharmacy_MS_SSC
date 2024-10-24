using System;

namespace Pharmacy_MS_SSC.Reports.Models
{
    public class Ledger
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
    }
}
