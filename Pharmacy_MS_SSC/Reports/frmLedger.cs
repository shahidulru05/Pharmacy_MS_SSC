using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC.Reports
{
    public partial class frmLedger : Form
    {

        // SQL connection        
        static readonly DbConnection dbCon = new DbConnection();
        private readonly SqlConnection _conn = new SqlConnection(dbCon.ConnectionString());

        private SqlCommand _cmd;
        private SqlDataReader _dr;
        private SqlDataAdapter _da;
        private DataSet _ds;
        private DataTable _dt;

        private double _credit;
        private double _debit;

        private ReportViewer _reportViewer;
        
        public frmLedger()
        {
            InitializeComponent();
            dateTimePickerFrom.MaxDate=DateTime.Today;
            dateTimePickerTo.MaxDate=DateTime.Today;
        }

        private DataTable LedgerReportDt()
        {
            var dt=new DataTable();
            dt.Columns.Add("Date");
            dt.Columns.Add("Description");
            dt.Columns.Add("Debit");
            dt.Columns.Add("Credit");

            if (listViewLedger.Items.Count <= 0) return dt;
            foreach (ListViewItem item in listViewLedger.Items)
            {
                var drw = dt.NewRow();
                drw["Date"] = item.Text;
                drw["Description"] = item.SubItems[1].Text;
                drw["Debit"] = Convert.ToDouble(item.SubItems[2].Text);
                drw["Credit"] = Convert.ToDouble(item.SubItems[3].Text);

                dt.Rows.Add(drw);
            }
            return dt;
        }
        
        private void LoadSaleReturn()
        {
            _conn.Close();
            _conn.Open();

            var query =
                "SELECT ReturnDate, SUM(ISNULL(Payment,0)) AS PAY_AMT FROM tblSaleReturnMaster WHERE ReturnDate BETWEEN '" +
                dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" +
                dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' GROUP BY ReturnDate";
            _cmd = new SqlCommand(query, _conn);
            _da = new SqlDataAdapter(_cmd);
            _dt = new DataTable();
            _da.Fill(_dt);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var debit = Convert.ToDouble(row["PAY_AMT"].ToString());
                    _debit += debit;

                    var lv = new ListViewItem(Convert.ToDateTime(row["ReturnDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Sale Return");
                    lv.SubItems.Add(debit.ToString("N"));
                    lv.SubItems.Add("0");

                    listViewLedger.Items.Add(lv);
                    listViewLedger.Refresh();
                }
            }
        }
        
        private void LoadVendorPayment()
        {
            _conn.Close();
            _conn.Open();

            var query =
                "SELECT PAY_DATE, SUM(ISNULL(PAY_AMT,0)) AS PAY_AMT FROM TBL_VENDOR_PAYMENT WHERE PAY_DATE BETWEEN '" +
                dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" +
                dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' GROUP BY PAY_DATE";
            _cmd = new SqlCommand(query, _conn);
            _da = new SqlDataAdapter(_cmd);
            _dt = new DataTable();
            _da.Fill(_dt);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var debit = Convert.ToDouble(row["PAY_AMT"].ToString());
                    _debit += debit;

                    var lv = new ListViewItem(Convert.ToDateTime(row["PAY_DATE"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Vendor Payment");
                    lv.SubItems.Add(debit.ToString("N"));
                    lv.SubItems.Add("0");

                    listViewLedger.Items.Add(lv);
                    listViewLedger.Refresh();
                }
            }
        }

        private void LoadDueCollection()
        {
            _conn.Close();
            _conn.Open();

            var query =
                "SELECT COLL_DATE, SUM(ISNULL(DUE_COLL,0)) AS DUE_COLL FROM TBL_DUE_COLLECTION WHERE COLL_DATE BETWEEN '" +
                dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" +
                dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' GROUP BY COLL_DATE";
            _cmd = new SqlCommand(query, _conn);
            _da = new SqlDataAdapter(_cmd);
            _dt = new DataTable();
            _da.Fill(_dt);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var credit = Convert.ToDouble(row["DUE_COLL"].ToString());
                    _credit += credit;
                    
                    var lv = new ListViewItem(Convert.ToDateTime(row["COLL_DATE"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Due Collection");
                    lv.SubItems.Add("0");
                    lv.SubItems.Add(credit.ToString("N"));

                    listViewLedger.Items.Add(lv);
                    listViewLedger.Refresh();
                }
            }
        }

        private void LoadSale()
        {
            _conn.Close();
            _conn.Open();

            var query =
                //"SELECT SaleDate, (SUM(ISNULL(GrandTotal,0))-SUM(ISNULL(PurchasePrice,0))) AS PROFIT, SUM(ISNULL(TotalDue,0)) AS TotalDue FROM tblSaleMaster WHERE SaleDate BETWEEN '" +
                "SELECT SaleDate, SUM(ISNULL(GrandTotal,0)) AS GrandTotal, SUM(ISNULL(TotalDue,0)) AS TotalDue FROM tblSaleMaster WHERE SaleDate BETWEEN '" +
                dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" +
                dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' GROUP BY SaleDate";
            _cmd = new SqlCommand(query, _conn);
            _da = new SqlDataAdapter(_cmd);
            _dt = new DataTable();
            _da.Fill(_dt);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var credit = Convert.ToDouble(row["GrandTotal"].ToString());
                    _credit += credit;

                    var debit = Convert.ToDouble(row["TotalDue"].ToString());
                    _debit += debit;

                    var lv = new ListViewItem(Convert.ToDateTime(row["SaleDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Sale");
                    lv.SubItems.Add("0");
                    lv.SubItems.Add(credit.ToString("N"));
                    listViewLedger.Items.Add(lv);

                    lv = new ListViewItem(Convert.ToDateTime(row["SaleDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Sale Due");
                    lv.SubItems.Add(debit.ToString("N"));
                    lv.SubItems.Add("0");
                    listViewLedger.Items.Add(lv);

                    listViewLedger.Refresh();
                }
            }
        }

        private void PurchaseReturn()
        {
            var query =
                "SELECT RETURN_DATE, SUM(ISNULL(TOTAL,0)) AS TOTAL FROM TBL_PURCHASE_RETURN_DTL WHERE RETURN_DATE BETWEEN '" +
                dateTimePickerFrom.Value.ToString(GlobalSettings.DateFormatSave) + "' AND '" +
                dateTimePickerTo.Value.ToString(GlobalSettings.DateFormatSave) + "' GROUP BY RETURN_DATE";

            var dt = Db.GetDataTable(query);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var credit = Convert.ToDouble(row["TOTAL"].ToString());
                    _credit += credit;

                    var lv = new ListViewItem(Convert.ToDateTime(row["RETURN_DATE"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Purchase Return");
                    lv.SubItems.Add("0");
                    lv.SubItems.Add(credit.ToString("N"));
                    listViewLedger.Items.Add(lv);
                    
                    listViewLedger.Refresh();
                }
            }
        }

        private void LoadPurchase()
        {
            _conn.Close();
            _conn.Open();

            var query =
                "SELECT PurchaseDate, SUM(TotalCost) AS TotalCost FROM tblPurchase WHERE PurchaseDate BETWEEN '" +
                dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" +
                dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' GROUP BY PurchaseDate";
            _cmd = new SqlCommand(query, _conn);
            _da = new SqlDataAdapter(_cmd);
            _dt = new DataTable();
            _da.Fill(_dt);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var lv = new ListViewItem(Convert.ToDateTime(row["PurchaseDate"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Purchase");
                    lv.SubItems.Add(Convert.ToDouble(row["TotalCost"].ToString()).ToString("N"));
                    lv.SubItems.Add("0");

                    listViewLedger.Items.Add(lv);
                    listViewLedger.Refresh();
                }
            }
        }
        
        private void LoadExpense()
        {
            _conn.Close();
            _conn.Open();

            var query = "SELECT Date, SUM(Amount) AS Amount FROM tblExpense WHERE Date BETWEEN '" +
                        dateTimePickerFrom.Value.ToString("yyyy-MM-dd") + "' AND '" +
                        dateTimePickerTo.Value.ToString("yyyy-MM-dd") + "' GROUP BY Date";
            _cmd = new SqlCommand(query, _conn);
            _da = new SqlDataAdapter(_cmd);
            _dt = new DataTable();
            _da.Fill(_dt);

            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var debit = Convert.ToDouble(row["Amount"].ToString());
                    _debit += debit;
                    var lv = new ListViewItem(Convert.ToDateTime(row["Date"].ToString()).ToString("dd-MMM-yyyy"));
                    lv.SubItems.Add("Expense");
                    lv.SubItems.Add(debit.ToString("N"));
                    lv.SubItems.Add("0");

                    listViewLedger.Items.Add(lv);
                    listViewLedger.Refresh();
                }
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

        private void buttonShow_Click(object sender, EventArgs e)
        {
            try
            {
                listViewLedger.Items.Clear();
                _credit = 0;
                _debit = 0;
                
                LoadPurchase();
                PurchaseReturn();
                LoadExpense();
                LoadSale();
                LoadSaleReturn();
                LoadDueCollection();
                LoadVendorPayment();
                
                labelCredit.Text = _credit.ToString("N");
                labelDebit.Text = _debit.ToString("N");
                var balance = _credit - _debit;
                labelBalance.Text = balance.ToString("N");
                labelBalance.BackColor = balance > 0 ? Color.Green : Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.MinDate = dateTimePickerFrom.Value;
        }

        private void buttonPrintLedger_Click(object sender, EventArgs e)
        {
            _reportViewer=new ReportViewer();
            _reportViewer.LocalReport.ReportEmbeddedResource = Application.ProductName + ".Reports.rptLedger.rdlc";

            ReportParameterCollection parameterCollection = new ReportParameterCollection();
            parameterCollection.Add(new ReportParameter("pFromDate", dateTimePickerFrom.Value.ToShortDateString()));
            parameterCollection.Add(new ReportParameter("pToDate", dateTimePickerTo.Value.ToShortDateString()));
            parameterCollection.Add(new ReportParameter("pCredit", labelCredit.Text));
            parameterCollection.Add(new ReportParameter("pDebit", labelDebit.Text));
            parameterCollection.Add(new ReportParameter("pBalance", labelBalance.Text));
            _reportViewer.LocalReport.SetParameters(parameterCollection);

            _reportViewer.RefreshReport();

            _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo));
            _reportViewer.LocalReport.DataSources.Add(new ReportDataSource("LedgerDetails", LedgerReportDt()));

            _reportViewer.RefreshReport();

            timerPrintLedger.Start();
            Enabled = false;
        }

        private void timerPrintLedger_Tick(object sender, EventArgs e)
        {
            if(!_reportViewer.CurrentStatus.CanPrint) return;
            timerPrintLedger.Stop();
            _reportViewer.PrintDialog();
            Enabled = true;
        }
    }
}
