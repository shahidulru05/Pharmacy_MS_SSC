using System;
using System.IO;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmWaiting waiting = new frmWaiting();
            waiting.Show();
            try
            {
                GlobalSettings.Server = File.ReadAllText("host.txt");
            }
            catch { }
            if (string.IsNullOrEmpty(GlobalSettings.Server))
            {
                MessageBox.Show("Server Not Found");
                Application.Exit();
            }
            else
            {
                try
                {
                    GlobalSettings.OfficeInfo = Db.GetDataTable("SELECT * FROM TBL_OFFICE WHERE STATUS='A'");
                }
                catch
                {
                    MessageBox.Show("Could Not Connect To Server\nPlease check if the server is shared");
                    Application.Exit();
                    return;
                }

                if (GlobalSettings.OfficeInfo.Rows.Count > 0)
                {
                    try { Db.QueryExecute("CREATE INDEX TBL_SALE_DTL_INVNO ON tblSaleDetails (InvNo)"); }
                    catch { }

                    try { Db.QueryExecute("CREATE INDEX TBL_TRADE_NAME_TRADE_CODE_NAME ON tblTradeName (TradeCode, TradeName)"); }
                    catch { }

                    try { Db.QueryExecute("CREATE INDEX TBL_STOCK_QTY_UNIT ON tblStock (Qty,UnitPrice) INCLUDE (id,TradeCode,wsPrice,SaleMRP,REMAINDER_QTY)"); }
                    catch { }
                    
                }


                waiting.Close();
                Application.Run(new frmLogin());
            }
            
        }
    }
}
