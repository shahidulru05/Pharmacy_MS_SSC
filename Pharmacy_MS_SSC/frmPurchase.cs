using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmPurchase : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private int vendorID;

        public frmPurchase()
        {
            InitializeComponent();

            LoadPurchase_TempToGrid();
            PurchaseGridSum();
            LoadSallerList();
        }
        
        private void LoadSallerList()
        {
            try
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("SELECT id, VendorName FROM tblVendor", conn);
                var da=new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    comboBoxSallerName.DataSource = dt;
                    comboBoxSallerName.ValueMember = "id";
                    comboBoxSallerName.DisplayMember = "VendorName";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GenerateInvoice()
        {
            var year = Settings.Default.CURRENT_PERIOD;
            var defaultInvoice = "PINV-" + year + "1";

            conn.Close();
            SqlCommand cmd = new SqlCommand("SELECT InvNo FROM tblPurchase WHERE id = (SELECT MAX(id) AS ID FROM tblPurchase)");
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read() && !sdr.IsDBNull(0))
            {
                var db_invoice = sdr["InvNo"].ToString();
                var db_inv_year = db_invoice.Substring(5, 4);
                textBoxInvoiceNo.Text = Convert.ToInt32(db_inv_year) < Convert.ToInt32(year)
                    ? defaultInvoice
                    : new AutoGenerateInvoice().Invoice(db_invoice, "PINV-", 1);
            }
            else
            {
                textBoxInvoiceNo.Text = defaultInvoice;
            }
        }

        private void LoadTradeNameToGrid()
        {
            try
            {
                conn.Close();
                conn.Open();
                
                var query = "SELECT tblTradeName.id, tblTradeName.TradeCode, tblTradeName.TradeName, tblVendor.VendorName, " +
                            "tblVendor.id AS vendorId FROM tblTradeName INNER JOIN " +
                            "tblVendor ON tblTradeName.VendorID = tblVendor.id";
                SqlCommand cmd = new SqlCommand(query, conn);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPurchase_TempToGrid()
        {
            try
            {
                // generate bill id
                GenerateInvoice();
                
                conn.Close();
                conn.Open();

                var query =
                    "SELECT tblPurchase_Temp.*, tblTradeName.TradeName, tblVendor.VendorName " +
                    "FROM tblPurchase_Temp INNER JOIN " +
                    "tblTradeName ON tblPurchase_Temp.TradeCode = tblTradeName.TradeCode INNER JOIN " +
                    "tblVendor ON tblPurchase_Temp.VendorId = tblVendor.id " +
                    "WHERE UserName='" + GlobalSettings.UserName + "'";

                var cmd = new SqlCommand(query, conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                button3.Visible = dataGridView1.Rows.Count > 0;
                label24.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void textBox3_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = true;
            LoadTradeNameToGrid();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();

                var query = "SELECT tblTradeName.id, tblTradeName.TradeCode, tblTradeName.TradeName, tblVendor.id AS vendorId, tblVendor.VendorName " +
                            "FROM tblTradeName INNER JOIN " +
                            "tblVendor ON tblTradeName.VendorID = tblVendor.id "+
                            "WHERE TradeName LIKE('" + textBoxTradeName.Text.Trim() + "%')";
                SqlCommand cmd = new SqlCommand(query, conn);

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }
        
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            panelTrade.Visible = true;
            LoadTradeNameToGrid();
        }
        
        //Quty TextBox
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float totalCost = float.Parse(textBoxTotalCost.Text.Trim().ToString());
                if (textBoxTotalCost.Text.Trim() == "")
                {
                    DialogResult r1 = MessageBox.Show("Please Enter Unit Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxTotalCost.Text = "0";
                }
                else if (totalCost < 0)
                {
                    DialogResult r1 = MessageBox.Show("- Not Allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxTotalCost.Text = "0";
                }
                else if (textBoxQty.Text.Trim() == "")
                {
                    DialogResult r1 = MessageBox.Show("Please Enter Qty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    textBoxUnitPrice.Text = (float.Parse(textBoxTotalCost.Text.Trim()) / float.Parse(textBoxQty.Text.Trim())).ToString("F");

                }
            }
            catch
            {
                DialogResult r1 = MessageBox.Show("Please Type Correct Value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUnitPrice.Text = "0";
            }
            
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxUnitPrice.Text.Trim() == "")
            {
                textBoxUnitPrice.Text = "0";
            }   
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            frmTradeName ft = new frmTradeName();
            ft.Show();
        }
        
        //TextBox Clear
        public void txtClear()
        {
            textBoxTradeCode.Clear();
            textBoxTradeName.Clear();
            textBoxPurchaseInvoice.Clear();
            textBoxVendorName.Clear();
            textBoxQty.Text = "0";
            textBoxUnitPrice.Text = "0";
            textBoxWsPrice.Text = "0";
            textBoxSaleMrp.Text = "0";
            textBoxRunStock.Text = "0";
            textBoxTotalCost.Text = "0"; 
            textBoxBatchNo.Clear();
        }

        private void PurchaseGridSum()
        {
            double wsPrice = 0;
            double mrp = 0;
            double totalCost = 0;
            double unitPrice = 0;

            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    var quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells["ttQty"].Value.ToString());
                    wsPrice += Convert.ToDouble(dataGridView1.Rows[i].Cells["ttWSPrice"].Value.ToString()) * quantity;
                    mrp += Convert.ToDouble(dataGridView1.Rows[i].Cells["ttSaleMRP"].Value.ToString()) * quantity;
                    totalCost += Convert.ToDouble(dataGridView1.Rows[i].Cells["ttTotalCost"].Value.ToString());
                    unitPrice += Convert.ToDouble(dataGridView1.Rows[i].Cells["ttUnitPrice"].Value.ToString());
                    
                }
            }

            label27.Text = wsPrice.ToString();
            label29.Text = mrp.ToString();
            label31.Text = totalCost.ToString();

            labelWsTotalProfit.Text = (wsPrice - totalCost).ToString();
            labelMrpTotalProfit.Text = (mrp - totalCost).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Visible = dataGridView1.Rows.Count > 0;
            if(comboBoxPurchaseType.Text != "")
            {
                if (textBoxTradeCode.Text.Trim() != "")
                {
                    if (textBoxPurchaseInvoice.Text.Trim() != "")
                    {
                        float Qty = float.Parse(textBoxQty.Text.ToString());
                        if (Qty >= 1)
                        {
                            float UnitPrice = float.Parse(textBoxUnitPrice.Text.ToString());
                            if ((UnitPrice >= 0.1 && comboBoxPurchaseType.Text == "General") || comboBoxPurchaseType.Text != "General")
                            {

                                float WSPrice = float.Parse(textBoxWsPrice.Text.ToString());
                                if (WSPrice >= 0.1)
                                {
                                    float SaleMRP = float.Parse(textBoxSaleMrp.Text.ToString());
                                    if (SaleMRP >= 0.1)
                                    {
                                        if (textBoxBatchNo.Text.Trim() != "")
                                        {
                                            if(dateTimePicker1.Value.ToShortDateString() == dateTimePickerExpiryDate.Value.ToShortDateString())
                                            {
                                                // Display a message box with Icon. 
                                                MessageBox.Show("Please Check Manufacture & Expiry Date.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                dateTimePicker1.Focus();
                                            }
                                            else
                                            {
                                                conn.Close();
                                                conn.Open();
                                                DataTable dt = new DataTable();
                                                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM tblPurchase_Temp WHERE PurchaseType='" + comboBoxPurchaseType.Text.Trim() + "' AND TradeCode='" + textBoxTradeCode.Text + "' AND BatchNo='"+textBoxBatchNo.Text.Trim()+"' AND UserName='" + GlobalSettings.UserName + "'", conn);
                                                sda.Fill(dt);

                                                if (dt.Rows.Count == 0)
                                                {
                                                    //insert into tblPurchase_Temp table
                                                    conn.Close();
                                                    conn.Open();
                                                    SqlCommand cmdd = new SqlCommand(
                                                        "INSERT INTO tblPurchase_Temp (PurchaseType,PurchaseDate,TradeCode,PurchaseInvNo,VendorId,Qty,UnitPrice,WSPrice,SaleMRP,RunStock,TotalCost,ManufactureDate,ExpiryDate,BatchNo,UserName,SELLER_ID, SELLER_NAME,INV_DATE) VALUES('" +
                                                        comboBoxPurchaseType.Text.Trim() + "','" + dateTimePickerPurchaseDate.Value.ToString("M/d/yyyy") + "','" +
                                                        textBoxTradeCode.Text + "','" + textBoxPurchaseInvoice.Text.Trim() + "','" + vendorID + "','" +
                                                        textBoxQty.Text.Trim() + "','" + textBoxUnitPrice.Text.Trim() + "','" + textBoxWsPrice.Text.Trim() + "','" +
                                                        textBoxSaleMrp.Text.Trim() + "','" + textBoxRunStock.Text.Trim() + "','" + textBoxTotalCost.Text.Trim() + "','" +
                                                        dateTimePicker1.Value.ToString("M/d/yyyy") + "','" + dateTimePickerExpiryDate.Value.ToString("M/d/yyyy") + "','" +
                                                        textBoxBatchNo.Text.Trim() + "','" + GlobalSettings.UserName + "', '"+comboBoxSallerName.SelectedValue+"', '" +
                                                        comboBoxSallerName.Text + "','" + dateTimePickerInvoiceDate.Value.ToString("M/d/yyyy") + "')", conn);
                                                    cmdd.ExecuteNonQuery();
                                                    conn.Close();

                                                    // Called User Defin Function
                                                    LoadPurchase_TempToGrid();

                                                    PurchaseGridSum();

                                                    txtClear();
                                                    textBoxTradeName.Focus();

                                                }
                                                else
                                                {
                                                    //conn.Close();
                                                    MessageBox.Show("You have already added this Item.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    textBoxInvoiceNo.Focus();
                                                }
                                            }                                                                                    
                                        }
                                        else
                                        {
                                            // Display a message box with Icon. 
                                            MessageBox.Show("Please Type Batch No.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            textBoxBatchNo.Focus();
                                        }
                                    }
                                    else
                                    {
                                        // Display a message box with Icon. 
                                        MessageBox.Show("Please Type Sale MRP/Price.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBoxSaleMrp.Focus();
                                    }
                                }
                                else
                                {
                                    // Display a message box with Icon. 
                                    MessageBox.Show("Please Type W/S Price.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBoxWsPrice.Focus();
                                }
                            }
                            else
                            {
                                // Display a message box with Icon. 
                                MessageBox.Show("Please Type Unit Price.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxUnitPrice.Focus();
                            }
                        }
                        else
                        {
                            // Display a message box with Icon. 
                            MessageBox.Show("Please Type Quantity.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxQty.Focus();
                        }
                    }
                    else
                    {
                        // Display a message box with Icon. 
                        MessageBox.Show("Please Type Purchase Invoice No.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPurchaseInvoice.Focus();
                    }
                }
                else
                {
                    // Display a message box with Icon. 
                    MessageBox.Show("Please Select Trade Name.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                    panelTrade.Visible = true;
                    LoadTradeNameToGrid();
                }
            }
            else
            {
                // Display a message box with Icon. 
                MessageBox.Show("Please Select Purchase Type..", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBoxQty.Text.Trim() == "")
            {
                textBoxQty.Text = "0";
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float WsPrice;
                WsPrice = float.Parse(textBoxWsPrice.Text.Trim().ToString());
                if (textBoxWsPrice.Text.Trim() == "")
                {
                    DialogResult r1 = MessageBox.Show("Please Enter W/S Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxWsPrice.Text = "0";
                }
                else if (WsPrice < 0)
                {
                    DialogResult r1 = MessageBox.Show("- Not Allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxWsPrice.Text = "0";
                }                
            }
            catch
            {
                DialogResult r1 = MessageBox.Show("Please Check W/S Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxWsPrice.Text = "0";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float WsPrice;
                WsPrice = float.Parse(textBoxSaleMrp.Text.Trim().ToString());
                if (textBoxSaleMrp.Text.Trim() == "")
                {
                    DialogResult r1 = MessageBox.Show("Please Enter Sale MRP/Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSaleMrp.Text = "0";
                }
                else if (WsPrice < 0)
                {
                    DialogResult r1 = MessageBox.Show("- Not Allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxSaleMrp.Text = "0";
                }
            }
            catch
            {
                DialogResult r1 = MessageBox.Show("Please Check Sale MRP/Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSaleMrp.Text = "0";
            }
        }

        private string purchaseID;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    purchaseID = dataGridView1.SelectedRows[0].Cells["ttid"].Value.ToString();
                    labelTradeName.Text = dataGridView1.SelectedRows[0].Cells["ttTradeName"].Value.ToString();
                    vendorID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ttVendorId"].Value.ToString());

                    comboBoxPurchaseType.Text = dataGridView1.SelectedRows[0].Cells["ttPurchaseType"].Value.ToString();
                    dateTimePickerPurchaseDate.Text = dataGridView1.SelectedRows[0].Cells["ttPurchaseDate"].Value.ToString();
                    textBoxTradeCode.Text = dataGridView1.SelectedRows[0].Cells["ttTradeCode"].Value.ToString();
                    textBoxTradeName.Text = dataGridView1.SelectedRows[0].Cells["ttTradeName"].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells["ttManufactureDate"].Value.ToString();
                    textBoxPurchaseInvoice.Text = dataGridView1.SelectedRows[0].Cells["ttPurchaseInvNo"].Value.ToString();
                    textBoxVendorName.Text = dataGridView1.SelectedRows[0].Cells["ttVendorName"].Value.ToString();
                    textBoxQty.Text = dataGridView1.SelectedRows[0].Cells["ttQty"].Value.ToString();
                    textBoxUnitPrice.Text = dataGridView1.SelectedRows[0].Cells["ttUnitPrice"].Value.ToString();
                    dateTimePickerExpiryDate.Text = dataGridView1.SelectedRows[0].Cells["ttExpiryDate"].Value.ToString();
                    textBoxWsPrice.Text = dataGridView1.SelectedRows[0].Cells["ttWSPrice"].Value.ToString();
                    textBoxSaleMrp.Text = dataGridView1.SelectedRows[0].Cells["ttSaleMRP"].Value.ToString();
                    textBoxRunStock.Text = dataGridView1.SelectedRows[0].Cells["ttRunStock"].Value.ToString();
                    textBoxBatchNo.Text = dataGridView1.SelectedRows[0].Cells["ttBatchNo"].Value.ToString();
                    comboBoxSallerName.Text = dataGridView1.SelectedRows[0].Cells["ColumnSELLER_NAME"].Value.ToString();
                    dateTimePickerPurchaseDate.Text = dataGridView1.SelectedRows[0].Cells["ttPurchaseDate"].Value.ToString();
                    dateTimePickerInvoiceDate.Text = dataGridView1.SelectedRows[0].Cells["ColumnINV_DATE"].Value.ToString();
                    

                    //panelTrade.Visible = false;
                    //textBox4.Focus();
                    button1.Visible = false;
                    button2.Visible = true;
                    button3.Visible = false;
                    button4.Visible = true;
                    button5.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM tblPurchase_Temp WHERE id='" + purchaseID + "'", conn);
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                //insert into tblPurchase_Temp table
                conn.Close();
                conn.Open();                                                                                                                                                                                                                                                                                                                                                                                                                            //W/S
                SqlCommand cmdd = new SqlCommand("DELETE FROM tblPurchase_Temp  WHERE id='" + purchaseID + "'", conn);
                cmdd.ExecuteNonQuery();
                conn.Close();              

                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Data Delete Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Called User Defin Function
                LoadPurchase_TempToGrid();

                PurchaseGridSum();

                txtClear();
                textBoxTradeName.Focus();
                labelTradeName.Text = ".";

                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = dataGridView1.Rows.Count > 0;
                button4.Visible = false;
                button5.Visible = false;

            }
            else
            {
                //conn.Close();
                DialogResult r1 = MessageBox.Show("You have already added this Item.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxInvoiceNo.Focus();
            }               
        }

        //Varible
        private float Qty1, wsPrice1, SaleMRP1;
        private string vPurchaseType, vvTradeCode, vTradeName;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    var grid1 = dataGridView1.Rows[i];

                    // p = Purchase
                    var pQty = float.Parse(grid1.Cells["ttQty"].Value.ToString());
                    var pWsPrice = float.Parse(grid1.Cells["ttWSPrice"].Value.ToString());
                    var pSaleMrp = float.Parse(grid1.Cells["ttSaleMRP"].Value.ToString());
                    var pUnitPrice = float.Parse(grid1.Cells["ttUnitPrice"].Value.ToString());
                    var pTradeCode = grid1.Cells["ttTradeCode"].Value.ToString();

                    conn.Close();
                    conn.Open();
                    var cmd=new SqlCommand("SELECT * FROM tblStock WHERE TradeCode='" + pTradeCode + "'", conn);
                    var dr = cmd.ExecuteReader();
                    
                    if (dr.Read())
                    {
                        // o = Old, t = Total
                        var oQty = float.Parse(dr["Qty"].ToString());
                        var oUnitPrice = float.Parse(dr["UnitPrice"].ToString());

                        var oTotalPrice = oQty * oUnitPrice;
                        var pTotalPrice = pQty * pUnitPrice;

                        var tQty = pQty + oQty;
                        var tUnitPrice = oTotalPrice + pTotalPrice;

                        var rUnitPrice = tUnitPrice / tQty;

                        conn.Close();
                        conn.Open();
                        var cmd1 = new SqlCommand("UPDATE tblStock SET Qty='" + tQty + "', wsPrice='" + pWsPrice + "', SaleMRP='" + pSaleMrp + "' , UnitPrice='" + rUnitPrice + "' WHERE  TradeCode='" + pTradeCode + "'", conn);
                        cmd1.ExecuteNonQuery();
                        //conn.Close();
                    }

                    //insert tblPurchase
                    conn.Close();
                    conn.Open();
                    var query2 =
                        "INSERT INTO tblPurchase (InvNo,PurchaseType,PurchaseDate,TradeCode,PurchaseInvNo,VendorId,Qty,"+
                        "UnitPrice,WSPrice,SaleMRP,RunStock,TotalCost,ManufactureDate,ExpiryDate,BatchNo,UserName, SELLER_ID,INV_DATE) VALUES('" +
                        textBoxInvoiceNo.Text.Trim() + "', '" + grid1.Cells["ttPurchaseType"].Value + "', '" +
                        Convert.ToDateTime(grid1.Cells["ttPurchaseDate"].Value).ToString("M/d/yyyy") + "', '" + grid1.Cells["ttTradeCode"].Value +
                        "', '" + grid1.Cells["ttPurchaseInvNo"].Value + "', '" + grid1.Cells["ttVendorId"].Value + "', '" +
                        grid1.Cells["ttQty"].Value + "', '" + grid1.Cells["ttUnitPrice"].Value + "', '" + grid1.Cells["ttWSPrice"].Value +
                        "', '" + grid1.Cells["ttSaleMRP"].Value + "', '" + grid1.Cells["ttRunStock"].Value + "', '" +
                        grid1.Cells["ttTotalCost"].Value + "', '" + Convert.ToDateTime(grid1.Cells["ttManufactureDate"].Value).ToString("M/d/yyyy") +
                        "', '" + Convert.ToDateTime(grid1.Cells["ttExpiryDate"].Value).ToString("M/d/yyyy") +
                        "', '" + grid1.Cells["ttBatchNo"].Value + "', '" + grid1.Cells["ttUserName"].Value + "', '" + grid1.Cells["ColumnSELLER_ID"].Value +
                        "', '" + Convert.ToDateTime(grid1.Cells["ColumnINV_DATE"].Value).ToString("M/d/yyyy") + "')";
                    var cmd2 = new SqlCommand(query2, conn);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                }

                //delete 
                conn.Close();
                conn.Open();
                SqlCommand cmd3 = new SqlCommand("DELETE FROM tblPurchase_Temp WHERE UserName='"+GlobalSettings.UserName+"'", conn);
                cmd3.ExecuteNonQuery();

                LoadPurchase_TempToGrid();

                MessageBox.Show("Data Posting Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells["sl"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["ttsl"].Value = (e.RowIndex + 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            purchaseID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            labelTradeName.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //panelTrade.Visible = false;
            //textBox4.Focus();
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = dataGridView1.Rows.Count > 0;
            button4.Visible = false;
            button5.Visible = false;
            txtClear();
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBoxPurchaseType.Text != "")
            {
                if (textBoxTradeCode.Text.Trim() != "")
                {
                    if (textBoxPurchaseInvoice.Text.Trim() != "")
                    {
                        float Qty = float.Parse(textBoxQty.Text.ToString());
                        if (Qty >= 1)
                        {
                            float UnitPrice = float.Parse(textBoxUnitPrice.Text.ToString());
                            if ((UnitPrice >= 0.1 && comboBoxPurchaseType.Text == "General") || comboBoxPurchaseType.Text != "General")
                            {

                                float WSPrice = float.Parse(textBoxWsPrice.Text.ToString());
                                if (WSPrice >= 0.1)
                                {
                                    float SaleMRP = float.Parse(textBoxSaleMrp.Text.ToString());
                                    if (SaleMRP >= 0.1)
                                    {
                                        if (textBoxBatchNo.Text.Trim() != "")
                                        {
                                            if (dateTimePicker1.Value.ToShortDateString() == dateTimePickerExpiryDate.Value.ToShortDateString())
                                            {
                                                // Display a message box with Icon. 
                                                MessageBox.Show("Please Check Manufacture & Expiry Date.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                dateTimePicker1.Focus();
                                            }
                                            else
                                            {
                                                conn.Close();
                                                conn.Open();
                                                SqlCommand cmdd = new SqlCommand(
                                                    "UPDATE tblPurchase_Temp SET PurchaseType='" +
                                                    comboBoxPurchaseType.Text.Trim() + "', PurchaseDate='" +
                                                    dateTimePickerPurchaseDate.Value.ToShortDateString() + "', VendorId='" +
                                                    vendorID + "',Qty='" + textBoxQty.Text.Trim() + "',UnitPrice='" +
                                                    textBoxUnitPrice.Text.Trim() + "',WSPrice='" +
                                                    textBoxWsPrice.Text.Trim() + "',SaleMRP='" + textBoxSaleMrp.Text.Trim() +
                                                    "',RunStock='" + textBoxRunStock.Text.Trim() + "',TotalCost='" +
                                                    textBoxTotalCost.Text.Trim() + "',ManufactureDate='" +
                                                    dateTimePicker1.Value.ToShortDateString() +
                                                    "',ExpiryDate='" + dateTimePickerExpiryDate.Value.ToShortDateString() +
                                                    "',BatchNo='" +
                                                    textBoxBatchNo.Text.Trim() + "',UserName='" + GlobalSettings.UserName +
                                                    "', SELLER_ID='"+comboBoxSallerName.SelectedValue+"', SELLER_NAME='" +
                                                    comboBoxSallerName.Text + "', INV_DATE='" + dateTimePickerExpiryDate.Value.ToString("M/d/yyyy") + 
                                                    "' WHERE id='" + purchaseID + "' ", conn);
                                                cmdd.ExecuteNonQuery();
                                                conn.Close();

                                                
                                                // Called User Defin Function
                                                LoadPurchase_TempToGrid();

                                                PurchaseGridSum();

                                                txtClear();
                                                textBoxTradeName.Focus();
                                                labelTradeName.Text = ".";

                                                button1.Visible = true;
                                                button2.Visible = false;
                                                button3.Visible = dataGridView1.Rows.Count > 0;
                                                button4.Visible = false;
                                                button5.Visible = false;

                                            }
                                        }
                                        else
                                        {
                                            // Display a message box with Icon. 
                                            DialogResult r1 = MessageBox.Show("Please Type Batch No.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            textBoxBatchNo.Focus();
                                        }
                                    }
                                    else
                                    {
                                        // Display a message box with Icon. 
                                        DialogResult r1 = MessageBox.Show("Please Type Sale MRP/Price.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBoxSaleMrp.Focus();
                                    }
                                }
                                else
                                {
                                    // Display a message box with Icon. 
                                    DialogResult r1 = MessageBox.Show("Please Type W/S Price.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBoxWsPrice.Focus();
                                }
                            }
                            else
                            {
                                // Display a message box with Icon. 
                                DialogResult r1 = MessageBox.Show("Please Type Unit Price.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxUnitPrice.Focus();
                            }
                        }
                        else
                        {
                            // Display a message box with Icon. 
                            DialogResult r1 = MessageBox.Show("Please Type Quantity.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxQty.Focus();
                        }
                    }
                    else
                    {
                        // Display a message box with Icon. 
                        DialogResult r1 = MessageBox.Show("Please Type Purchase Invoice No.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxPurchaseInvoice.Focus();
                    }
                }
                else
                {
                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Please Select Trade Name.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    panelTrade.Visible = true;
                    LoadTradeNameToGrid();
                }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Please Select Purchase Type..", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    var tradeCode = dataGridView2.SelectedRows[0].Cells["TradeCodeP"].Value.ToString();
                    textBoxTradeCode.Text = tradeCode.ToString();
                    textBoxTradeName.Text = dataGridView2.SelectedRows[0].Cells["TradeNameP"].Value.ToString();
                    textBoxVendorName.Text = dataGridView2.SelectedRows[0].Cells["VendorP"].Value.ToString();
                    tradeCode = dataGridView2.SelectedRows[0].Cells["TradeCodeP"].Value.ToString();
                    vendorID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["ssVendorId"].Value.ToString());

                    panelTrade.Visible = false;
                    textBoxPurchaseInvoice.Focus();

                    conn.Close();
                    conn.Open();
                    var cmd = new SqlCommand("SELECT * FROM tblStock WHERE TradeCode='" + tradeCode + "'", conn);
                    
                    var odr = cmd.ExecuteReader();
                    if (odr.Read())
                    {
                        textBoxRunStock.Text = odr["Qty"].ToString();
                        textBoxWsPrice.Text = odr["wsPrice"].ToString();
                        textBoxSaleMrp.Text = odr["SaleMRP"].ToString();
                        textBoxWs.Text = odr["wsPrice"].ToString();
                        textBoxMrp.Text =odr["SaleMRP"].ToString() ;
                        textBoxUnit.Text = odr["UnitPrice"].ToString();
                    }
                    else
                    {
                        textBoxRunStock.Text = "0";
                        textBoxWs.Text = "0";
                        textBoxMrp.Text = "0";
                        textBoxUnit.Text = "0";
                    }


                    odr.Close();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxTotalCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float totalCost = float.Parse(textBoxTotalCost.Text.Trim().ToString());
                if (textBoxTotalCost.Text.Trim() == "")
                {
                    DialogResult r1 = MessageBox.Show("Please Enter Unit Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxTotalCost.Text = "0";
                }
                else if (totalCost < 0)
                {
                    DialogResult r1 = MessageBox.Show("- Not Allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxTotalCost.Text = "0";
                }
                else if (textBoxQty.Text.Trim() == "")
                {
                    DialogResult r1 = MessageBox.Show("Please Enter Qty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    textBoxUnitPrice.Text = (float.Parse(textBoxTotalCost.Text.Trim()) / float.Parse(textBoxQty.Text.Trim())).ToString("F");

                }
            }
            catch
            {
                DialogResult r1 = MessageBox.Show("Please Type Correct Value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxUnitPrice.Text = "0";
            }
        }

        private void comboBoxPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPurchaseType.Text==@"Sample")
            {
                textBoxTotalCost.Text = "0";
                textBoxTotalCost.Enabled = GlobalSettings.InputSamplePrice;
            }
            else
            {
                textBoxTotalCost.Enabled = true;
            }
            
        }

        private void labelTradeClose_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = false;
        }
        
    }
}
