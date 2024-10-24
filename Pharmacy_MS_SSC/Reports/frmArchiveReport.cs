using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC.Reports
{
    public partial class frmArchiveReport : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private string _companyId;
        private string _tradeCode;
        private int _currentExpiryIndex;
        private int _totalExpiryItems;


        public frmArchiveReport()
        {
            InitializeComponent();
        }


        private void ExpiringSoonFilterByTradeId()
        {
            listViewArchiveList.Items.Clear();

            conn.Close();
            conn.Open();
            var query =
                "SELECT TP.TradeCode, TN.TradeName, TP.BatchNo, TP.PurchaseDate, TP.ManufactureDate, TP.ExpiryDate, TV.VendorName " +
                "FROM tblPurchase TP LEFT JOIN tblTradeName TN ON TP.TradeCode=TN.TradeCode " +
                "LEFT JOIN tblVendor TV ON TP.VendorId=TV.id WHERE TP.STATUS='SO' AND TP.TradeCode='" + _tradeCode +
                "' ORDER BY TradeCode";
            var cmd = new SqlCommand(query, conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var sl = 1;
                foreach (DataRow row in dt.Rows)
                {
                    var lvi = new ListViewItem(sl.ToString());
                    lvi.SubItems.Add(row["TradeCode"].ToString());
                    lvi.SubItems.Add(row["TradeName"].ToString());
                    lvi.SubItems.Add(row["BatchNo"].ToString());
                    lvi.SubItems.Add(Convert.ToDateTime(row["PurchaseDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(Convert.ToDateTime(row["ManufactureDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(Convert.ToDateTime(row["ExpiryDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(row["VendorName"].ToString());
                    
                    listViewArchiveList.Items.Add(lvi);

                    labelTotalItems.Text = @"Total items : " + sl;
                    listViewArchiveList.EnsureVisible(sl - 1);
                    sl++;
                    Refresh();
                }
            }

            labelTotalItems.Text = @"Total items : " + listViewArchiveList.Items.Count;
        }

        private void ExpiringSoonFilterByCompany()
        {
            listViewArchiveList.Items.Clear();

            conn.Close();
            conn.Open();
            var query =
                "SELECT TP.TradeCode, TN.TradeName, TP.BatchNo, TP.PurchaseDate, TP.ManufactureDate, TP.ExpiryDate, TV.VendorName " +
                "FROM tblPurchase TP LEFT JOIN tblTradeName TN ON TP.TradeCode=TN.TradeCode " +
                "LEFT JOIN tblVendor TV ON TP.VendorId=TV.id WHERE TP.STATUS='SO' AND TP.VendorId='" + _companyId +
                "' ORDER BY TradeCode";
            var cmd = new SqlCommand(query, conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var sl = 1;
                foreach (DataRow row in dt.Rows)
                {
                    var lvi = new ListViewItem(sl.ToString());
                    lvi.SubItems.Add(row["TradeCode"].ToString());
                    lvi.SubItems.Add(row["TradeName"].ToString());
                    lvi.SubItems.Add(row["BatchNo"].ToString());
                    lvi.SubItems.Add(Convert.ToDateTime(row["PurchaseDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(Convert.ToDateTime(row["ManufactureDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(Convert.ToDateTime(row["ExpiryDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(row["VendorName"].ToString());
                    
                    listViewArchiveList.Items.Add(lvi);

                    labelTotalItems.Text = @"Total items : " + sl;
                    listViewArchiveList.EnsureVisible(sl - 1);
                    sl++;
                    Refresh();
                }
            }

            labelTotalItems.Text = @"Total items : " + listViewArchiveList.Items.Count;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labelPin_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void textBoxCompany_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            textBoxCompany.Clear();
            var cmd = new SqlCommand("SELECT id, VendorName FROM tblVendor", conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            dataGridViewCompany.DataSource = dt;
            panelCompany.Visible = true;
        }

        private void textBoxCompany_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("SELECT id, VendorName FROM tblVendor WHERE VendorName LIKE '%" + textBoxCompany.Text + "%'", conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridViewCompany.DataSource = dt;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void dataGridViewCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _companyId = dataGridViewCompany.Rows[e.RowIndex].Cells["id"].Value.ToString();
                textBoxCompany.Text = dataGridViewCompany.Rows[e.RowIndex].Cells["VendorName"].Value.ToString();
                panelCompany.Visible = false;
                ExpiringSoonFilterByCompany();
            }
            catch
            {
                //
            }
        }

        private void dataGridViewCompany_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewCompany.Rows[e.RowIndex].Cells["vSL"].Value = (e.RowIndex + 1).ToString();
        }

        private void textBoxTradeName_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                textBoxTradeName.Clear();
                var cmd = new SqlCommand("SELECT id, TradeCode, TradeName FROM tblTradeName", conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridViewTradeList.DataSource = dt;

                panelTradeName.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxTradeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("SELECT id, TradeCode, TradeName FROM tblTradeName WHERE TradeName LIKE '%" + textBoxTradeName.Text + "%'", conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridViewTradeList.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewTradeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _tradeCode = dataGridViewTradeList.Rows[e.RowIndex].Cells["tTradeCode"].Value.ToString();
                textBoxTradeName.Text = dataGridViewTradeList.Rows[e.RowIndex].Cells["tTradeName"].Value.ToString();

                panelTradeName.Visible = false;

                ExpiringSoonFilterByTradeId();
            }
            catch
            {
                //
            }
        }

        private void dataGridViewTradeList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewTradeList.Rows[e.RowIndex].Cells["tSl"].Value = (e.RowIndex + 1).ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panelCompany.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panelTradeName.Hide();
        }

        private void buttonAllArchive_Click(object sender, EventArgs e)
        {
            listViewArchiveList.Items.Clear();

            conn.Close();
            conn.Open();
            var query =
                "SELECT TP.TradeCode, TN.TradeName, TP.BatchNo, TP.PurchaseDate, TP.ManufactureDate, TP.ExpiryDate, TV.VendorName " +
                "FROM tblPurchase TP LEFT JOIN tblTradeName TN ON TP.TradeCode=TN.TradeCode " +
                "LEFT JOIN tblVendor TV ON TP.VendorId=TV.id WHERE TP.STATUS='SO' ORDER BY TradeCode";
            var cmd = new SqlCommand(query, conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var sl = 1;
                foreach (DataRow row in dt.Rows)
                {
                    var lvi = new ListViewItem(sl.ToString());
                    lvi.SubItems.Add(row["TradeCode"].ToString());
                    lvi.SubItems.Add(row["TradeName"].ToString());
                    lvi.SubItems.Add(row["BatchNo"].ToString());
                    lvi.SubItems.Add(Convert.ToDateTime(row["PurchaseDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(Convert.ToDateTime(row["ManufactureDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(Convert.ToDateTime(row["ExpiryDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lvi.SubItems.Add(row["VendorName"].ToString());

                    listViewArchiveList.Items.Add(lvi);

                    listViewArchiveList.EnsureVisible(sl - 1);
                    sl++;
                }
            }

            labelTotalItems.Text = @"Total items : " + listViewArchiveList.Items.Count;
        }

    }
}
