
using System;

namespace Pharmacy_MS_SSC.Reports.Models
{
    public class DueCollection
    {
        public string DUE_COLL_INV { get; set; }
        public string SALE_INV { get; set; }
        public double DUE_COLL { get; set; }
        public DateTime COLL_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public string UPDATE_BY { get; set; }
    }
}
