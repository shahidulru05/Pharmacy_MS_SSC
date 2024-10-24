using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_MS_SSC.Models
{
    public class DailyExpense
    {
        public int Id { get; set; }
        public string INV_NO { get; set; }
        public DateTime Date { get; set; }
        public int PayGatewayId { get; set; }
        public double Amount { get; set; }
        public string Person { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
