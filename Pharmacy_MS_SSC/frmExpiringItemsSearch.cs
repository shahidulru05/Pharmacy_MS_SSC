using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmExpiringItemsSearch : Form
    {
        private Button searchButton;
        private string _companyId;
        private string _tradeCode;
        private int _currentExpiryIndex;
        private int _totalExpiryItems;
        
        public frmExpiringItemsSearch()
        {
            InitializeComponent();
            comboBoxExpiryDay.SelectedIndex = 2;
            
            AddArchive();

            SetValue();
            LoadData(FilterType.All);
        }

        private enum FilterType
        {
            All, DateToDate, CompanyName, TradeName, BatchNumber
        }

        private void AddArchive()
        {
            if (GlobalSettings.AddToArchive)
            {
                listViewExpiringItems.CheckBoxes = true;
                labelCheckedItems.Visible = true;
                buttonUpdate.Visible = true;
            }
            else
            {
                listViewExpiringItems.CheckBoxes = false;
                labelCheckedItems.Visible = false;
                buttonUpdate.Visible = false;
            }
        }

        private void LoadData(FilterType filterType)
        {
            try
            {
                var query = "SELECT P.id, P.Qty as purchase_qty, P.ManufactureDate, P.ExpiryDate, " +
                            "P.BatchNo, T.TradeCode, T.TradeName, S.Qty, V.VendorName " +
                            "FROM tblPurchase AS P " +
                            "LEFT JOIN tblTradeName AS T ON P.TradeCode=T.TradeCode " +
                            "LEFT JOIN tblStock AS S ON T.TradeCode=S.TradeCode " +
                            "LEFT JOIN tblVendor AS V ON P.VendorId=V.id";

                var filter = " WHERE S.Qty>0 AND S.UnitPrice>0 AND P.STATUS <> 'SO' ";

                var orderBy = " ORDER BY T.TradeCode";

                if (filterType == FilterType.All)
                {
                    filter += "";
                }
                else if (filterType == FilterType.DateToDate)
                {
                    filter += " AND (P.ExpiryDate BETWEEN '" +
                              dateTimePickerStart.Value.ToString(GlobalSettings.DateFormatSave) +
                              "' AND '" + dateTimePickerEnd.Value.ToString(GlobalSettings.DateFormatSave) + "')";

                    if (checkBoxCompany.Checked)
                    {
                        if (!string.IsNullOrEmpty(_companyId))
                        {
                            filter += " AND P.VendorId='" + _companyId + "'";
                        }
                        else
                        {
                            MessageBox.Show("Please enter company name");
                            return;
                        }
                    }
                    
                    if (checkBoxTradeName.Checked)
                    {
                        if (!string.IsNullOrEmpty(_tradeCode))
                        {
                            filter += " AND P.TradeCode='" + _tradeCode + "'";
                        }
                        else
                        {
                            MessageBox.Show("Please enter trade name");
                            return;
                        }
                    }
                }
                else if (filterType == FilterType.CompanyName)
                {
                    filter += " AND P.VendorId='" + _companyId + "'";
                }
                else if (filterType == FilterType.TradeName)
                {
                    filter += " AND P.TradeCode='" + _tradeCode + "'";
                }
                else if (filterType == FilterType.BatchNumber)
                {
                    filter += " AND P.BatchNo='" + textBoxBatchNo.Text.Trim() + "'";
                }

                var finalQuery = query + filter + orderBy;

                var dt = Db.GetDataTable(finalQuery);



                // Load Data to ListView
                listViewExpiringItems.Items.Clear();
                _totalExpiryItems = 0;
                labelTotalItems.Text = @"Total items : 0";
                labelExpiryQuantity.Text = @"Total expiry qty : 0";

                if (dt.Rows.Count > 0)
                {
                    var sl = 1;
                    var expiryDay = Convert.ToDouble(comboBoxExpiryDay.Text);
                    foreach (DataRow row in dt.Rows)
                    {
                        var exd = Convert.ToDateTime(row["ExpiryDate"].ToString()).Date;
                        var ts = exd - DateTime.Today.Date;

                        var lvi = new ListViewItem(sl.ToString());
                        lvi.SubItems.Add(row["id"].ToString());
                        lvi.SubItems.Add(row["BatchNo"].ToString());
                        lvi.SubItems.Add(row["TradeCode"].ToString());
                        lvi.SubItems.Add(row["TradeName"].ToString());
                        lvi.SubItems.Add(row["VendorName"].ToString());
                        lvi.SubItems.Add(row["purchase_qty"].ToString());
                        lvi.SubItems.Add(row["Qty"].ToString());
                        lvi.SubItems.Add(Convert.ToDateTime(row["ManufactureDate"].ToString()).ToString("dd-MMM-yyyy"));
                        lvi.SubItems.Add(Convert.ToDateTime(row["ExpiryDate"].ToString()).ToString("dd-MMM-yyyy"));
                        lvi.SubItems.Add(ts.TotalDays.ToString());

                        if (ts.Days <= expiryDay)
                        {
                            _totalExpiryItems += 1;
                            lvi.BackColor = Color.IndianRed;
                            lvi.ForeColor = Color.White;
                        }
                        else
                        {
                            lvi.BackColor = Color.White;
                            lvi.ForeColor = Color.Black;
                        }

                        if (checkBoxViewOnlyExpiry.Checked)
                        {
                            if (ts.Days <= expiryDay)
                            {
                                listViewExpiringItems.Items.Add(lvi);
                                listViewExpiringItems.EnsureVisible(sl - 1);
                                sl++;
                            }
                        }
                        else
                        {
                            listViewExpiringItems.Items.Add(lvi);
                            listViewExpiringItems.EnsureVisible(sl - 1);
                            sl++;
                        }

                        labelTotalItems.Text = @"Total items : " + sl;
                        labelExpiryQuantity.Text = @"Total expiry qty : " + _totalExpiryItems;
                        Application.DoEvents();
                    }
                }

                if (listViewExpiringItems.Items.Count == 0)
                {
                    MessageBox.Show(@"No Data");
                }

                labelTotalItems.Text = @"Total items : " + listViewExpiringItems.Items.Count;
                labelExpiryQuantity.Text = @"Total expiry qty : " + _totalExpiryItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void SetValue()
        {
            var query = "SELECT MIN(ExpiryDate) AS MIN_DATE, MAX(ExpiryDate) AS MAX_DATE FROM tblPurchase WHERE STATUS <> 'SO'";
            var max = Db.GetDataReader(query);
            if (max.HasRows)
            {
                max.Read();
                var minDate = Convert.ToDateTime(max["MIN_DATE"]);
                var maxDate = Convert.ToDateTime(max["MAX_DATE"]);
                dateTimePickerStart.MinDate = minDate;
                dateTimePickerStart.MaxDate = maxDate;
                dateTimePickerEnd.MinDate = minDate;
                dateTimePickerEnd.MaxDate = maxDate;
            }

        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labelPin_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panelCompany.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panelTradeName.Visible = false;
        }

        private void textBoxCompany_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var query = "SELECT id, VendorName FROM tblVendor WHERE VendorName LIKE '%" + textBoxCompany.Text + "%'";
                dataGridViewCompany.DataSource = Db.GetDataTable(query);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void textBoxCompany_Click(object sender, EventArgs e)
        {
            textBoxCompany.Clear();
            _companyId = string.Empty;
            dataGridViewCompany.DataSource = Db.GetDataTable("SELECT id, VendorName FROM tblVendor");
            panelCompany.Visible = true;
        }

        private void dataGridViewCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             _companyId = dataGridViewCompany.Rows[e.RowIndex].Cells["id"].Value.ToString();
             textBoxCompany.Text = dataGridViewCompany.Rows[e.RowIndex].Cells["VendorName"].Value.ToString();
             panelCompany.Visible = false;

             LoadData(FilterType.CompanyName);
        }

        private void dataGridViewCompany_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewCompany.Rows[e.RowIndex].Cells["vSl"].Value = (e.RowIndex + 1).ToString();
        }
        
        private void buttonBatchNoSearch_Click(object sender, EventArgs e)
        {
            searchButton = (Button) sender;
            LoadData(FilterType.BatchNumber);
        }

        private void textBoxBatchNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonBatchNoSearch.PerformClick();
            }
        }

        private void textBoxTradeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var query="SELECT id, TradeCode, TradeName FROM tblTradeName WHERE TradeName LIKE '%"+textBoxTradeName.Text+"%'";
                
                dataGridViewTradeList.DataSource = Db.GetDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxTradeName_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxTradeName.Clear();
                _tradeCode = string.Empty;
                dataGridViewTradeList.DataSource = Db.GetDataTable("SELECT id, TradeCode, TradeName FROM tblTradeName");

                panelTradeName.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewTradeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _tradeCode = dataGridViewTradeList.Rows[e.RowIndex].Cells["tTradeCode"].Value.ToString();
            textBoxTradeName.Text = dataGridViewTradeList.Rows[e.RowIndex].Cells["tTradeName"].Value.ToString();

            panelTradeName.Visible = false;

            LoadData(FilterType.TradeName);
        }

        private void dataGridViewTradeList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewTradeList.Rows[e.RowIndex].Cells["tSl"].Value = (e.RowIndex + 1).ToString();
        }
        
        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerEnd.MinDate = dateTimePickerStart.Value;
        }

        private void comboBoxExpiryDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentExpiryIndex = 0;
        }

        private void listViewExpiringItems_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var checkedItems = 0;
            foreach (ListViewItem item in listViewExpiringItems.Items)
            {
                if (item.Checked)
                {
                    checkedItems += 1;
                }
            }

            buttonUpdate.Enabled = checkedItems > 0;
            labelCheckedItems.Text = "Total checked items : "+ checkedItems;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var selectedId = "";
            foreach (ListViewItem item in listViewExpiringItems.Items)
            {
                if (item.Checked)
                {
                    selectedId += selectedId == "" ? item.SubItems[columnHeaderId.Index].Text : "," + item.SubItems[columnHeaderId.Index].Text;
                }
            }

            var flag = Db.QueryExecute("UPDATE tblPurchase SET STATUS='SO' WHERE ID IN (" + selectedId + ")");

            if (searchButton!=null)
            {
                searchButton.PerformClick();
            }

            MessageBox.Show(flag ? "Successfully update" : "Failed try again");

        }

        private void buttonAllStock_Click(object sender, EventArgs e)
        {
            try
            {
                searchButton = (Button)sender;
                LoadData(FilterType.All);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonSearchDateToDate_Click(object sender, EventArgs e)
        {
            searchButton = (Button)sender;
            LoadData(FilterType.DateToDate);
        }
        
        
    }
}
