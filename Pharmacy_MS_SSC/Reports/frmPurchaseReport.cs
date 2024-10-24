using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using Microsoft.Reporting.WinForms;

namespace Pharmacy_MS_SSC.Reports
{
    public partial class frmPurchaseReport : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmPurchaseReport()
        {
            InitializeComponent();
            comboBoxPurchaseType.SelectedValue = 0;
        }

        private void PurchaseReport()
        {
            try
            {
                reportViewerPurchaseReport.LocalReport.DataSources.Clear();

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("pFromDate", dateTimePickerFrom.Value.ToString("dd-MMM-yy")));
                parameterCollection.Add(new ReportParameter("pToDate", dateTimePickerTo.Value.ToString("dd-MMM-yy")));
                reportViewerPurchaseReport.LocalReport.SetParameters(parameterCollection);
                
                ReportDataSource hospitalDetailsDataSource = new ReportDataSource("HospitalDetails", OfficeDetails());
                ReportDataSource purchaseInformation = new ReportDataSource("PurchaseInformation",
                    PurchaseInformationDateToDate(dateTimePickerFrom.Value, dateTimePickerTo.Value, textBoxSearch.Text, comboBoxPurchaseType.Text=="All"?"":comboBoxPurchaseType.Text));
                
                reportViewerPurchaseReport.LocalReport.DataSources.Clear();
                reportViewerPurchaseReport.LocalReport.DataSources.Add(purchaseInformation);
                reportViewerPurchaseReport.LocalReport.DataSources.Add(hospitalDetailsDataSource);

                reportViewerPurchaseReport.RefreshReport();
            }
            catch
            {
                reportViewerPurchaseReport.LocalReport.DataSources.Clear();
            }
        }

        private DataTable PurchaseInformationDateToDate(DateTime from, DateTime to, string  text, string purchaseType)
        {
            conn.Close();
            conn.Open();
            var query = "SELECT tblPurchase.*, tblTradeName.TradeName, tblVendor.VendorName " +
                        "FROM tblPurchase " +
                        "INNER JOIN tblTradeName ON tblPurchase.TradeCode = tblTradeName.TradeCode " +
                        "INNER JOIN tblVendor ON tblPurchase.VendorId = tblVendor.id " +
                        "WHERE (INV_DATE BETWEEN '" + from.ToString("M/d/yyyy") + "' AND '" +
                        to.ToString("M/d/yyyy") + "') " +
                        "AND ((tblTradeName.TradeName LIKE '%" + text + "%') " +
                        "OR tblPurchase.TradeCode = '" + text + "' " +
                        "OR (tblVendor.VendorName LIKE '%" + text + "%')) " +
                        "AND tblPurchase.PurchaseType LIKE '%" + purchaseType + "%' " +
                        "ORDER BY INV_DATE DESC";
            var cmd = new SqlCommand(query, conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        private DataTable OfficeDetails()
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT *FROM TBL_OFFICE", conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
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

        private void frmPurchaseReport_Load(object sender, EventArgs e)
        {
            reportViewerPurchaseReport.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewerPurchaseReport.ZoomMode = ZoomMode.FullPage;
            this.reportViewerPurchaseReport.RefreshReport();
            
            PurchaseReport();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PurchaseReport();
        }
        
        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSearch.PerformClick();
            }
        }

        private void comboBoxPurchaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PurchaseReport();
        }


    }
}
