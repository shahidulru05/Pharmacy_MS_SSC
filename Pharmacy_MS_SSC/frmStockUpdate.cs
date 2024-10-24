using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmStockUpdate : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private string _tradeCode;
        private int vendorID;
        private string stockTempID;
        public frmStockUpdate()
        {
            InitializeComponent();
            
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            LoadStockUpdateTempData();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
            }
            else
            {
                this.TopMost = true;
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
            }
            else
            {
                this.TopMost = true;
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString(); 
            lblTime.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = true;
            LoadTradeNameToGrid();
            textBoxTradeCode.Clear();
            textBoxVendor.Clear();
            button1.Enabled = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            panelTrade.Visible = true;
            LoadTradeNameToGrid();
        }

        private void LoadTradeNameToGrid()
        {
            try
            {
                conn.Close();
                conn.Open();

                var query = "SELECT tblTradeName.TradeCode, tblTradeName.TradeName, tblVendor.VendorName " +
                            "FROM tblTradeName INNER JOIN " +
                            "tblVendor ON tblTradeName.VendorID = tblVendor.id";
                var cmd = new SqlCommand(query, conn);
                var da=new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells["sl"].Value = (e.RowIndex + 1).ToString();
        }

        private void LoadStock(string tradeCode)
        {
            try
            {
                if (textBoxTradeName.Text != "")
                {
                    conn.Close();
                    conn.Open();

                    var cmd = new SqlCommand("SELECT * FROM tblStock WHERE TradeCode='" + tradeCode + "'");
                    cmd.Connection = conn;
                    var odr = cmd.ExecuteReader();
                    if (odr.Read())
                    {
                        textBoxRunStock.Text = odr["Qty"].ToString();
                        textBoxRunWSPrice.Text = odr["wsPrice"].ToString();
                        textBoxWsPrice.Text = odr["wsPrice"].ToString();
                        textBoxRunSaleMrp.Text = odr["SaleMRP"].ToString();
                        textBoxSaleMrp.Text = odr["SaleMRP"].ToString();
                        textBoxCurrentStock.Text = odr["Qty"].ToString();
                        textBoxRunPPrice.Text = odr["UnitPrice"].ToString();
                        textBoxPurchaseUnitPrice.Text = odr["UnitPrice"].ToString();
                        conn.Close();
                    }
                    odr.Close();
                }
                else
                {
                    textBoxRunStock.Clear();
                    textBoxRunWSPrice.Clear();
                    textBoxRunSaleMrp.Clear();
                    textBoxCurrentStock.Clear();
                    textBoxRunPPrice.Clear();
                    textBoxPurchaseUnitPrice.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxQty.Text = "0";
            }
        }
        
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["gsl"].Value = (e.RowIndex + 1).ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBoxWsPrice.Text!="0" && textBoxSaleMrp.Text!="0")
                {
                    conn.Close();
                    conn.Open();
                    var cmd1 = new SqlCommand("SELECT * FROM tblStock_temp WHERE TradeCode='"+_tradeCode+"'", conn);
                    var dr = cmd1.ExecuteReader();
                    if (!dr.Read())
                    {
                        // o = Old, t = Total
                        var oQty = Convert.ToDouble(textBoxRunStock.Text);
                        var oUnitPrice = Convert.ToDouble(textBoxRunPPrice.Text);
                        var pQty = Convert.ToDouble(textBoxQty.Text);
                        var pUnitPrice = Convert.ToDouble(textBoxPurchaseUnitPrice.Text);

                        var oTotalPrice = oQty * oUnitPrice;
                        var pTotalPrice = pQty * pUnitPrice;

                        var tQty = pQty + oQty;
                        var tUnitPrice = oTotalPrice + pTotalPrice;

                        var rUnitPrice = tUnitPrice / tQty;

                        conn.Close();
                        conn.Open();
                        var cmd = new SqlCommand(
                            "INSERT INTO tblStock_temp (TradeCode,TradeName,Vendor,Qty,CurrentQty,wsPrice,SaleMRP,UnitPrice,UserName) VALUES ('" +
                            textBoxTradeCode.Text + "','" + textBoxTradeName.Text + "','" + textBoxVendor.Text + "','" +
                            textBoxRunStock.Text + "','" + tQty + "','" + textBoxWsPrice.Text +
                            "','" + textBoxSaleMrp.Text + "','" + rUnitPrice + "','" +
                            GlobalSettings.UserName + "' )", conn);
                        cmd.ExecuteNonQuery();

                        LoadStockUpdateTempData();

                        textBoxTradeCode.Clear();
                        textBoxTradeName.Clear();
                        textBoxVendor.Clear();
                        textBoxRunStock.Clear();
                        textBoxQty.Clear();
                        textBoxCurrentStock.Clear();
                        textBoxRunWSPrice.Clear();
                        textBoxRunSaleMrp.Clear();
                        textBoxWsPrice.Clear();
                        textBoxSaleMrp.Clear();
                        textBoxPurchaseUnitPrice.Clear();
                        textBoxRunPPrice.Clear();

                        textBoxTradeName.Focus();
                    }
                    else
                    {
                        MessageBox.Show("This item already exists under you or another user", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please fill all fileld and try again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStockUpdateTempData()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblStock_temp WHERE UserName='" + GlobalSettings.UserName + "'", conn);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            button3.Visible = dataGridView1.Rows.Count > 0;
            
            label14.Text = dataGridView1.Rows.Count.ToString();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                stockTempID = dataGridView1.Rows[e.RowIndex].Cells["gid"].Value.ToString();
                label12.Text = dataGridView1.Rows[e.RowIndex].Cells["gTradeName"].Value.ToString();
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;

            label12.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE tblStock_temp WHERE id='"+stockTempID+"' AND UserName='" + GlobalSettings.UserName + "'", conn);
            cmd.ExecuteNonQuery();

            button4.PerformClick();

            LoadStockUpdateTempData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (int ss = 0; ss < dataGridView1.Rows.Count; ss++)
                {
                    var quantity = dataGridView1.Rows[ss].Cells["gQuantity"].Value;
                    var wsPrice = dataGridView1.Rows[ss].Cells["gWSPrice"].Value;
                    var saleMRP = dataGridView1.Rows[ss].Cells["gSaleMRP"].Value;
                    var tradeCode = dataGridView1.Rows[ss].Cells["TradeCode"].Value;
                    var unitPrice = dataGridView1.Rows[ss].Cells["unitPrice"].Value;

                    conn.Close();
                    conn.Open();
                    var query = "UPDATE tblStock SET Qty='"+quantity+"', wsPrice='"+wsPrice+"', SaleMRP='"+saleMRP+"', UnitPrice='"+unitPrice+"' WHERE TradeCode='"+tradeCode+"' ";
                    var cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                conn.Open();
                var cmd1=new SqlCommand("DELETE tblStock_temp WHERE UserName='" + GlobalSettings.UserName + "'", conn);
                cmd1.ExecuteNonQuery();

                LoadStockUpdateTempData();

                MessageBox.Show("Successfully Submitted Final Posting", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxWsPrice.Text) > 0) { }
            }
            catch
            {
                textBoxWsPrice.Text = textBoxRunWSPrice.Text;
                textBoxWsPrice.SelectAll();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxSaleMrp.Text) > 0) { }
            }
            catch
            {
                textBoxSaleMrp.Text = textBoxRunSaleMrp.Text;
                textBoxSaleMrp.SelectAll();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();

                var query = "SELECT tblTradeName.TradeCode, tblTradeName.TradeName, tblVendor.* " +
                            "FROM tblTradeName INNER JOIN " +
                            "tblVendor ON tblTradeName.VendorID = tblVendor.id " +
                            "WHERE TradeName LIKE('" + textBoxTradeName.Text.Trim() + "%')";
                var cmd = new SqlCommand(query, conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxQty.Text) >= 0)
                {
                    textBoxCurrentStock.Text = (Convert.ToDouble(textBoxRunStock.Text) + Convert.ToDouble(textBoxQty.Text)).ToString();
                }
                else
                {
                    textBoxCurrentStock.Text = textBoxRunStock.Text;
                }
            }
            catch
            {
                textBoxCurrentStock.Text = textBoxRunStock.Text;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                textBoxTradeCode.Text = dataGridView2.SelectedRows[0].Cells["TradeCodeP"].Value.ToString();
                textBoxTradeName.Text = dataGridView2.SelectedRows[0].Cells["TradeNameP"].Value.ToString();
                textBoxVendor.Text = dataGridView2.SelectedRows[0].Cells["VendorP"].Value.ToString();

                LoadStock(dataGridView2.SelectedRows[0].Cells["TradeCodeP"].Value.ToString());
                _tradeCode = dataGridView2.SelectedRows[0].Cells["TradeCodeP"].Value.ToString();

                panelTrade.Visible = false;
                textBoxQty.ReadOnly = false;
                textBoxQty.Focus();
                textBoxWsPrice.ReadOnly = false;
                textBoxSaleMrp.ReadOnly = false;
                button1.Enabled = true;
            }
            else
            {
                // Display a message box with Icon. 
                textBoxQty.ReadOnly = true;
                textBoxWsPrice.ReadOnly = true;
                textBoxSaleMrp.ReadOnly = true;
                button1.Enabled = false;
                MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelTradeClose_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = false;
        }
    }
}
