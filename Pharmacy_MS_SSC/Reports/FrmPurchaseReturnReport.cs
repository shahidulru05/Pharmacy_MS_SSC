using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC.Reports
{
    public partial class FrmPurchaseReturnReport : Form
    {
        public FrmPurchaseReturnReport()
        {
            InitializeComponent();
            LoadTrade();
            LoadCompany();
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

        private void buttonView_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "SELECT PR.*, P.BatchNo, P.InvNo AS PURCHASE_INV, P.TradeCode, T.TradeName, V.VendorName " +
                            "FROM TBL_PURCHASE_RETURN_DTL AS PR " +
                            "LEFT JOIN tblPurchase AS P ON PR.PURCHASE_ID=P.id " +
                            "LEFT JOIN tblTradeName AS T ON P.TradeCode=T.TradeCode " +
                            "LEFT JOIN tblVendor AS V ON P.VendorId=V.id ";

                var where = "WHERE PR.RETURN_DATE BETWEEN '" + dateTimePickerFrom.Value.ToString(GlobalSettings.DateFormatSave) +
                            "' AND '" + dateTimePickerTo.Value.ToString(GlobalSettings.DateFormatSave) + "' "; ;
                
                if (checkBoxTradeName.Checked)
                {
                    where += " AND P.TradeCode='" + comboBoxTradeName.SelectedValue + "'";

                }

                if (checkBoxCompany.Checked)
                {
                    where += " AND P.VendorId='" + comboBoxCompany.SelectedValue + "'";
                }

                var returnDetails = Db.GetDataTable(query + where);

                if (returnDetails.Rows.Count>0)
                {
                    var pc = new ReportParameterCollection();
                    pc.Add(new ReportParameter("pFromDate", dateTimePickerFrom.Value.ToString()));
                    pc.Add(new ReportParameter("pToDate", dateTimePickerTo.Value.ToString()));

                    new CustomReportViewer("Purchase Return", "Reports.RptPurchaseReturnDetails",
                        new ReportDataSource("OfficeInfo", GlobalSettings.OfficeInfo),
                        new ReportDataSource("PurchaseReturn", returnDetails), pc).Show();
                }
                else
                {
                    MessageBox.Show("No data");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
