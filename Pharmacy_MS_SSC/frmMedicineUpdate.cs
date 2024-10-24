using System;
using System.Data;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmMedicineUpdate : Form
    {
        public frmMedicineUpdate()
        {
            InitializeComponent();
        }

        private void ClearField()
        {
            labelCode.Text = "";
            labelMedicineName.Text = "";
            labelCategory.Text = "";
            labelCompany.Text = "";
            labelRunningStock.Text = "";
            labelPurchasePrice.Text = "";
            labelWsPrice.Text = "";
            labelSaleMrp.Text = "";
            textBoxNewSaleMrp.Clear();
            textBoxNewWsPrice.Clear();
            buttonUpdate.Enabled = false;
        }

        private void ShowTradeDetails(string tradeCode)
        {
            ClearField();

            panelTrade.Visible = false;
            var query = "SELECT TN.*, CN.CategoryName, VN.VendorName, ST.Qty, ST.wsPrice, ST.SaleMRP, ST.UnitPrice " +
                        "FROM tblTradeName TN " +
                        "LEFT JOIN tblCategory CN ON TN.CategoryID=CN.ID " +
                        "LEFT JOIN tblVendor VN ON TN.VendorID=VN.ID " +
                        "LEFT JOIN tblStock ST ON TN.TradeCode=ST.TradeCode " +
                        "WHERE TN.TradeCode='" + tradeCode + "' ";
            
            var dr = Db.GetDataReader(query);
            if (dr.HasRows)
            {
                dr.Read();
                labelCode.Text = dr["TradeCode"].ToString();
                labelMedicineName.Text = dr["TradeName"].ToString();
                labelCategory.Text = dr["CategoryName"].ToString();
                labelCompany.Text = dr["VendorName"].ToString();
                labelRunningStock.Text = dr["Qty"].ToString();
                labelPurchasePrice.Text = dr["UnitPrice"].ToString();
                labelWsPrice.Text = dr["wsPrice"].ToString();
                labelSaleMrp.Text = dr["SaleMRP"].ToString();
                buttonUpdate.Enabled = true;
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

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSearch.PerformClick();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var queryTable = "SELECT * FROM tblTradeName WHERE TradeCode='" + textBoxSearch.Text +
                                 "' OR TradeName LIKE '%" + textBoxSearch.Text + "%' ";

                var dt = Db.GetDataTable(queryTable);
                if (dt.Rows.Count>0)
                {
                    panelTrade.Visible = true;
                    listViewTrade.Items.Clear();
                    var sl = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        var lvi=new ListViewItem(sl.ToString());
                        lvi.SubItems.Add(row["TradeCode"].ToString());
                        lvi.SubItems.Add(row["TradeName"].ToString());

                        sl++;
                        listViewTrade.Items.Add(lvi);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBoxHideTradePanel_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = false;
        }
        
        private void listViewTrade_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ShowTradeDetails(listViewTrade.SelectedItems[0].SubItems[columnHeaderTradeCode.Index].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listViewTrade_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    ShowTradeDetails(listViewTrade.SelectedItems[0].SubItems[columnHeaderTradeCode.Index].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var newWsPrice = textBoxNewWsPrice.Text != "" ? Convert.ToDouble(textBoxNewWsPrice.Text.Trim()) : 0;
                var newSaleMrp = textBoxNewSaleMrp.Text != "" ? Convert.ToDouble(textBoxNewSaleMrp.Text.Trim()) : 0;

                var queryWsPrice = "";
                var querySaleMrpPrice = "";
                var wsMessage = "";
                var saleMrpMessage = "";


                if (newWsPrice>0)
                {
                    queryWsPrice = "wsPrice='" + newWsPrice + "'";
                    wsMessage = "Old WS Price: ["+ labelWsPrice.Text +"] New WS Price: ["+newWsPrice+"]";
                }

                if (newSaleMrp>0)
                {
                    querySaleMrpPrice = "SaleMRP='" + newSaleMrp + "'";
                    saleMrpMessage = "Old Sale MRP: ["+ labelSaleMrp.Text + "] New Sale MRP: ["+newSaleMrp+"]";
                }

                var query = "UPDATE tblStock SET " + queryWsPrice + ", " + querySaleMrpPrice + 
                            " WHERE TradeCode='" + labelCode.Text + "'";

                if((newWsPrice==0 || newWsPrice==' ') && (newSaleMrp == 0 || newSaleMrp == ' ')) return;

                if (MessageBox.Show(wsMessage+"\n"+saleMrpMessage+"\n----------\nAre you sure update this price?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    var isUpdate=Db.QueryExecute(query);
                    if (isUpdate)
                    {
                        MessageBox.Show("Successfully completed medicine update");
                        ClearField();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
