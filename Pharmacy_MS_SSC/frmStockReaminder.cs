using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmStockRemainder : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection _conn = new SqlConnection(dbCon.ConnectionString());

        public frmStockRemainder()
        {
            InitializeComponent();
        }

        private void StockRemainderItems()
        {
            _conn.Close();
            _conn.Open();
            var query = "SELECT tblStock.*, tblTradeName.TradeName, tblGenericName.GenericName, tblVendor.VendorName " +
                        "FROM tblStock " +
                        "LEFT JOIN tblTradeName ON tblStock.TradeCode=tblTradeName.TradeCode " +
                        "LEFT JOIN tblVendor ON tblTradeName.VendorID=tblVendor.id " +
                        "LEFT JOIN tblGenericName ON tblTradeName.GenericID=tblGenericName.id " +
                        "WHERE tblStock.Qty<=tblStock.REMAINDER_QTY AND (tblTradeName.TradeName LIKE '%"+saTextBoxSearch.Text+"%' " +
                        "OR tblStock.TradeCode='" + saTextBoxSearch.Text + "') " +
                        " ORDER BY tblStock.Qty DESC";
            var cmd = new SqlCommand(query, _conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                labelReaminderQty.Text = "";
                listViewRemainderList.Items.Clear();
                var sl = 1;
                foreach (DataRow row in dt.Rows)
                {
                    var lvi = new ListViewItem(sl.ToString());
                    lvi.SubItems.Add(row["TradeCode"].ToString());
                    lvi.SubItems.Add(row["TradeName"].ToString());
                    lvi.SubItems.Add(row["Qty"].ToString());
                    lvi.SubItems.Add(row["REMAINDER_QTY"].ToString());
                    lvi.SubItems.Add(row["GenericName"].ToString());
                    lvi.SubItems.Add(row["VendorName"].ToString());

                    listViewRemainderList.Items.Add(lvi);

                    listViewRemainderList.EnsureVisible(sl - 1);

                    sl++;
                    Application.DoEvents();
                }
            }

            labelReaminderQty.Text = listViewRemainderList.Items.Count.ToString();
            Refresh();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            StockRemainderItems();
        }

        private void saTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                StockRemainderItems();
            }
        }

    }
}
