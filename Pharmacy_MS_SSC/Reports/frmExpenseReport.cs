using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pharmacy_MS_SSC.Common;
using Microsoft.Reporting.WinForms;



namespace Pharmacy_MS_SSC.Reports
{
    public partial class frmExpenseReport : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmExpenseReport()
        {
            InitializeComponent();
        }

        private void frmExpenseReport_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("pStartDate", dateTimePickerStart.Value.ToShortDateString()));
                parameterCollection.Add(new ReportParameter("pEndDate", dateTimePickerEnd.Value.ToShortDateString()));
                reportViewer1.LocalReport.SetParameters(parameterCollection);
                
                ReportDataSource expense = new ReportDataSource("DailyExpense", GetDaileExpense());
                ReportDataSource hospitalDetailsDataSource = new ReportDataSource("HospitalDetails", HospitalDetails());

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(expense);
                reportViewer1.LocalReport.DataSources.Add(hospitalDetailsDataSource);

                reportViewer1.RefreshReport();

            }
            catch
            {
                reportViewer1.LocalReport.DataSources.Clear();
            }
        }

        private DataTable GetDaileExpense()
        {
            conn.Close();
            conn.Open();
            string queryConfirm = "SELECT tblExpense.*, tblPayGateway.Name FROM tblExpense INNER JOIN tblPayGateway ON tblExpense.PayGatewayId = tblPayGateway.Id " +
                                  "WHERE tblExpense.Date BETWEEN '" + dateTimePickerStart.Value.ToString("M/d/yyyy") + "' AND '" + dateTimePickerEnd.Value.ToString("M/d/yyyy") + "' ";

            var cmd = new SqlCommand(queryConfirm, conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        private DataTable HospitalDetails()
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT *FROM TBL_OFFICE", conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reportViewer1.CurrentStatus.CanPrint)
            {
                reportViewer1.PrintDialog();
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label21_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void dateTimePickerStart_KeyDown(object sender, KeyEventArgs e)
        {
            button1.PerformClick();
        }

        private void dateTimePickerEnd_KeyDown(object sender, KeyEventArgs e)
        {
            button1.PerformClick();
        }
    }
}
