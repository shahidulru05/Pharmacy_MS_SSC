using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmSaleReturn : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private AutoGenerateInvoice autoGenerateInvoice = new AutoGenerateInvoice();

        private int gridIndex = 0;
        private string salID;

        public frmSaleReturn()
        {
            InitializeComponent();

            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            textBoxSaleInvoice2.Text = DateTime.Today.Year.ToString();

            GenerateInvoice();
        }

        private void ShowSaleBySaleInv()
        {
            dataGridView1.Rows.Clear();

            var saleInvoice = textBoxSaleInvoice1.Text.Trim() + textBoxSaleInvoice2.Text.Trim();

            var query = "SELECT SS.id, SS.TradeCode, SS.TradeName, SS.Qty, SUM(SS.RETURN_QTY) AS RETURN_QTY, " +
                        "(ISNULL(SS.Qty,0)-SUM(SS.RETURN_QTY)) AS AFTER_RETURN_QTY, SS.UnitPrice, SS.SubTotal, " +
                        "SS.Discount, SS.Total FROM " +
                        "(SELECT S.*, tblTradeName.TradeName, ISNULL(R.ReturnQty,0) RETURN_QTY " +
                        "FROM tblSaleDetails AS S " +
                        "LEFT JOIN tblTradeName ON S.TradeCode=tblTradeName.TradeCode " +
                        "LEFT JOIN tblSaleReturnDetails AS R ON S.id=R.SaleID " +
                        "WHERE  S.InvNo = '" + saleInvoice + "') AS SS " +
                        "GROUP BY SS.id, SS.TradeCode, SS.TradeName, SS.Qty, SS.UnitPrice, SS.SubTotal, " +
                        "SS.Discount, SS.Total ORDER BY SS.id ASC";
            var dt = Db.GetDataTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["saleID"].Value = dr["id"].ToString();
                dataGridView1.Rows[i].Cells["saleTradeCode"].Value = dr["TradeCode"].ToString();
                dataGridView1.Rows[i].Cells["saleTradeName"].Value = dr["TradeName"].ToString();
                dataGridView1.Rows[i].Cells["saleQty"].Value = dr["Qty"].ToString();
                dataGridView1.Rows[i].Cells["returnQty"].Value = dr["RETURN_QTY"].ToString();
                dataGridView1.Rows[i].Cells["afterReturn"].Value = dr["AFTER_RETURN_QTY"].ToString();
                dataGridView1.Rows[i].Cells["saleUnitPrice"].Value = dr["UnitPrice"].ToString();
                dataGridView1.Rows[i].Cells["saleSubTotal"].Value = dr["SubTotal"].ToString();
                dataGridView1.Rows[i].Cells["saleDiscount"].Value = dr["Discount"].ToString();
                dataGridView1.Rows[i].Cells["saleTotal"].Value = dr["Total"].ToString();
            }

            panelTrade.Visible = dataGridView1.RowCount > 0;
        }

        private void GenerateInvoice()
        {
            try
            {
                var year = Settings.Default.CURRENT_PERIOD;
                string defaultInvoice = "SLR-"+year+"1";
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT InvNo FROM tblSaleReturnMaster WHERE id = (SELECT MAX(id) AS ID FROM tblSaleReturnMaster)", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() && !dr.IsDBNull(0))
                {
                    var db_invoice = dr["InvNo"].ToString();
                    var db_inv_year = db_invoice.Substring(4, 4);
                    label15.Text = Convert.ToInt32(db_inv_year) < Convert.ToInt32(year)
                        ? defaultInvoice
                        : new AutoGenerateInvoice().Invoice(db_invoice, "SLR-" + year, 1);
                }
                else
                {
                    label15.Text = defaultInvoice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void InsertSaleReturnMaster()
        {
            conn.Close();
            conn.Open();
            string query = "INSERT INTO tblSaleReturnMaster VALUES ('" + label15.Text + "','" + 
                           textBoxSaleInvoice1.Text+textBoxSaleInvoice2.Text.Trim() + "','" + textBox7.Text.Trim() + "','" +
                           textBox16.Text.Trim() + "','" + label17.Text + "','" + Convert.ToDouble(textBox9.Text) + "','" +
                           Convert.ToDouble(textBox11.Text) + "','" + Convert.ToDouble(textBox12.Text.Trim()) + "','" + 
                           Convert.ToDouble(textBox13.Text) + "','" + Convert.ToDouble(textBox14.Text) + "','" + 
                           lblDate.Text + "','" + lblTime.Text + "','" + Convert.ToInt32(label9.Text) + "','" + GlobalSettings.UserName + "' )";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        private void StockUpdate(string tradeCode, double quantity)
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT *FROM tblStock WHERE TradeCode='" + tradeCode + "'", conn);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                var qty = Convert.ToDouble(dr["Qty"].ToString());
                var result = qty + quantity;

                var cmd1 = new SqlCommand("UPDATE tblStock SET Qty='" + result + "' WHERE TradeCode='" + tradeCode + "'", conn);
                dr.Close();
                cmd1.ExecuteNonQuery();
            }
        }

        private void InsertSaleReturnDetails()
        {
            try
            {
                for (var ss = 0; ss < dgvfrmSale.Rows.Count; ss++)
                {
                    conn.Close();
                    conn.Open();
                    var query = "INSERT INTO tblSaleReturnDetails VALUES " + "('" +
                                label15.Text + "','" +
                                dgvfrmSale.Rows[ss].Cells["tempSaleID"].Value + "','" +
                                Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempUnitPrice"].Value) + "','" +
                                Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempQty"].Value) + "','" +
                                Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempSubTotal"].Value) + "','" +
                                Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempTotal"].Value) + "', +" +
                                " '" + GlobalSettings.UserName + "') ";

                    var cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    StockUpdate(dgvfrmSale.Rows[ss].Cells["tempTradeCode"].Value.ToString(), Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempQty"].Value));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void PaymentCalculate()
        {
            double grandTotal = Convert.ToDouble(textBox11.Text) > 0 ? Convert.ToDouble(textBox11.Text) : 0.00;
            double payment = Convert.ToDouble(textBox12.Text) > 0 ? Convert.ToDouble(textBox12.Text) : 0.00;
            double calculate = payment - grandTotal;

            if (calculate < 0)
            {
                textBox13.Text = (calculate * (-1)).ToString("N");
                textBox14.Text = "0.00";
            }
            else if (calculate > 0)
            {
                textBox13.Text = "0.00";
                textBox14.Text = calculate.ToString("N");
            }
            else
            {
                textBox13.Text = "0.00";
                textBox14.Text = "0.00";
            }

        }

        private void DiscountCalculate()
        {
            double subTotal = Convert.ToDouble(textBox9.Text) > 0 ? Convert.ToDouble(textBox9.Text) : 0.00;
            double discount = Convert.ToDouble(textBox10.Text) > 0 ? Convert.ToDouble(textBox10.Text) : 0.00;

            textBox11.Text = (subTotal - discount).ToString("N");
        }
        
        private void CalculateGridValue()
        {
            if (dgvfrmSale.Rows.Count > 0)
            {
                double grandTotal = 0;

                for (int ss = 0; ss < dgvfrmSale.Rows.Count; ss++)
                {
                    grandTotal += Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempTotal"].Value.ToString());
                }

                textBox9.Text = grandTotal.ToString("N");
            }
            else
            {
                textBox9.Text = "0.00";
            }
        }

        private void ClearSaleTextBox()
        {
            textBoxTradeCode.Clear();
            textBox2.Clear();
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox8.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            labelQty.Text = "";
        }
        
        private void SingleCalculate()
        {
            var unitPrice = Convert.ToDouble(textBox3.Text.Trim()) > 0 ? Convert.ToDouble(textBox3.Text.Trim()) : 0;
            var returnQty = Convert.ToDouble(textBox4.Text.Trim()) > 0 ? Convert.ToDouble(textBox4.Text.Trim()) : 0;
            var discount = Convert.ToDouble(textBox5.Text.Trim()) > 0 ? Convert.ToDouble(textBox5.Text.Trim()) : 0;

            var subTotal = (unitPrice * returnQty);
            var per = ((subTotal * discount) / 100);
            var grandTotal = subTotal - per;

            textBox8.Text = subTotal.ToString();
            textBox6.Text = grandTotal.ToString();

        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox4.Text) > 0)
                {
                    if (Convert.ToDouble(textBox4.Text.Trim()) <= Convert.ToDouble(labelQty.Text))
                    {
                        SingleCalculate();
                    }
                    else
                    {
                        textBox4.Text = labelQty.Text;
                        textBox4.SelectAll();
                    }
                }
                else
                {
                    textBox8.Text = "0";
                }
            }
            catch
            {
                textBox6.Text = "0";
                textBox4.Text = "0";
                textBox4.SelectAll();
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 1).ToString();
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                salID = dataGridView1.Rows[e.RowIndex].Cells["saleID"].Value.ToString();
                textBoxTradeCode.Text = dataGridView1.Rows[e.RowIndex].Cells["saleTradeCode"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["saleTradeName"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["saleUnitPrice"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["saleDiscount"].Value.ToString();
                labelQty.Text = dataGridView1.Rows[e.RowIndex].Cells["afterReturn"].Value.ToString();

                panelTrade.Visible = false;

                btnAdd.Enabled = true;
                textBox4.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxTradeCode.Text != "")
                {
                    if (Convert.ToDouble(textBox4.Text) > 0)
                    {
                        int ss = dgvfrmSale.Rows.Add();
                        dgvfrmSale.Rows[ss].Cells["tempSaleID"].Value = salID;
                        dgvfrmSale.Rows[ss].Cells["tempTradeCode"].Value = textBoxTradeCode.Text;
                        dgvfrmSale.Rows[ss].Cells["tempTradeName"].Value = textBox2.Text;
                        dgvfrmSale.Rows[ss].Cells["tempUnitPrice"].Value = textBox3.Text;
                        dgvfrmSale.Rows[ss].Cells["tempQty"].Value = textBox4.Text;
                        dgvfrmSale.Rows[ss].Cells["tempSubTotal"].Value = textBox8.Text;
                        dgvfrmSale.Rows[ss].Cells["tempDiscount"].Value = textBox5.Text;
                        dgvfrmSale.Rows[ss].Cells["tempTotal"].Value = textBox6.Text;

                        label9.Text = dgvfrmSale.RowCount.ToString();

                        CalculateGridValue();
                        DiscountCalculate();
                        PaymentCalculate();

                        ClearSaleTextBox();

                    }
                    else
                    {
                        MessageBox.Show("Please enter quantity", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select Trade Name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvfrmSale_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvfrmSale.Rows[e.RowIndex].Cells["tempSL"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvfrmSale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvfrmSale.Rows.Count > 0)
                {
                    btnCancel.Visible = true;
                    btnDelete.Visible = true;
                    btnAdd.Visible = false;

                    gridIndex = e.RowIndex;
                    label17.Text = dgvfrmSale.Rows[e.RowIndex].Cells["tempTradeName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvfrmSale.Rows.RemoveAt(gridIndex);

                label9.Text = dgvfrmSale.RowCount.ToString();

                CalculateGridValue();
                DiscountCalculate();
                PaymentCalculate();

                gridIndex = 0;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                btnAdd.Visible = true;
                label17.Text = "-";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gridIndex = 0;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;
            label17.Text = "-";
        }
        
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox12.Text) >= 0)
                {
                    PaymentCalculate();
                }
            }
            catch
            {
                textBox12.Text = "0.00";
                textBox12.SelectAll();
            }
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            textBox10.SelectAll();
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            textBox12.SelectAll();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnAdd.Visible)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.PerformClick();
                    textBox2.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvfrmSale.RowCount > 0)
            {
                GenerateInvoice();

                InsertSaleReturnDetails();
                InsertSaleReturnMaster();

                dgvfrmSale.Rows.Clear();

                textBox9.Text = "0.00";
                textBox10.Text = "0.00";
                textBox11.Text = "0.00";
                textBox12.Text = "0.00";
                textBox13.Text = "0.00";
                textBox14.Text = "0.00";

                label9.Text = "0";

                GenerateInvoice();
            }
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelPin_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void textBoxSaleInvoice2_TextChanged(object sender, EventArgs e)
        {
            ShowSaleBySaleInv();
        }

        private void textBoxSaleInvoice2_Click(object sender, EventArgs e)
        {
            ShowSaleBySaleInv();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox10.Text) >= 0)
                {
                    if (Convert.ToDouble(textBox10.Text.Trim()) <= Convert.ToDouble(textBox9.Text))
                    {
                        DiscountCalculate();
                        PaymentCalculate();
                    }
                    else
                    {
                        textBox10.Text = "0.00";
                        DiscountCalculate();
                        PaymentCalculate();
                        textBox10.SelectAll();
                    }
                }
                else
                {
                    textBox10.Text = "0.00";
                    DiscountCalculate();
                    PaymentCalculate();
                }
            }
            catch
            {
                textBox10.Text = "0.00";
                DiscountCalculate();
                PaymentCalculate();
                textBox10.SelectAll();
            }
        }

        private void labelTradeClose_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = false;
        }

        
    }
}
