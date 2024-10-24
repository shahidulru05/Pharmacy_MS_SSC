using System;

namespace Pharmacy_MS_SSC.Models
{
    public class DateToDateSaleReport
    {
        public string InvNo { get; set; }
        public DateTime SaleDate { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public double Adjustment { get; set; }
        public double GrandTotal { get; set; }
        public double TotalDue { get; set; }
        public string UserName { get; set; }
        public double PurchasePrice { get; set; }
        public double TotalItem { get; set; }
        public double MobileNo { get; set; }
        public double PatientName { get; set; }

        
        
    }
}
