
using System;

namespace Pharmacy_MS_SSC.Reports.Models
{
    public class VendorPayment
    {
        public double ID { get; set; }
        public string PAY_INV { get; set; }
        public string PURCHASE_INV { get; set; }
        public string PURCHASE_INV_VENDOR { get; set; }
        public double PAY_AMT { get; set; }
        public DateTime PAY_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public string UPDATE_BY { get; set; }
        public DateTime INV_DATE { get; set; }
        public string SELLER_NAME { get; set; }

    }
}
