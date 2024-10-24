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
    public partial class frmVendorPayment : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmVendorPayment()
        {
            InitializeComponent();
            GenerateInvoice();
        }

        private void ClearText()
        {
            foreach (var textBox in Controls.OfType<TextBox>())
            {
                if (textBox.Name != textBoxSearch.Name)
                {
                    textBox.Text = "0.00";
                }
            }
            textBoxPurchaseInvoice.Clear();
            labelSallerName.Text = "";
        }

        private void InsertPayment()
        {
            GenerateInvoice();
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand(
                "INSERT INTO TBL_VENDOR_PAYMENT(PAY_INV,PURCHASE_INV,PURCHASE_INV_VENDOR,PAY_AMT,PAY_DATE,CREATE_BY,INV_DATE,SELLER_NAME)VALUES('" +
                labelPaymentInv.Text + "', '"+textBoxPurchaseInvoice.Text+"', '"+textBoxSearch.Text.Trim()+"','"+
                textBoxPayment.Text.Trim() + "', '" + DateTime.Now.ToString("M/d/yyyy") + "', '" + GlobalSettings.UserName + "','" +
                dateTimePickerInvoiceDate.Value.ToString("M/d/yyyy") + "','"+labelSallerName.Text+"' )", conn);
            cmd.ExecuteNonQuery();
            GenerateInvoice();
        }

        private void PaymentList(string purchaseInvoice, string invoiceDate)
        {
            listViewPaymentList.Items.Clear();
            double totalAmount = 0;
            var sl = 1;

            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM TBL_VENDOR_PAYMENT WHERE PURCHASE_INV_VENDOR='" + purchaseInvoice + "' AND INV_DATE='" + invoiceDate + "'", conn);
            var da=new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var amt = Convert.ToDouble(row["PAY_AMT"].ToString());
                    var lv=new ListViewItem(sl.ToString());
                    lv.SubItems.Add(row["PURCHASE_INV"].ToString());
                    lv.SubItems.Add(amt.ToString());
                    lv.SubItems.Add(Convert.ToDateTime(row["PAY_DATE"].ToString()).ToString("dd-MMM-yy"));

                    listViewPaymentList.Items.Add(lv);

                    totalAmount += amt;
                    sl++;
                }
            }

            textBoxAlreadyPay.Text = totalAmount.ToString("N");
            textBoxTotalDue.Text = (Convert.ToDouble(textBoxTotalAmount.Text) - Convert.ToDouble(textBoxAlreadyPay.Text)).ToString("N");
        }

        private void GenerateInvoice()
        {
            try
            {
                var year = Settings.Default.CURRENT_PERIOD;
                string defaultInvoice = "VPINV-" + year + "1";
                conn.Close();
                conn.Open();

                var cmd = new SqlCommand("SELECT PAY_INV AS INV FROM TBL_VENDOR_PAYMENT WHERE ID = (SELECT MAX(ID) AS ID FROM TBL_VENDOR_PAYMENT)", conn);
                var dr = cmd.ExecuteReader();
                if (dr.Read() && !dr.IsDBNull(0))
                {
                    var db_invoice = dr["INV"].ToString();
                    var db_inv_year = db_invoice.Substring(6, 4);
                    labelPaymentInv.Text = Convert.ToInt32(db_inv_year) < Convert.ToInt32(year)
                        ? defaultInvoice
                        : new AutoGenerateInvoice().Invoice(db_invoice, "VPINV-" + year, 1);
                }
                else
                {
                    labelPaymentInv.Text = defaultInvoice;
                }
                dr.Close();
            }
            catch
            {
                //
            }
        }

        private void SearchSaleInvoice(string purchaseInvoice, string invoiceDate)
        {
            listViewPurchaseInvoice.Items.Clear();
            listViewPurchaseInvoice.Groups.Clear();
            ClearText();
            
            double totalQty = 0;
            double totalAmount = 0;
            var sl = 1;

            // Purchase Invoice Group
            conn.Close();
            conn.Open();
            var cmd1 = new SqlCommand("SELECT InvNo FROM tblPurchase WHERE PurchaseInvNo='" + purchaseInvoice +
                                      "' AND INV_DATE='" + invoiceDate + "' GROUP BY InvNo", conn);
            var da1 = new SqlDataAdapter(cmd1);
            var dt1 = new DataTable();
            da1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    var lvg = new ListViewGroup(row["InvNo"].ToString(), HorizontalAlignment.Left);
                    listViewPurchaseInvoice.Groups.Add(lvg);

                    textBoxPurchaseInvoice.Text += textBoxPurchaseInvoice.Text == "" ? row["InvNo"].ToString() : ", " + row["InvNo"];
                }
            }

            //Load Saller Name
            conn.Close();
            conn.Open();
            var cmd2 = new SqlCommand("SELECT TV.VendorName FROM (SELECT TP.SELLER_ID FROM tblPurchase TP WHERE TP.PurchaseInvNo ='"+
                                      textBoxSearch.Text.Trim() + "' AND TP.INV_DATE='" + invoiceDate +
                                      "' GROUP BY TP.SELLER_ID)ST INNER JOIN tblVendor TV ON ST.SELLER_ID=TV.id", conn);
            var da2 = new SqlDataAdapter(cmd2);
            var dt2 = new DataTable();
            da2.Fill(dt2);
            labelSallerName.Text = "";
            if (dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    if (labelSallerName.Text=="")
                    {
                        labelSallerName.Text = row["VendorName"].ToString();
                    }
                    else
                    {
                        labelSallerName.Text += ", " + row["VendorName"];
                    }
                }
            }

            // Purchase Items Details
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT tblPurchase.*, tblTradeName.TradeName FROM tblPurchase INNER JOIN tblTradeName ON tblPurchase.TradeCode=tblTradeName.TradeCode WHERE tblPurchase.PurchaseInvNo='" + purchaseInvoice + "' AND tblPurchase.INV_DATE='" + invoiceDate + "'", conn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var amount = Convert.ToDouble(row["TotalCost"].ToString());
                    var qty = Convert.ToDouble(row["Qty"].ToString());
                    totalQty += qty;
                    totalAmount += amount;

                    var lv = new ListViewItem();

                    foreach (ListViewGroup viewGroup in listViewPurchaseInvoice.Groups)
                    {
                        if (viewGroup.Header == row["InvNo"].ToString())
                        {
                            lv = new ListViewItem(sl.ToString(), viewGroup);
                            lv.SubItems.Add(row["TradeCode"].ToString());
                            lv.SubItems.Add(row["TradeName"].ToString());
                            lv.SubItems.Add(qty.ToString());
                            lv.SubItems.Add(row["UnitPrice"].ToString());
                            lv.SubItems.Add(row["TotalCost"].ToString());
                            lv.SubItems.Add(row["BatchNo"].ToString());
                        }
                    }

                    listViewPurchaseInvoice.Items.Add(lv);

                    textBoxTotalItems.Text = sl.ToString("N");
                    textBoxTotalQty.Text = totalQty.ToString("N");
                    textBoxTotalAmount.Text = totalAmount.ToString("N");
                    sl++;
                }
            }

            PaymentList(purchaseInvoice, invoiceDate);
            textBoxPayment.Focus();
            textBoxPayment.SelectAll();
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

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchSaleInvoice(textBoxSearch.Text.Trim(), dateTimePickerInvoiceDate.Value.ToString("M/d/yyyy"));
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchSaleInvoice(textBoxSearch.Text.Trim(), dateTimePickerInvoiceDate.Value.ToString("M/d/yyyy"));
        }

        private void textBoxPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var totalDue = Convert.ToDouble(textBoxTotalDue.Text);
                var payment = Convert.ToDouble(textBoxPayment.Text);

                if (payment > 0)
                {
                    if (payment <= totalDue)
                    {
                        textBoxCurrentDue.Text = (totalDue - payment).ToString("N");
                        buttonPayment.Enabled = true;
                    }
                    else
                    {
                        textBoxPayment.Text = Convert.ToString(totalDue);
                        textBoxPayment.SelectAll();
                        buttonPayment.Enabled = false;
                    }
                }
            }
            catch
            {
                textBoxCurrentDue.Text = "0.00";
                textBoxPayment.Text = "0.00";
                textBoxPayment.SelectAll();
                buttonPayment.Enabled = false;
            }
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            InsertPayment();
            ClearText();
            SearchSaleInvoice(textBoxSearch.Text.Trim(), dateTimePickerInvoiceDate.Value.ToString("M/d/yyyy"));
            buttonPayment.Enabled = false;
        }

        private void textBoxPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (!buttonPayment.Enabled) return;
            InsertPayment();
            ClearText();
            SearchSaleInvoice(textBoxSearch.Text.Trim(), dateTimePickerInvoiceDate.Value.ToString("M/d/yyyy"));
            buttonPayment.Enabled = false;
        }

        private void textBoxPayment_Click(object sender, EventArgs e)
        {
            textBoxPayment.SelectAll();
        }

        private void dateTimePickerInvoiceDate_ValueChanged(object sender, EventArgs e)
        {
            SearchSaleInvoice(textBoxSearch.Text.Trim(), dateTimePickerInvoiceDate.Value.ToString("M/d/yyyy"));
        }


    }
}
