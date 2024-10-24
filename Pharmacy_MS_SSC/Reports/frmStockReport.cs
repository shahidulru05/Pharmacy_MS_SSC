using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Properties;

namespace Pharmacy_MS_SSC.Reports
{
    public partial class frmStockReport : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmStockReport()
        {
            InitializeComponent();
        }
        
        private void label22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label33_Click(object sender, EventArgs e)
        {

        }
        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //LoadStockDetails();
        }

        private void LoadStockDetails(bool isCustomSearch=false)
        {
            try
            {
                panelSearch.Enabled = false;
                var query = "SELECT tblTradeName.TradeCode, tblTradeName.TradeName, tblTradeName.RACK_NAME, tblCategory.CategoryName, " +
                            "tblGenericName.GenericName, tblVendor.VendorName, tblStock.Qty, tblStock.UnitPrice, " +
                            "tblStock.wsPrice, tblStock.SaleMRP FROM tblTradeName INNER JOIN " +
                            "tblCategory ON tblTradeName.CategoryID = tblCategory.id INNER JOIN " +
                            "tblGenericName ON tblTradeName.GenericID = tblGenericName.id INNER JOIN " +
                            "tblVendor ON tblTradeName.VendorID = tblVendor.id INNER JOIN " +
                            "tblStock ON tblTradeName.TradeCode = tblStock.TradeCode ";
                var subQuery = "";

                labelTotalCost.Text = "0";
                labelTotalMRP.Text = "0";
                labelTotalWS.Text = "0";
                labelProfitMRP.Text = "0";
                labelProfitWS.Text = "0";
                progressBarLoading.Maximum = 0;
                progressBarLoading.Value = 0;
                listViewStockDetails.Items.Clear();
                labelTotalItem.Text = "0";
                var sl = 1;
                
                if (radioButtonAll.Checked)
                {
                    if (textBoxSearch.Text=="")
                    {
                        subQuery = "";
                        if (isCustomSearch)
                        {
                            subQuery += " WHERE tblTradeName.VendorID ='" + comboBoxCompany.SelectedValue +
                                        "' AND tblTradeName.CategoryID='" + comboBoxCategory.SelectedValue + "'";
                        }
                    }
                    else
                    {
                        subQuery = "WHERE (TradeName LIKE('%" + textBoxSearch.Text.Trim() + "%') OR tblTradeName.TradeCode ='" +
                                   textBoxSearch.Text.Trim() + "' OR CategoryName LIKE('%" + textBoxSearch.Text.Trim() + "%') OR GenericName LIKE('%" +
                                   textBoxSearch.Text.Trim() + "%') OR VendorName LIKE('%" + textBoxSearch.Text.Trim() + "%'))";
                    }
                }
                else if (radioButtonWithoutZero.Checked)
                {
                    if (textBoxSearch.Text=="")
                    {
                        subQuery = "WHERE tblStock.Qty > 0";
                        if (isCustomSearch)
                        {
                            subQuery += " AND tblTradeName.VendorID ='" + comboBoxCompany.SelectedValue +
                                        "' AND tblTradeName.CategoryID='" + comboBoxCategory.SelectedValue + "'";
                        }
                    }
                    else
                    {
                        subQuery = "WHERE tblStock.Qty > 0 AND (TradeName LIKE('%" + textBoxSearch.Text.Trim() + "%') OR tblTradeName.TradeCode ='" +
                                   textBoxSearch.Text.Trim() + "' OR CategoryName LIKE('%" + textBoxSearch.Text.Trim() + "%') OR GenericName LIKE('%" +
                                   textBoxSearch.Text.Trim() + "%') OR VendorName LIKE('%" + textBoxSearch.Text.Trim() + "%'))";
                    }
                }
                else if (radioButtonWithZero.Checked)
                {
                    if (textBoxSearch.Text == "")
                    {
                        subQuery = "WHERE tblStock.Qty = 0";
                        if (isCustomSearch)
                        {
                            subQuery += " AND tblTradeName.VendorID ='" + comboBoxCompany.SelectedValue +
                                        "' AND tblTradeName.CategoryID='" + comboBoxCategory.SelectedValue + "'";
                        }
                    }
                    else
                    {
                        subQuery = "WHERE tblStock.Qty = 0 AND (TradeName LIKE('%" + textBoxSearch.Text.Trim() + "%') OR tblTradeName.TradeCode ='" +
                                   textBoxSearch.Text.Trim() + "' OR CategoryName LIKE('%" + textBoxSearch.Text.Trim() + "%') OR GenericName LIKE('%" +
                                   textBoxSearch.Text.Trim() + "%') OR VendorName LIKE('%" + textBoxSearch.Text.Trim() + "%'))";
                    }
                }

                var dt = Db.GetDataTable(query + subQuery);
                var totalRow = dt.Rows.Count;
                if (totalRow > 0)
                {
                    progressBarLoading.Maximum = totalRow;
                    foreach (DataRow row in dt.Rows)
                    {
                        var lv = new ListViewItem(sl.ToString());           //0
                        lv.SubItems.Add(row["TradeCode"].ToString());       //1
                        lv.SubItems.Add(row["TradeName"].ToString());       //2
                        lv.SubItems.Add(row["CategoryName"].ToString());    //3
                        lv.SubItems.Add(row["GenericName"].ToString());     //4
                        lv.SubItems.Add(row["VendorName"].ToString());      //5
                        lv.SubItems.Add(Convert.ToDouble(row["Qty"].ToString()).ToString("N"));             //6
                        lv.SubItems.Add(Convert.ToDouble(row["UnitPrice"].ToString()).ToString("N"));       //7
                        lv.SubItems.Add(""); //TotalCost                    //8
                        lv.SubItems.Add(Convert.ToDouble(row["wsPrice"].ToString()).ToString("N"));         //9
                        lv.SubItems.Add(""); //TotalWsPrice                 //10
                        lv.SubItems.Add(""); //ProfitWsPrice                //11
                        lv.SubItems.Add(Convert.ToDouble(row["SaleMRP"].ToString()).ToString("N"));         //12
                        lv.SubItems.Add(""); // TotalSaleMRP                //13
                        lv.SubItems.Add(""); //ProfitSaleMRP                //14
                        lv.SubItems.Add(row["RACK_NAME"].ToString());

                        listViewStockDetails.Items.Add(lv);
                        listViewStockDetails.EnsureVisible(sl - 1);
                        labelTotalItem.Text = sl.ToString();
                        progressBarLoading.Value = sl;
                        sl++;
                        Application.DoEvents();
                    }
                }

                CalculateTradeValue();
                panelSearch.Enabled = true;

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelSearch.Enabled = true;
            }
        }
        
        private void CalculateTradeValue()
        {
            progressBarLoading.Maximum = listViewStockDetails.Items.Count;

            double TotalCost = 0;
            double TotalMRP = 0;
            double TotalWS = 0;
            double ProfitMRP = 0;
            double ProfitWS = 0;
            
            foreach (ListViewItem item in listViewStockDetails.Items)
            {
                listViewStockDetails.EnsureVisible(item.Index);
                
                // Total Cost = qty * UnitPrice
                item.SubItems[8].Text = (Convert.ToDouble(item.SubItems[6].Text) * Convert.ToDouble(item.SubItems[7].Text)).ToString("N");
                
                // Total WS Price = qty * wsPrice
                item.SubItems[10].Text = (Convert.ToDouble(item.SubItems[6].Text) * Convert.ToDouble(item.SubItems[9].Text)).ToString("N");

                // ProfitWSPrice =TotalWSPrice-TotalCost
                item.SubItems[11].Text = (Convert.ToDouble(item.SubItems[10].Text) - Convert.ToDouble(item.SubItems[8].Text)).ToString("N");

                // TotalMRP = Qty * SaleMRP
                item.SubItems[13].Text = (Convert.ToDouble(item.SubItems[6].Text) * Convert.ToDouble(item.SubItems[12].Text)).ToString("N");

                // TotalProfitMRP = TotalMRP - TotalCost
                item.SubItems[14].Text = (Convert.ToDouble(item.SubItems[13].Text) - Convert.ToDouble(item.SubItems[8].Text)).ToString("N");

                TotalCost += Convert.ToDouble(item.SubItems[8].Text);
                TotalMRP += Convert.ToDouble(item.SubItems[13].Text);
                TotalWS += Convert.ToDouble(item.SubItems[10].Text);
                ProfitMRP += Convert.ToDouble(item.SubItems[14].Text);
                ProfitWS += Convert.ToDouble(item.SubItems[11].Text);

                labelTotalCost.Text = TotalCost.ToString("N");
                labelTotalMRP.Text = TotalMRP.ToString("N");
                labelTotalWS.Text = TotalWS.ToString("N");
                labelProfitMRP.Text = ProfitMRP.ToString("N");
                labelProfitWS.Text = ProfitWS.ToString("N");

                progressBarLoading.Value = item.Index + 1;

                //panelCalculate.Refresh();
                
                //listViewStockDetails.Refresh();
                Application.DoEvents();
            }


            labelTotalCost.Text = TotalCost.ToString("N");
            labelTotalMRP.Text = TotalMRP.ToString("N");
            labelTotalWS.Text = TotalWS.ToString("N");
            labelProfitMRP.Text = ProfitMRP.ToString("N");
            labelProfitWS.Text = ProfitWS.ToString("N");
        }
        
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            radioButtonAll.Checked = true;
            LoadStockDetails();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            foreach (var textBox in panelStockDetails.Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }
            panelStockDetails.Visible = false;
        }

        private void pictureBoxCopyPurchaseInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLastPurchaseInvoicec.Text)) return;
            Clipboard.SetText(textBoxLastPurchaseInvoicec.Text);
            pictureBoxCopyPurchaseInvoice.Image = Resources.Checkmark;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBoxCopyPurchaseInvoice.Image = Resources.Copy;
            timer1.Stop();
        }
        
        private void radioButtonAll_Click(object sender, EventArgs e)
        {
            LoadStockDetails();
        }

        private void radioButtonWithoutZero_Click(object sender, EventArgs e)
        {
            LoadStockDetails();
        }

        private void radioButtonWithZero_Click(object sender, EventArgs e)
        {
            LoadStockDetails();
        }

        private void listViewStockDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                panelStockDetails.Visible = true;
                var tradeCode = listViewStockDetails.SelectedItems[0].SubItems[1].Text;
                textBoxPRunningStockQty.Text = Convert.ToDouble(listViewStockDetails.SelectedItems[0].SubItems[6].Text).ToString("N");

                textBoxPTradeCode.Text = tradeCode;
                textBoxPTradeName.Text = listViewStockDetails.SelectedItems[0].SubItems[2].Text;

                textBoxRackNo.Text = listViewStockDetails.SelectedItems[0].SubItems[columnHeaderRackNumber.Index].Text;

                var query = "SELECT MAX(InvNo) AS InvNo, SUM(Qty) AS Qty FROM tblPurchase WHERE TradeCode='" + tradeCode + "' GROUP BY TradeCode";
                var dr = Db.GetDataReader(query);
                if (dr.Read())
                {
                    textBoxPTotalPurchaseQty.Text = dr["Qty"] != DBNull.Value ? Convert.ToDouble(dr["Qty"]).ToString("N"):"0.00";
                    textBoxLastPurchaseInvoicec.Text = dr["InvNo"] != DBNull.Value ? dr["InvNo"].ToString() : "";
                }
                else
                {
                    textBoxPTotalPurchaseQty.Text = "0.00";
                    textBoxLastPurchaseInvoicec.Text = "";
                }

                var querySale = "SELECT SUM(Qty) AS Qty FROM tblSaleDetails WHERE TradeCode='" + tradeCode + "' ";
                var drSale = Db.GetDataReader(querySale);
                if (drSale.Read())
                {
                    textBoxPTotalSaleQty.Text = drSale["Qty"] != DBNull.Value ? Convert.ToDouble(drSale["Qty"]).ToString("N") : "0.00";
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labelCustomSearchClose_Click(object sender, EventArgs e)
        {
            panelCustomSearch.Visible = false;
        }

        private void buttonCustomSearch_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            panelCustomSearch.Visible = true;
        }

        private void buttonCustom_Click(object sender, EventArgs e)
        {
            LoadStockDetails(true);
        }

        private void frmStockReport_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxCompany.DataSource = null;
                comboBoxCompany.DisplayMember = "VendorName";
                comboBoxCompany.ValueMember = "id";
                comboBoxCompany.DataSource = Db.GetDataTable("SELECT id, VendorName FROM tblVendor");

                comboBoxCategory.DataSource = null;
                comboBoxCategory.DisplayMember = "CategoryName";
                comboBoxCategory.ValueMember = "id";
                comboBoxCategory.DataSource = Db.GetDataTable("SELECT * FROM tblCategory");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void radioButtonCsAll_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonAll.Checked = radioButtonCsAll.Checked;
        }

        private void radioButtonCsWithOutZiro_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonWithoutZero.Checked = radioButtonCsWithOutZiro.Checked;
        }

        private void radioButtonCsWithZiro_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonWithZero.Checked = radioButtonCsWithZiro.Checked;
        }

        
    }
}
