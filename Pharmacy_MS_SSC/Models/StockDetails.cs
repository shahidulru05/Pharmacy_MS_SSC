
namespace Pharmacy_MS_SSC.Models
{
    public class StockDetails
    {
        public int Sl { get; set; }
        public string TradeCode { get; set; }
        public string TradeName { get; set; }
        public string CategoryName { get; set; }
        public string GenericName { get; set; }
        public string VendorName { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotalCost { get; set; }
        public double wsPrice { get; set; }
        public double TotalWsPrice { get; set; }
        public double ProfitWsPrice { get; set; }
        public double SaleMRP { get; set; }
        public double TotalSaleMRP { get; set; }
        public double ProfitSaleMRP { get; set; }
    }
}
