using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualStudio.Shell.Interop;

namespace Pharmacy_MS_SSC.Reports
{
    public partial class frmSaleReport : Form
    {

        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private string _searchInvoice = "0";
        
        public frmSaleReport()
        {
            InitializeComponent();

            dateTimePickerTo.MinDate = DateTime.Today;
            textBoxInvoice2.Text = DateTime.Today.Year.ToString();
            //SaleDateToDate();
        }

        private DataTable SubDueList()
        {
            conn.Close();
            conn.Open();
            var query = "SELECT VWS.InvNo, VWS.GrandTotal, VWS.TotalDue, TDC.DUE_COLL FROM VW_SALE VWS LEFT JOIN " +
                        "(SELECT SALE_INV, SUM(DUE_COLL) AS DUE_COLL FROM TBL_DUE_COLLECTION GROUP BY SALE_INV) TDC " +
                        "ON VWS.InvNo=TDC.SALE_INV WHERE VWS.MobileNo='" + textBoxPhone.Text.Trim() + "' ";
            var cmd = new SqlCommand(query, conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private DataTable PatientInformation()
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT MobileNo, COUNT(MobileNo) AS MobileNoCount, MAX(SaleDate) AS SaleDate FROM tblSaleMaster " +
                                     "WHERE SaleDate BETWEEN '" + dateTimePickerFrom.Value.ToString("M/d/yyyy") + "' AND '" +
                                     dateTimePickerTo.Value.ToString("M/d/yyyy") + "' GROUP BY MobileNo ORDER BY MobileNoCount DESC", conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        private DataTable PatientInformation(string phoneNo)
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT *FROM tblSaleMaster WHERE MobileNo='"+phoneNo+"'", conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        private DataTable SaleMaster(string saleInvoiceNo)
        {
            conn.Close();
            conn.Open();
            string query =
                "SELECT InvNo, Payment, Total, Adjustment, GrandTotal, Discount, SubTotal, SaleDate, SaleTime, UserName, Refund, TotalDue " +
                "FROM tblSaleMaster " +
                "WHERE InvNo='" + saleInvoiceNo + "'";
            var cmd = new SqlCommand(query, conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        
        private ReportDataSource SearchDateToDate(string invoice)
        {
            ReportDataSource reportDataSource;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;

            conn.Close();
            conn.Open();
            var query = "";

            if (invoice == "0")
            {
                query = "SELECT InvNo, MobileNo, PatientName, SubTotal, Discount,Total, Adjustment, GrandTotal, SaleDate, TotalDue, " +
                        "UserName, PurchasePrice, TotalItem FROM tblSaleMaster WHERE SaleDate BETWEEN '" +
                        dateTimePickerFrom.Value.ToString("M/d/yyyy") + "' AND '" +
                        dateTimePickerTo.Value.ToString("M/d/yyyy") + "'";
                cmd = new SqlCommand(query, conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                reportDataSource = new ReportDataSource("DateToDateSale", dt);

            }
            else
            {
                query = "SELECT tblSaleDetails.*, tblTradeName.TradeName " +
                        "FROM tblSaleDetails INNER JOIN tblTradeName ON " +
                        "tblSaleDetails.TradeCode = tblTradeName.TradeCode " +
                        "WHERE tblSaleDetails.InvNo='" + invoice + "'";
                cmd = new SqlCommand(query, conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                reportDataSource = new ReportDataSource("SaleInvoice", dt);
            }

            //_searchInvoice = "0";
            return reportDataSource;
        }

        private void labelPin_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSaleReport_Load(object sender, EventArgs e)
        {
            var dt = Db.GetDataTable("SELECT TradeCode, TradeName FROM tblTradeName");
            if (dt.Rows.Count > 0)
            {
                comboBoxTradeName.DataSource = dt;
            }

            var dtVenodr = Db.GetDataTable("SELECT id, VendorName FROM tblVendor");
            if (dtVenodr.Rows.Count > 0)
            {
                comboBoxVendorName.DataSource = dtVenodr;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("pFromDate", dateTimePickerFrom.Value.ToString("dd-MMM-yy")));
                parameterCollection.Add(new ReportParameter("pToDate", dateTimePickerTo.Value.ToString("dd-MMM-yy")));

                if (radioButtonSaleReport.Checked)
                {
                    ReportDataSource dateToDate = SearchDateToDate(_searchInvoice);

                    new CustomReportViewer("Sale Report", "Reports.rptSaleDateToDate",
                        new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo), dateToDate,
                        parameterCollection).ShowDialog();
                }
                else if (radioButtonCustomerPhone.Checked)
                {
                    new CustomReportViewer("", "Reports.rptSaleGroupMobile",
                            new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo),
                            new ReportDataSource("SaleGroupMobile", PatientInformation()), parameterCollection)
                        .ShowDialog();
                }
            }
            catch
            {
                //
            }
        }
        
        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.MinDate = dateTimePickerFrom.Value;
        }

        private void buttonSearchInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                _searchInvoice = textBoxInvoice1.Text + textBoxInvoice2.Text;

                new CustomReportViewer("Invoice Report", "Reports.rptSaleInvoice",
                    new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo),
                    new ReportDataSource("SaleMaster", SaleMaster(_searchInvoice)),
                    new ReportDataSource("DueCollection", Db.GetDataTable("SELECT * FROM TBL_DUE_COLLECTION WHERE SALE_INV='" + _searchInvoice + "'")),
                    SearchDateToDate(_searchInvoice)).ShowDialog();

                _searchInvoice = "0";
            }
            catch
            {
                //
            }
        }

