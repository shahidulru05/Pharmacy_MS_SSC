using System.Data;

namespace Pharmacy_MS_SSC.Common
{
    public class GlobalSettings
    {
        //Variable
        private static string _devUser = "DEVELOPER";
        private static string _devPass = "developer12345";
        private static string _viewDateFormatShort = "dd-MMM-yy";
        private static string _viewDateFormatShortWithDay = "dddd dd-MMM-yy";
        private static string _saveDateFormat = "M/d/yyyy";
        private static string _saveTimeFormat = "h:mm tt";
        public static bool LoanRemainder = false;
        public static double SaleMemoSize;
        public static bool InputSamplePrice = false;
        public static bool AddToArchive = false;

        //Invoice Variable
        public static string PurchaseReturn { get {return "PRI-";} }

        //Property
        public static string DevUser { get { return _devUser; } }
        public static string DevPass { get { return _devPass; } }
        public static DataTable OfficeInfo { get; set; }
        public static string Server { get; set; }
        public static string EmployeeId { get; set; }
        public static string UserName { get; set; }
        public static string UserRole { get; set; }
        public static string DateFormatShortView { get { return _viewDateFormatShort; } }
        public static string DateFormatShortWithDateView { get { return _viewDateFormatShort; } }
        public static string DateFormatSave { get { return _saveDateFormat; } }
        public static string TimeFormatSave { get { return _saveTimeFormat; } }



    }
}
