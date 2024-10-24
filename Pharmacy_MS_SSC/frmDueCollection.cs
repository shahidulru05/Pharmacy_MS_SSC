using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmDueCollection : Form
    {
        // SQL connection        
        static readonly DbConnection dbCon = new DbConnection();
        private static readonly SqlConnection _conn = new SqlConnection(dbCon.ConnectionString());

        private SqlCommand _cmd = new SqlCommand("", _conn);
        private SqlDataReader _dr;
        private SqlDataAdapter _da;
        private DataSet _ds;
        private DataTable _dt;

        public frmDueCollection()
        {
            InitializeComponent();
            GenerateInvoice();
            LoadDueList();
        }
        
        private void ResetForm(bool searchBoxClear)
        {
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                if (searchBoxClear)
                {
                    if (textBox.Name!=textBoxSaleInvoice1.Name)
                    {
                        textBox.Clear();
                    }
                }
                else
                {
                    if (textBox.Name==textBoxSaleInvoice1.Name || textBox.Name==textBoxSaleInvoice2.Name)
                    {
                        
                    }
                    else
                    {
                        if (textBox.Name != textBoxSaleInvoice1.Name)
                        {
                            textBox.Clear();
                        }
                    }
                }
            }

            buttonPayment.Enabled = false;
            listViewDuePayment.Items.Clear();
            textBoxTotalDuePay.Text = "0.00";

        }
        
        private double DueCollectedAmount(string saleInv)
        {
            _conn.Close();
            _conn.Open();
            _cmd.CommandText = "SELECT * FROM TBL_DUE_COLLECTION WHERE SALE_INV='" + saleInv + "'";
            var dr = _cmd.ExecuteReader();

            double dueCollect = 0;

            while (dr.Read())
            {
                dueCollect += Convert.ToDouble(dr["DUE_COLL"].ToString());
            }
            dr.Close();
            return dueCollect;
        }

        private void GenerateInvoice()
        {
            try
            {
                var year = Settings.Default.CURRENT_PERIOD;
                string defaultInvoice = "DCINV-" + year + "1";
                _conn.Close();
                _conn.Open();

                _cmd.CommandText = "SELECT DUE_COLL_INV AS INV FROM TBL_DUE_COLLECTION WHERE ID = (SELECT MAX(ID) AS ID FROM TBL_DUE_COLLECTION)";
                _dr = _cmd.ExecuteReader();

                if (_dr.Read() && !_dr.IsDBNull(0))
                {
                    var db_invoice = _dr["INV"].ToString();
                    var db_inv_year = db_invoice.Substring(6, 4);
                    labelDueCollectionInvoice.Text = Convert.ToInt32(db_inv_year) < Convert.ToInt32(year)
                        ? defaultInvoice
                        : new AutoGenerateInvoice().Invoice(db_invoice, "DCINV-" + year, 1);
                }
                else
                {
                    labelDueCollectionInvoice.Text = defaultInvoice;
                }
                _dr.Close();
            }
            catch
            {
                //
            }
        }

        private void LoadDuePaymentList(string invNo)
        {
            _conn.Close();
            _conn.Open();
            _cmd.CommandText = "SELECT * FROM TBL_DUE_COLLECTION WHERE SALE_INV='" + invNo + "'";
            _dr = _cmd.ExecuteReader();

            listViewDuePayment.Items.Clear();
            var sl = 1;
            double payTk = 0;
            while (_dr.Read())
            {
                var dueColl = _dr["DUE_COLL"].ToString();
                var collDate =  Convert.ToDateTime(_dr["COLL_DATE"].ToString()).ToString("dd-MMM-yy");
                var lv = new ListViewItem(sl.ToString());
                lv.SubItems.Add(_dr["DUE_COLL_INV"].ToString());
                lv.SubItems.Add(dueColl);
                lv.SubItems.Add(collDate);

                payTk += Convert.ToDouble(dueColl);
                textBoxTotalDuePay.Text = payTk.ToString("N");
                listViewDuePayment.Items.Add(lv);
                sl++;
            }
            
            _dr.Close();
        }

        private void LoadSaleInv(string invNo)
        {
            _conn.Close();
            _conn.Open();
            _cmd.CommandText = "SELECT * FROM tblSaleMaster WHERE InvNo='" + invNo + "'";
            _dr = _cmd.ExecuteReader();
            if (_dr.Read())
            {
                textBoxSaleInv.Text = invNo;
                textBoxName.Text = _dr["PatientName"].ToString();
                textBoxPhone.Text = _dr["MobileNo"].ToString();
                textBoxSaleAmount.Text = _dr["GrandTotal"].ToString();

                var saleAmount = Convert.ToDouble(_dr["GrandTotal"].ToString());
                var saleTimePay = Convert.ToDouble(_dr["Payment"].ToString());
                var totalDuePay = Convert.ToDouble(textBoxTotalDuePay.Text);

                textBoxPayment.Text = (saleTimePay + totalDuePay).ToString();
                textBoxDue.Text = (saleAmount - (saleTimePay + totalDuePay)).ToString();

                textBoxDuePay.Clear();
                textBoxCurrentDue.Clear();
            }
            _dr.Close();
        }

        private void LoadDueList()
        {
            listViewDue.Items.Clear();
            var sl = 1;
            double dueTk = 0;

            _conn.Close();
            _conn.Open();
            _cmd.CommandText = "SELECT * FROM VW_SALE ORDER BY MobileNo ASC";
            _da=new SqlDataAdapter(_cmd);
            _dt=new DataTable();
            _da.Fill(_dt);

            if (_dt.Rows.Count>0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    var saleInv = row["InvNo"].ToString();
                    var preDue = Convert.ToDouble(row["TotalDue"].ToString());

                    var dueCollected = DueCollectedAmount(row["InvNo"].ToString());

                    var runDue = preDue - dueCollected;

                    var lv = new ListViewItem(sl.ToString());
                    lv.SubItems.Add(saleInv);
                    lv.SubItems.Add(runDue.ToString("N"));
                    lv.SubItems.Add(row["MobileNo"].ToString());
                    lv.SubItems.Add(row["PatientName"].ToString());

                    dueTk += Convert.ToDouble(runDue);
                    labelDueCount.Text = sl.ToString();
                    labelTotalDue.Text = dueTk.ToString("N");
                    sl++;
                    listViewDue.Items.Add(lv);
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ResetForm(false);

            var saleInv = textBoxSaleInvoice1.Text + textBoxSaleInvoice2.Text;
            if (saleInv != textBoxSaleInvoice1.Text)
            {
                foreach (ListViewItem item in listViewDue.Items)
                {
                    if (item.SubItems[1].ToString().ToLower().Contains(saleInv.ToLower()))
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        listViewDue.Items.Remove(item);
                    }

                }
                if (listViewDue.SelectedItems.Count == 1)
                {
                    listViewDue.Focus();
                }
            }
            else
            {
                LoadDueList();
            }
        }

        private void textBoxSaleInvoice2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSearch.PerformClick();
            }
        }

        private void listViewDue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                ResetForm(true);

                if (e.KeyCode==Keys.Enter)
                {
                    LoadDuePaymentList(listViewDue.SelectedItems[0].SubItems[1].Text);
                    LoadSaleInv(listViewDue.SelectedItems[0].SubItems[1].Text);
                    textBoxDuePay.Focus();
                }
            }
            catch 
            {
                ResetForm(true);

                textBoxDuePay.Focus();
            }
        }

        private void textBoxDuePay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var totalDue = Convert.ToDouble(textBoxDue.Text);
                var payment = Convert.ToDouble(textBoxDuePay.Text);
                
                if (payment > 0)
                {
                    if (payment <= totalDue)
                    {
                        textBoxCurrentDue.Text = (totalDue - payment).ToString("N");
                        buttonPayment.Enabled = true;
                    }
                    else
                    {
                        textBoxDuePay.Text = Convert.ToString(totalDue);
                        textBoxDuePay.SelectAll();
                        buttonPayment.Enabled = false;
                    }
                }
            }
            catch
            {
                textBoxCurrentDue.Text = "0.00";
                textBoxDuePay.Text = "0.00";
                textBoxDuePay.SelectAll();
                buttonPayment.Enabled = false;
            }
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            try
            {
                _conn.Close();
                _conn.Open();
                GenerateInvoice();

                _cmd.CommandText =
                    "INSERT INTO TBL_DUE_COLLECTION ([DUE_COLL_INV],[SALE_INV],[DUE_COLL],[COLL_DATE],[CREATE_BY],[UPDATE_BY]) VALUES ('" +
                    labelDueCollectionInvoice.Text + "', '" + textBoxSaleInv.Text + "', '" + textBoxDuePay.Text + "','" +
                    DateTime.Now.ToString("M/d/yyyy") + "', '" + GlobalSettings.UserName + "','')";
            
                var isPay = _cmd.ExecuteNonQuery();
                if (isPay <= 0) return;
                buttonPayment.Enabled = false;
                if (!(Convert.ToDouble(textBoxCurrentDue.Text) > 0))
                {
                    _conn.Close();
                    _conn.Open();
                    _cmd.CommandText = "UPDATE tblSaleMaster SET PAY_STATUS='P' WHERE InvNo='" + textBoxSaleInv.Text + "'";
                    _cmd.ExecuteNonQuery();
                }

                ResetForm(true);

                LoadDueList();
                GenerateInvoice();
                textBoxSaleInvoice2.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                buttonPayment.Enabled = false;
            }
        }

        private void textBoxDuePay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (buttonPayment.Enabled)
                {
                    buttonPayment.PerformClick();
                }
            }
        }

        private void listViewDue_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ResetForm(true);


                LoadDuePaymentList(listViewDue.SelectedItems[0].SubItems[1].Text);
                LoadSaleInv(listViewDue.SelectedItems[0].SubItems[1].Text);

                var selectedItem = listViewDue.SelectedItems[0].SubItems[columnHeaderMobileNo.Index].Text;
                double totalDueThisCustomer = 0;
                labelTotalDueThisCustomer.Text = @"00";

                if (selectedItem!="")
                {
                    totalDueThisCustomer += (from ListViewItem item in listViewDue.Items where item.SubItems[columnHeaderMobileNo.Index].Text == selectedItem select Convert.ToDouble(item.SubItems[columnHeaderDue.Index].Text)).Sum();
                }

                labelTotalDueThisCustomer.Text = totalDueThisCustomer.ToString("N");

                textBoxDuePay.Focus();
            }
            catch 
            {
                //
            }
        }
    }
}
