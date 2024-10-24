using System;

namespace Pharmacy_MS_SSC.Reports.Models
{
    public class PatientInformation
    {
        public int id { get; set; }
        public string InvNo { get; set; }
        public string PatientID { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double GrandTotal { get; set; }
        public double Payment { get; set; }
        public double TotalDue { get; set; }
        public double Refund { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime SaleTime { get; set; }
        public int TotalItem { get; set; }
        public string UserName { get; set; }
        public string PatientName { get; set; }
        public double PurchasePrice { get; set; }
        
    }
}