        private void textBoxInvoice2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSearchInvoice.PerformClick();
            }
        }
        
        private void buttonSearchPhone_Click(object sender, EventArgs e)
        {
            try
            {
                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("pPhone", textBoxPhone.Text.Trim()));
                parameterCollection.Add(new ReportParameter("pSubDueList", SubDueList().Rows.Count > 0 ? "1" : "0"));

                new CustomReportViewer("", "Reports.rptSalePhoneNo",
                    new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo),
                    new ReportDataSource("PatientInformation", PatientInformation(textBoxPhone.Text.Trim())),
                    new ReportDataSource("SubDueList", SubDueList()),
                    parameterCollection
                    ).ShowDialog();
            }
            catch
            {
                //
            }
        }

        private void textBoxPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSearchPhone.PerformClick();
            }
        }

        private void buttonSearchTradeName_Click(object sender, EventArgs e)
        {
            var query = "SELECT SD.*, TN.TradeName, SM.SaleDate, VN.VendorName " +
                        "FROM tblSaleDetails SD " +
                        "LEFT JOIN tblTradeName TN ON SD.TradeCode=TN.TradeCode " +
                        "LEFT JOIN tblSaleMaster SM ON SD.InvNo=SM.InvNo " +
                        "LEFT JOIN tblVendor VN ON TN.VendorID = VN.id " +
                        "WHERE (SM.SaleDate BETWEEN '" +
                        dateTimePickerTradeNameFrom.Value.ToString(GlobalSettings.DateFormatSave) + "' AND " +
                        "'" + dateTimePickerTradeNameTo.Value.ToString(GlobalSettings.DateFormatSave) + "') AND " +
                        "TN.TradeCode='" + comboBoxTradeName.SelectedValue + "'";
            var dt = Db.GetDataTable(query);

            var rpc=new ReportParameterCollection();
            rpc.Add(new ReportParameter("pFromDate",dateTimePickerTradeNameFrom.Value.ToString()));
            rpc.Add(new ReportParameter("pToDate",dateTimePickerTradeNameTo.Value.ToString()));
            

            new CustomReportViewer("Sale Report", "Reports.rptSaleTradeCodeSaleDate",
                new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo),
                new ReportDataSource("TradeCodeSaleDate", dt),
                rpc).Show();

        }

        private void buttonSearchVendorName_Click(object sender, EventArgs e)
        {
            var query = "SELECT SD.*, TN.TradeName, SM.SaleDate, VN.VendorName " +
                        "FROM tblSaleDetails SD " +
                        "LEFT JOIN tblTradeName TN ON SD.TradeCode=TN.TradeCode " +
                        "LEFT JOIN tblSaleMaster SM ON SD.InvNo=SM.InvNo " +
                        "LEFT JOIN tblVendor VN ON TN.VendorID = VN.id " +
                        "WHERE (SM.SaleDate BETWEEN '" +
                        dateTimePickerTradeNameFrom.Value.ToString(GlobalSettings.DateFormatSave) + "' AND " +
                        "'" + dateTimePickerTradeNameTo.Value.ToString(GlobalSettings.DateFormatSave) + "') AND " +
                        "TN.VendorID='" + comboBoxVendorName.SelectedValue + "'";
            var dt = Db.GetDataTable(query);

            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("pFromDate", dateTimePickerTradeNameFrom.Value.ToString()));
            rpc.Add(new ReportParameter("pToDate", dateTimePickerTradeNameTo.Value.ToString()));


            new CustomReportViewer("Sale Report", "Reports.rptSaleTradeCodeSaleDate",
                new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo),
                new ReportDataSource("TradeCodeSaleDate", dt),
                rpc).Show();
        }



    }
}
