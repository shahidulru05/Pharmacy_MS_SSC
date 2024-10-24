using System;

namespace Pharmacy_MS_SSC.Reports.Models
{
    public class Purchase
    {
        public string InvNo { get; set; }
        public string PurchaseType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string TradeId { get; set; }
        public string TradeName { get; set; }
        public string TradeCode { get; set; }
        public string PurchaseInvNo { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double WSPrice { get; set; }
        public double SaleMRP { get; set; }
        public double RunStock { get; set; }
        public double TotalCost { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string BatchNo { get; set; }
        public string UserName { get; set; }
        
    }
}
