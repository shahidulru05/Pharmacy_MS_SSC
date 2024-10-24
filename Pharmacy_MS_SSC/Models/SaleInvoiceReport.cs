namespace Pharmacy_MS_SSC.Models
{
    public class SaleInvoiceReport
    {
        public int Id { get; set; }
        public string InvNo { get; set; }
        public string TradeCode { get; set; }
        public string TradeName { get; set; }
        public string SaleType { get; set; }
        public double UnitPrice { get; set; }
        public double Qty { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public string UserName { get; set; }

    }
}
