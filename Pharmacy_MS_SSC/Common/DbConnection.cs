using System.IO;

namespace Pharmacy_MS_SSC.Common
{
    public class DbConnection
    {
        public string serverName = File.ReadAllText("host.txt");
        public string databaseName = "PHARMACY_MS_SSC";
        public string userId = "sa";
        public string password = "bkbabu";

        public string ConnectionString()
        {
            var connectionString = (@"Data Source=" + serverName +
                                    "; Initial Catalog=" + databaseName +
                                    "; User ID=" + userId +
                                    "; Password=" + password + "");
            return connectionString;
        }
    }


}
