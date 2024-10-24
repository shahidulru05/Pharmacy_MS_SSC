using System;

namespace Pharmacy_MS_SSC.Models
{
    public class SaleMaster
    {
        public string InvNo { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public double Adjustment { get; set; }
        public double GrandTotal { get; set; }
        public double Payment { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime SaleTime { get; set; }
        public string UserName { get; set; }
        public string Refund { get; set; }
        public double TotalDue { get; set; }

    }
}
