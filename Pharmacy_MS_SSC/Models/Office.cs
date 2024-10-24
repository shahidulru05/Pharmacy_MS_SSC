using System.Drawing;

namespace Pharmacy_MS_SSC.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public Image Logo { get; set; }
    }
}
