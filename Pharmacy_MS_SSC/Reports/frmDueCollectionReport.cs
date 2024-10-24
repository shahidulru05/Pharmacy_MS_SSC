using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC.Reports
{

    public partial class frmDueCollectionReport : Form
    {
        // SQL connection        
        static readonly DbConnection dbCon = new DbConnection();
        private readonly SqlConnection _conn = new SqlConnection(dbCon.ConnectionString());

        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private SqlDataAdapter _da;
        private DataSet _ds;
        private DataTable _dt;

        public frmDueCollectionReport()
        {
            InitializeComponent();
            ViewReport();
        }

        private void ViewReport()
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(radioButtonDateToDate.Checked ? new ReportParameter("pShowDate", "1") : new ReportParameter("pShowDate", "0"));
                parameterCollection.Add(new ReportParameter("pFromDate", dateTimePicker1.Value.ToShortDateString()));
                parameterCollection.Add(new ReportParameter("pToDate", dateTimePicker2.Value.ToShortDateString()));
                reportViewer1.LocalReport.SetParameters(parameterCollection);

                ReportDataSource officeDetailsDataSource = new ReportDataSource("OfficeDetails", OfficeDetails());
                ReportDataSource dueCollectionDataSource = DueCollectionList();

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(officeDetailsDataSource);
                reportViewer1.LocalReport.DataSources.Add(dueCollectionDataSource);

                reportViewer1.RefreshReport();
            }
            catch
            {
                //
            }
        }

        private ReportDataSource DueCollectionList()
        {
            ReportDataSource reportDataSource;
            SqlCommand cmd;
            SqlDataAdapter da;
            DataTable dt;

            _conn.Close();
            _conn.Open();
            var query = "";

            if (radioButtonDateToDate.Checked)
            {
                query = "SELECT * FROM TBL_DUE_COLLECTION WHERE COLL_DATE BETWEEN '" +
                        dateTimePicker1.Value.ToString("M/d/yyyy") + "' AND '" +
                        dateTimePicker2.Value.ToString("M/d/yyyy") + "'";
                cmd = new SqlCommand(query, _conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                reportDataSource = new ReportDataSource("DueCollection", dt);

            }
            else
            {
                query = "SELECT * FROM TBL_DUE_COLLECTION WHERE COLL_DATE= '" + DateTime.Today.ToString("M/d/yyyy") + "'";
                cmd = new SqlCommand(query, _conn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                reportDataSource = new ReportDataSource("DueCollection", dt);
            }

            return reportDataSource;
        }

        private DataTable OfficeDetails()
        {
            _conn.Close();
            _conn.Open();
            var cmd = new SqlCommand("SELECT *FROM TBL_OFFICE", _conn);
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

        private void frmDueCollectionReport_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
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
        
        private void buttonShow_Click(object sender, EventArgs e)
        {
            ViewReport();
        }
    }
}
