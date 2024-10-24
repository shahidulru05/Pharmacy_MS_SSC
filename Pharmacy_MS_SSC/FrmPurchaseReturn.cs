using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pharmacy_MS_SSC.Common;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Toolbox;

namespace Pharmacy_MS_SSC
{
    public partial class FrmPurchaseReturn : Form
    {
        private string _purchaseId;

        public FrmPurchaseReturn()
        {
            InitializeComponent();
            LoadTrade();
            LoadCompany();
            GenerateInvoice();
            checkBoxReturnInv.Checked = Settings.Default.WithReturnInvoice;
            comboBoxTradeName.Select(0, 0);
            comboBoxCompany.Focus();
            textBoxSearch.Focus();
        }

        private void Print(string invoice)
        {
            var returnData = Db.GetDataTable("SELECT PN.INV, PN.RETURN_DATE, PN.PURCHASE_ID, PN.UNIT_PRICE, " +
                                             "PN.RETURN_QTY, PN.TOTAL, PN.REASON, PN.CREATE_BY, P.PurchaseInvNo, " +
                                             "P.InvNo AS P_INV, P.INV_DATE, P.BatchNo, P.ManufactureDate, " +
                                             "P.ExpiryDate, T.TradeName, G.GenericName, C.CategoryName, " +
                                             "V.VendorName AS COMPANY, S.VendorName AS SELLER " +
                                             "FROM TBL_PURCHASE_RETURN_DTL AS PN " +
                                             "LEFT JOIN tblPurchase AS P ON PN.PURCHASE_ID=P.id " +
                                             "LEFT JOIN tblVendor AS S ON P.SELLER_ID=S.id " +
                                             "LEFT JOIN tblTradeName AS T ON P.TradeCode=T.TradeCode " +
                                             "LEFT JOIN tblGenericName AS G ON T.GenericID=G.id " +
                                             "LEFT JOIN tblCategory AS C ON T.CategoryID=C.id " +
                                             "LEFT JOIN tblVendor AS V ON T.VendorID=V.id " +
                                             "WHERE PN.INV='"+invoice+"'");

            if (returnData.Rows.Count>0)
            {
                new CustomReportViewer("Purchase Return", "Reports.RptPurchaseReturn",
                    new ReportDataSource("OfficeInfo",GlobalSettings.OfficeInfo),
                    new ReportDataSource("ReturnData",returnData)
                ).Show();
            }
            else
            {
                MessageBox.Show("No data");
            }
        }

