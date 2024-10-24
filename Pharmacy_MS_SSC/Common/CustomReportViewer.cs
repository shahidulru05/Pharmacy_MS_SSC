using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Pharmacy_MS_SSC.Common
{
    public partial class CustomReportViewer : Form
    {

        public CustomReportViewer()
        {
            InitializeComponent();
        }
        
        private void labelClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labelPin_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void frmReportView_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.RefreshReport();
        }

        private void AutoPrint_Tick(object sender, EventArgs e)
        {
            if (!reportViewer1.CurrentStatus.CanPrint) return;
            AutoPrint.Stop();
            reportViewer1.PrintDialog();
        }


        /// <summary>
        /// Print report without preview
        /// </summary>
        /// <param name="selectPrinter"></param>
        public void PrintToPrinter()
        {
            AutoPrint.Start();
        }

        /// <summary>
        /// If set your report data source
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource">Report data source</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource)
        {
            InitializeComponent();

            labelTitle.Text = title;
            reportViewer1.LocalReport.ReportEmbeddedResource = Application.ProductName + "." + reportDocument + ".rdlc";
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.RefreshReport();
        }
        
        /// <summary>
        /// If set report data source 2 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2) 
            : this(title, reportDocument, reportDataSource1)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// If set report data source 3 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        /// <param name="reportDataSource3">Report data source 3</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2, ReportDataSource reportDataSource3)
            : this(title, reportDocument, reportDataSource1, reportDataSource2)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// If set your report data source 3 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        /// <param name="reportDataSource3">Report data source 3</param>
        /// <param name="reportDataSource4">Report data source 4</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2, ReportDataSource reportDataSource3, ReportDataSource reportDataSource4)
            : this(title, reportDocument, reportDataSource1, reportDataSource2, reportDataSource3)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// If set your report data source 3 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        /// <param name="reportDataSource3">Report data source 3</param>
        /// <param name="reportDataSource4">Report data source 4</param>
        /// <param name="reportDataSource5">Report data source 5</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2, ReportDataSource reportDataSource3, ReportDataSource reportDataSource4, ReportDataSource reportDataSource5)
            : this(title, reportDocument, reportDataSource1, reportDataSource2, reportDataSource3, reportDataSource4)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            reportViewer1.RefreshReport();
        }

        //-----------------------------------------------------------------------
        //                          With Parameters
        //-----------------------------------------------------------------------

        /// <summary>
        /// If set your report data source
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource">Report data source</param>
        /// <param name="parameterCollection">Report parameter collection</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource, ReportParameterCollection parameterCollection)
        {
            InitializeComponent();

            labelTitle.Text = title;
            reportViewer1.LocalReport.ReportEmbeddedResource = Application.ProductName + "." + reportDocument + ".rdlc";
            reportViewer1.LocalReport.SetParameters(parameterCollection);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// If set report data source 2 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        /// <param name="parameterCollection">Report parameter collection</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2, ReportParameterCollection parameterCollection)
            : this(title, reportDocument, reportDataSource1, parameterCollection)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// If set report data source 3 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        /// <param name="reportDataSource3">Report data source 3</param>
        /// <param name="parameterCollection">Report parameter collection</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2, ReportDataSource reportDataSource3, ReportParameterCollection parameterCollection)
            : this(title, reportDocument, reportDataSource1, reportDataSource2, parameterCollection)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// If set your report data source 3 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        /// <param name="reportDataSource3">Report data source 3</param>
        /// <param name="reportDataSource4">Report data source 4</param>
        /// <param name="parameterCollection">Report parameter collection</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2, ReportDataSource reportDataSource3, ReportDataSource reportDataSource4, ReportParameterCollection parameterCollection)
            : this(title, reportDocument, reportDataSource1, reportDataSource2, reportDataSource3, parameterCollection)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            reportViewer1.RefreshReport();
        }

        /// <summary>
        /// If set your report data source 3 time
        /// </summary>
        /// <param name="title">Report preview form title name</param>
        /// <param name="reportDocument">Link RDLC report document</param>
        /// <param name="reportDataSource1">Report data source 1</param>
        /// <param name="reportDataSource2">Report data source 2</param>
        /// <param name="reportDataSource3">Report data source 3</param>
        /// <param name="reportDataSource4">Report data source 4</param>
        /// <param name="reportDataSource5">Report data source 5</param>
        /// <param name="parameterCollection">Report parameter collection</param>
        public CustomReportViewer(string title, string reportDocument, ReportDataSource reportDataSource1, ReportDataSource reportDataSource2, ReportDataSource reportDataSource3, ReportDataSource reportDataSource4, ReportDataSource reportDataSource5, ReportParameterCollection parameterCollection)
            : this(title, reportDocument, reportDataSource1, reportDataSource2, reportDataSource3, reportDataSource4, parameterCollection)
        {
            reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            reportViewer1.RefreshReport();
        }


    }
}
