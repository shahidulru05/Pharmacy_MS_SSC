using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC.Reports
{
    public partial class frmVendorPaymentReport : Form
    {
        // SQL connection        
        static readonly DbConnection dbCon = new DbConnection();
        private readonly SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private SqlDataAdapter _da;
        private DataSet _ds;
        private DataTable _dt;
        public frmVendorPaymentReport()
        {
            InitializeComponent();
            ViewReport();
        }


        private ReportDataSource VendorPaymentList()
        {
            ReportDataSource reportDataSource;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;

            conn.Close();
            conn.Open();
            var query = "";

            if (radioButtonDateToDate.Checked)
            {
                query = "SELECT * FROM TBL_VENDOR_PAYMENT WHERE PAY_DATE BETWEEN '" +
                        dateTimePicker1.Value.ToString("M/d/yyyy") + "' AND '" +
                        dateTimePicker2.Value.ToString("M/d/yyyy") + "'";
                cmd = new SqlCommand(query, conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                reportDataSource = new ReportDataSource("VendorPay", dt);

            }
            else
            {
                query = "SELECT * FROM TBL_VENDOR_PAYMENT WHERE PAY_DATE= '" + DateTime.Today.ToString("M/d/yyyy") + "'";
                cmd = new SqlCommand(query, conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                reportDataSource = new ReportDataSource("VendorPay", dt);
            }

            return reportDataSource;
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

        private void ViewReport()
        {
            try
            {
                reportViewerVendorPayment.LocalReport.DataSources.Clear();

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(radioButtonDateToDate.Checked ? new ReportParameter("pShowDate", "1") : new ReportParameter("pShowDate", "0"));
                parameterCollection.Add(new ReportParameter("pFromDate", dateTimePicker1.Value.ToShortDateString()));
                parameterCollection.Add(new ReportParameter("pToDate", dateTimePicker2.Value.ToShortDateString()));
                reportViewerVendorPayment.LocalReport.SetParameters(parameterCollection);

                ReportDataSource officeDetailsDataSource = new ReportDataSource("OfficeDetails", OfficeDetails());
                ReportDataSource dueCollectionDataSource = VendorPaymentList();

                reportViewerVendorPayment.LocalReport.DataSources.Clear();
                reportViewerVendorPayment.LocalReport.DataSources.Add(officeDetailsDataSource);
                reportViewerVendorPayment.LocalReport.DataSources.Add(dueCollectionDataSource);

                reportViewerVendorPayment.RefreshReport();
            }
            catch
            {
                //
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

        private void frmVendorPaymentReport_Load(object sender, EventArgs e)
        {
            reportViewerVendorPayment.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewerVendorPayment.RefreshReport();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            ViewReport();
        }

        private void radioButtonToday_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            ViewReport();
        }

        private void radioButtonDateToDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }
    }
}