        private void UpdateStock(string tradeCode, double quantity)
        {
            try
            {
                var query = "SELECT Qty FROM tblStock WHERE TradeCode='" + tradeCode + "'";
                var dr = Db.GetDataReader(query);
                if (dr.HasRows)
                {
                    dr.Read();
                    var stockQty = Convert.ToDouble(dr["Qty"].ToString());
                    var currentQty = stockQty - quantity;
                    Db.QueryExecute("UPDATE tblStock SET Qty=" + currentQty + " WHERE TradeCode='" + tradeCode + "'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateInvoice()
        {
            labelInvoice.Text = Db.GenerateInvoice("PRI-", 1, 1, "TBL_PURCHASE_RETURN_DTL", "ID", "INV");
        }

        private void ClearField(bool isReturn = false)
        {
            _purchaseId = string.Empty;
            panelReturnDetails.Enabled = false;
            foreach (var textBox in panelReturnDetails.Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }

            if (isReturn)
            {
                listViewConfirmReturn.Items.Clear();
                CalculateReturn();
            }
        }

        private void CalculateReturn()
        {
            var totalItems = listViewConfirmReturn.Items.Count;
            var totalPrice = listViewConfirmReturn.Items.Cast<ListViewItem>().Sum(item => Convert.ToDouble(item.SubItems[chTotal.Index].Text.ToString()));

            labelTotalItems.Text = totalItems.ToString();
            labelTotalPrice.Text = totalPrice.ToString("N");
            buttonReturn.Enabled = totalItems > 0;
        }

        private void LoadTrade()
        {
            try
            {
                var tradeTd = Db.GetDataTable("SELECT TradeCode, TradeName FROM tblTradeName ORDER BY TradeName ASC");
                comboBoxTradeName.DisplayMember = "TradeName";
                comboBoxTradeName.ValueMember = "TradeCode";
                comboBoxTradeName.DataSource = tradeTd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCompany()
        {
            try
            {
                var tradeTd = Db.GetDataTable("SELECT id, VendorName FROM tblVendor ORDER BY VendorName ASC");
                comboBoxCompany.DisplayMember = "VendorName";
                comboBoxCompany.ValueMember = "id";
                comboBoxCompany.DataSource = tradeTd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void labelClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        private void label21_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }
        
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearField();
                listViewMedicineList.Items.Clear();

                var query =
                    "SELECT P.id, P.PurchaseDate, P.InvNo, P.PurchaseInvNo, P.BatchNo, P.TradeCode, " +
                    "P.Qty, T.TradeName " +
                    "FROM tblPurchase P " +
                    "LEFT JOIN tblTradeName T ON P.TradeCode=T.TradeCode ";
                var where = "";
                if (!string.IsNullOrEmpty(textBoxSearch.Text))
                {
                    if (string.IsNullOrEmpty(where))
                    {
                        where = "WHERE P.BatchNo='" + textBoxSearch.Text.Trim() + "'";
                    }
                }

                if (checkBoxTradeName.Checked)
                {
                    if (string.IsNullOrEmpty(where))
                    {
                        where = "WHERE P.TradeCode='" + comboBoxTradeName.SelectedValue + "'";
                    }
                    else
                    {
                        where += " AND P.TradeCode='" + comboBoxTradeName.SelectedValue + "'";
                    }
                }

                if (checkBoxCompany.Checked)
                {
                    if (string.IsNullOrEmpty(where))
                    {
                        where = "WHERE P.VendorId='" + comboBoxCompany.SelectedValue + "'";
                    }
                    else
                    {
                        where += " AND P.VendorId='" + comboBoxCompany.SelectedValue + "'";
                    }
                }


                var dt = Db.GetDataTable(query + where);
                var sl = 1;
                if (dt.Rows.Count>0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var lvi=new ListViewItem(sl.ToString());
                        lvi.SubItems.Add(Convert.ToDateTime(row["PurchaseDate"].ToString()).ToString(GlobalSettings.DateFormatShortView));
                        lvi.SubItems.Add(row["InvNo"].ToString());
                        lvi.SubItems.Add(row["PurchaseInvNo"].ToString());
                        lvi.SubItems.Add(row["BatchNo"].ToString());
                        lvi.SubItems.Add(row["TradeCode"].ToString());
                        lvi.SubItems.Add(row["TradeName"].ToString());
                        lvi.SubItems.Add(row["Qty"].ToString());
                        lvi.SubItems.Add(row["id"].ToString());
                        sl++;
                        listViewMedicineList.Items.Add(lvi);
                    }
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            buttonSearch.PerformClick();
        }

        private void listViewMedicineList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var query =
                    "SELECT P.id, P.PurchaseDate, P.InvNo, P.PurchaseInvNo, P.BatchNo, P.TradeCode, P.Qty, P.UnitPrice, " +
                    "P.ManufactureDate, P.ExpiryDate, S.Qty AS RUN_QTY, T.TradeName, C.CategoryName, G.GenericName, " +
                    "V.VendorName, VS.VendorName AS SELLER_NAME " +
                    "FROM tblPurchase P " +
                    "LEFT JOIN tblStock S ON P.TradeCode=S.TradeCode " +
                    "LEFT JOIN tblTradeName T ON P.TradeCode=T.TradeCode " +
                    "LEFT JOIN tblCategory C ON T.CategoryID=C.id " +
                    "LEFT JOIN tblGenericName G ON T.GenericID=G.id " +
                    "LEFT JOIN tblVendor V ON T.VendorID=V.id " +
                    "LEFT JOIN tblVendor VS ON P.SELLER_ID=VS.id " +
                    "WHERE P.id='"+listViewMedicineList.SelectedItems[0].SubItems[columnHeaderPurchaseId.Index].Text+"'";
                var dr = Db.GetDataReader(query);
                if (dr.HasRows)
                {
                    dr.Read();
                    panelReturnDetails.Enabled = true;

                    var purchaseQty = Convert.ToDouble(dr["Qty"].ToString());
                    var runningQty = Convert.ToDouble(dr["RUN_QTY"].ToString());
                    double previousReturnQty = 0;
                    double returnableQty = 0;

                    _purchaseId = dr["id"].ToString();
                    textBoxTradeCode.Text = dr["TradeCode"].ToString();
                    textBoxTradeName.Text = dr["TradeName"].ToString();
                    textBoxCategoryName.Text = dr["CategoryName"].ToString();
                    textBoxGenericName.Text = dr["GenericName"].ToString();
                    textBoxVendorName.Text = dr["VendorName"].ToString();
                    textBoxSellerName.Text = dr["SELLER_NAME"].ToString();
                    textBoxUnitPrice.Text = dr["UnitPrice"].ToString();

                    var checkQuery = "SELECT PURCHASE_ID, SUM(ISNULL(RETURN_QTY,0)) AS RETURN_QTY " +
                                     "FROM TBL_PURCHASE_RETURN_DTL WHERE PURCHASE_ID=" + _purchaseId + " GROUP BY PURCHASE_ID";
                    var preReturnDr = Db.GetDataReader(checkQuery);
                    if (preReturnDr.HasRows)
                    {
                        preReturnDr.Read();
                        previousReturnQty = Convert.ToDouble(preReturnDr["RETURN_QTY"].ToString());
                    }

                    returnableQty = purchaseQty - previousReturnQty;
                    if (previousReturnQty>0)
                    {
                        MessageBox.Show("Purchase Quantity = " + purchaseQty + "\nAlready Return = " +
                                        previousReturnQty + "\nAvailable Returnable Quantity = " + 
                                        returnableQty,textBoxTradeName.Text);
                    }

                    textBoxPurchaseQty.Text = returnableQty.ToString();
                    textBoxStockQty.Text = runningQty.ToString();

                    textBoxReturnQty.Focus();
                }
                else
                {
                    ClearField();
                }
            }
            catch (Exception ex)
            {
                ClearField();
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxReturnQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var purchaseQty = Convert.ToDouble(textBoxPurchaseQty.Text.Trim());
                var stockQty = Convert.ToDouble(textBoxStockQty.Text.Trim());
                var availableQty = purchaseQty > stockQty ? stockQty : purchaseQty;
                var enterQty = Convert.ToDouble(textBoxReturnQty.Text.Trim());
                if (availableQty>=enterQty && enterQty!=0)
                {
                    var unitPrice = Convert.ToDouble(textBoxUnitPrice.Text.Trim());
                    var totalPrice = unitPrice * enterQty;
                    textBoxReturnPrice.Text = totalPrice.ToString();
                    buttonAdd.Enabled = true;
                }
                else
                {
                    buttonAdd.Enabled = false;
                    MessageBox.Show("Maximum Return Qty = " + availableQty);
                    textBoxReturnQty.Clear();
                    textBoxReturnPrice.Text = @"0.00";
                }
            }
            catch
            {
                buttonAdd.Enabled = false;
                textBoxReturnQty.Clear();
                textBoxReturnPrice.Text = @"0.00";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var flag = false;
                foreach (ListViewItem item in listViewConfirmReturn.Items)
                {
                    var id = item.SubItems[chPurchaseId.Index].Text;
                    if (_purchaseId != id) continue;
                    flag = true;
                    break;
                }

                if (!flag)
                {
                    var lvi = new ListViewItem(_purchaseId);
                    lvi.SubItems.Add(textBoxTradeCode.Text);
                    lvi.SubItems.Add(textBoxTradeName.Text);
                    lvi.SubItems.Add(textBoxUnitPrice.Text);
                    lvi.SubItems.Add(textBoxReturnQty.Text);
                    lvi.SubItems.Add(textBoxReturnPrice.Text);
                    lvi.SubItems.Add(textBoxReason.Text);

                    listViewConfirmReturn.Items.Add(lvi);
                }
                else
                {
                    MessageBox.Show("This item has been added to this list.");
                }

                ClearField();
                CalculateReturn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxReturnQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBoxReason.Focus();
            }
        }

        private void listViewConfirmReturn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (listViewConfirmReturn.Items.Count>0)
                {
                    if (e.KeyCode==Keys.Delete)
                    {
                        listViewConfirmReturn.Items.RemoveAt(listViewConfirmReturn.SelectedItems[0].Index);
                    }
                }
                CalculateReturn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateInvoice();
                var query = string.Empty;

                foreach (ListViewItem item in listViewConfirmReturn.Items)
                {
                    query += "INSERT INTO TBL_PURCHASE_RETURN_DTL (ID, INV, PURCHASE_ID, UNIT_PRICE, RETURN_QTY, TOTAL, REASON, " +
                             "RETURN_DATE, CREATE_BY,CREATE_DATE) VALUES((SELECT ISNULL(MAX(ID)+1,1) AS ID FROM TBL_PURCHASE_RETURN_DTL),'"
                             + labelInvoice.Text + "'," + item.SubItems[chPurchaseId.Index].Text + ", " +
                             item.SubItems[chUnitPrice.Index].Text + "," + item.SubItems[chReturnQty.Index].Text + "," +
                             item.SubItems[chTotal.Index].Text + ",'" + item.SubItems[chReason.Index].Text + "','" +
                             DateTime.Now.ToString(GlobalSettings.DateFormatSave) + "','" + GlobalSettings.UserName + "','" +
                             DateTime.Now.ToString(GlobalSettings.DateFormatSave) + "');";
                }

                var flag = Db.QueryExecute(query);
                if (flag)
                {
                    foreach (ListViewItem item in listViewConfirmReturn.Items)
                    {
                        UpdateStock(item.SubItems[chTradeCode.Index].Text, Convert.ToDouble(item.SubItems[chReturnQty.Index].Text));
                    }

                    ClearField(true);

                    if (checkBoxReturnInv.Checked)
                    {
                        Print(labelInvoice.Text);
                    }
                }

                GenerateInvoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxReason_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonAdd.PerformClick();
            }
        }

        private void checkBoxReturnInv_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.WithReturnInvoice = checkBoxReturnInv.Checked;
            Settings.Default.Save();
        }

        private void linkLabelPrintOldInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var userInput = string.Empty;
            userInput = MessageBoxInput.Show("Please enter invoice number", "Print Old Invoice", GlobalSettings.PurchaseReturn);
            
            if (!string.IsNullOrEmpty(userInput))
            {
                Print(userInput);
            }
        }
    }
}
