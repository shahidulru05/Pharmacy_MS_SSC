using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmSale : Form
    {
        private string wsPrice = "0";
        private string salePrice = "0";
        private int gridIndex = 0;
        //private string _tradeCode;
        private double purchasePrice = 0;
        
        public frmSale()
        {
            InitializeComponent();

            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            GenerateInvoice();

            CalculateGridValue();
            DiscountCalculate();
            PaymentCalculate();
            SaleReport(labelSaleInvoice.Text);

            textBoxSaleInvoice2.Text = DateTime.Today.Year.ToString();
        }

        private void AdjustmentCalculate()
        {
            try
            {
                var total = Convert.ToDouble(textBoxFTotal.Text.Trim());
                var adj = Convert.ToDouble(textBoxFAdjustment.Text.Trim());
                textBoxFGrandTotal.Text = (total + adj).ToString("N");
            }
            catch
            {
                textBoxFAdjustment.Text = "0.00";
                textBoxFAdjustment.SelectAll();
                textBoxFAdjustment.Focus();
            }
        }

        private void SetSaleInvoiceSize()
        {
            var reportPath = Application.ProductName + ".Reports.";

            switch (GlobalSettings.SaleMemoSize.ToString())
            {
                case "2":
                    reportViewer1.LocalReport.ReportEmbeddedResource = reportPath + "rptSale2in.rdlc";
                    break;
                case "3":
                    reportViewer1.LocalReport.ReportEmbeddedResource = reportPath + "rptSale3in.rdlc";
                    break;
                default:
                    reportViewer1.LocalReport.ReportEmbeddedResource = reportPath + "rptSale3in.rdlc";
                    break;
            }
        }

        private void TradeAndStockDetails()
        {
            try
            {
                textBoxTradeCode.Text = dataGridView1.SelectedRows[0].Cells["saleTradeCode"].Value.ToString();
                wsPrice = dataGridView1.SelectedRows[0].Cells["saleWSPrice"].Value.ToString();
                salePrice = dataGridView1.SelectedRows[0].Cells["saleSaleMRP"].Value.ToString();
                labelQty.Text = dataGridView1.SelectedRows[0].Cells["saleQty"].Value.ToString();
                purchasePrice = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["unitPrice"].Value);

                textBoxTradeName.Text = dataGridView1.SelectedRows[0].Cells["saleTradeName"].Value.ToString();
                labelStoreLocation.Text = dataGridView1.SelectedRows[0].Cells["ColumnRACK_NAME_SALE"].Value.ToString();

                textBoxUnitPrice.Text = checkBox2.Checked ? wsPrice : salePrice;

                panelTrade.Visible = false;

                btnAdd.Enabled = true;

                textBoxQty.Focus();
                textBoxQty.SelectAll();
            }
            catch (Exception ex)
            {
                panelTrade.Visible = false;
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateInvoice()
        {
            try
            {
                var year = Settings.Default.CURRENT_PERIOD;
                string defaultInvoice = "SINV-"+year+"1";

                var dr = Db.GetDataReader("SELECT InvNo FROM tblSaleMaster WHERE id = (SELECT MAX(id) AS ID FROM tblSaleMaster)");
                if (dr.Read() && !dr.IsDBNull(0))
                {
                    var db_invoice = dr["InvNo"].ToString();
                    var db_inv_year = db_invoice.Substring(5, 4);
                    labelSaleInvoice.Text = Convert.ToInt32(db_inv_year) < Convert.ToInt32(year)
                        ? defaultInvoice
                        : new AutoGenerateInvoice().Invoice(db_invoice, "SINV-" + year, 1);
                }
                else
                {
                    labelSaleInvoice.Text = defaultInvoice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void InsertSaleMaster()
        {
            double totalPurchasePrice = 0;

            for (var ss = 0; ss < dgvfrmSale.Rows.Count; ss++)
            {
                totalPurchasePrice += Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempPurchasePrice"].Value.ToString());
            }

            var totalDue = Convert.ToDouble(textBoxFDue.Text);
            
            var query = "INSERT INTO tblSaleMaster (InvNo,PatientID,PatientName,Address,MobileNo,SubTotal,Discount,Total,Adjustment,GrandTotal,Payment,TotalDue,Refund,SaleDate,SaleTime,TotalItem,UserName,PurchasePrice, PAY_STATUS) VALUES (" +
                           "'" + labelSaleInvoice.Text + "','" + textBoxPatientId.Text.Trim() + "','" + textBoxPatientName.Text.Trim() + "','" + textBoxAddress.Text.Trim() + "','" +
                           textBoxMobile.Text.Trim() + "','" + Convert.ToDouble(textBoxFSubTotal.Text) + "','" +
                           Convert.ToDouble(textBoxFDiscount.Text.Trim()) + "','" + Convert.ToDouble(textBoxFTotal.Text) + "','" +
                           Convert.ToDouble(textBoxFAdjustment.Text.Trim()) + "','" + Convert.ToDouble(textBoxFGrandTotal.Text) + "','" +
                           Convert.ToDouble(textBoxFPayment.Text.Trim()) + "','" + totalDue + "','" +
                           Convert.ToDouble(textBoxFChange.Text) + "','" + DateTime.Now.ToString("M/d/yyyy") + "','" + DateTime.Now.ToLongTimeString() + "','" +
                           Convert.ToInt32(labelTotalItems.Text) + "','" + GlobalSettings.UserName + "', '"+totalPurchasePrice+"', '"+
                           (totalDue>0?'D':'P')+"' )";

            Db.QueryExecute(query);
        }

        private void stockUpdate(string tradeCode, double quantity)
        {
            var dr = Db.GetDataReader("SELECT * FROM tblStock WHERE TradeCode='" + tradeCode + "'");
            
            if (dr.HasRows)
            {
                dr.Read();
                var qty = Convert.ToDouble(dr["Qty"].ToString());
                var result = qty - quantity;
                dr.Close();

                Db.QueryExecute("UPDATE tblStock SET Qty='" + result + "' WHERE TradeCode='" + tradeCode + "'");
            }
        }

        private void InsertSaleDetails()
        {
            try
            {
                var saleType = checkBox2.Checked ? "WS" : "Sale";
                
                for (var ss = 0; ss < dgvfrmSale.Rows.Count; ss++)
                {
                    var query = "INSERT INTO tblSaleDetails (InvNo, TradeCode,SaleType,UnitPrice,Qty,SubTotal,Discount,Total,UserName,PurchasePrice)VALUES " + "('" +
                                   labelSaleInvoice.Text + "','" +
                                   dgvfrmSale.Rows[ss].Cells["tempTradeCode"].Value + "','" +
                                   saleType + "','" +
                                   Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempUnitPrice"].Value) + "','" +
                                   Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempQty"].Value) + "','" +
                                   Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempSubTotal"].Value) + "','" +
                                   Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempDiscount"].Value) + "','" +
                                   Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempTotal"].Value) + "', +" +
                                   " '" + GlobalSettings.UserName + "', +" +
                                   " '" + Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempPurchasePrice"].Value) + "') ";

                    Db.QueryExecute(query);

                    stockUpdate(dgvfrmSale.Rows[ss].Cells["tempTradeCode"].Value.ToString(), Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempQty"].Value));
                    Thread.Sleep(150);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void PaymentCalculate()
        {
            double grandTotal = Convert.ToDouble(textBoxFGrandTotal.Text) > 0 ? Convert.ToDouble(textBoxFGrandTotal.Text) : 0.00;
            double payment = Convert.ToDouble(textBoxFPayment.Text) > 0 ? Convert.ToDouble(textBoxFPayment.Text) : 0.00;
            double calculate = payment - grandTotal;

            if (calculate<0)
            {
                textBoxFDue.Text = (calculate * (-1)).ToString("N");
                textBoxFChange.Text = "0.00";
            }
            else if (calculate>0)
            {
                textBoxFDue.Text = "0.00";
                textBoxFChange.Text = calculate.ToString("N");
            }
            else
            {
                textBoxFDue.Text = "0.00";
                textBoxFChange.Text = "0.00";
            }

        }

        private void DiscountCalculate()
        {
            double subTotal = Convert.ToDouble(textBoxFSubTotal.Text) > 0 ? Convert.ToDouble(textBoxFSubTotal.Text) : 0.00;
            double discount = Convert.ToDouble(textBoxFDiscount.Text) > 0 ? Convert.ToDouble(textBoxFDiscount.Text) : 0.00;

            textBoxFTotal.Text = (subTotal - discount).ToString("N");
        }
        
        private void CalculateGridValue()
        {
            if (dgvfrmSale.Rows.Count>0)
            {
                double grandTotal=0;

                for (int ss = 0; ss < dgvfrmSale.Rows.Count; ss++)
                {
                    grandTotal += Convert.ToDouble(dgvfrmSale.Rows[ss].Cells["tempTotal"].Value.ToString());
                }

                textBoxFSubTotal.Text = grandTotal.ToString("N");
            }
            else
            {
                textBoxFSubTotal.Text = "0.00";
            }
        }

        private void ClearSaleTextBox()
        {
            textBoxTradeCode.Clear();
            textBoxTradeName.Clear();
            textBoxUnitPrice.Text = "0";
            textBoxQty.Text = "0";
            textBoxSubTotal.Text = "0";
            textBoxDiscount.Text = "0";
            textBoxGrandTotal.Text = "0";
            labelQty.Text = "";
            textBoxLess.Text = "0";
            labelStoreLocation.Text = "-";
        }
        
        private void SingleCalculate()
        {
            var unitPrice = Convert.ToDouble(textBoxUnitPrice.Text.Trim()) > 0 ? Convert.ToDouble(textBoxUnitPrice.Text.Trim()) : 0;
            var saleQty = Convert.ToDouble(textBoxQty.Text.Trim()) > 0 ? Convert.ToDouble(textBoxQty.Text.Trim()) : 0;
            var discount = Convert.ToDouble(textBoxDiscount.Text.Trim()) > 0 ? Convert.ToDouble(textBoxDiscount.Text.Trim()) : 0;
            
            var subTotal = (unitPrice * saleQty);
            var totalPurchasePrice = purchasePrice * saleQty;
            var per = ((subTotal * discount) / 100);
            var grandTotal = subTotal - per;

            textBoxSubTotal.Text = subTotal.ToString();
            if (grandTotal>=totalPurchasePrice)
            {
                textBoxGrandTotal.Text = grandTotal.ToString();
            }
            else
            {
                textBoxGrandTotal.Text = subTotal.ToString();
                textBoxDiscount.Text = "0";
                textBoxDiscount.SelectAll();
            }

            textBoxLess.MaxLength = Convert.ToInt32(subTotal - totalPurchasePrice);
        }
        // Used Defind Function for Show Stock data from More table
        private void LoadTradeName()
        {
            var query = "SELECT tblStock.*, tblTradeName.TradeName, tblTradeName.RACK_NAME " +
                        "FROM tblStock INNER JOIN tblTradeName ON tblStock.TradeCode=tblTradeName.TradeCode " +
                        "WHERE tblStock.Qty>0 AND tblStock.UnitPrice>0";

            dataGridView1.DataSource = Db.GetDataTable(query);
        }

        private void label19_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
            }
            else
            {
                this.TopMost = true;
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
            }
            else
            {
                this.TopMost = true;
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmSale_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            this.reportViewer1.RefreshReport();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var query = "SELECT tblStock.*, tblTradeName.TradeCode, tblTradeName.TradeName, tblTradeName.RACK_NAME " +
                           "FROM tblStock INNER JOIN tblTradeName ON tblStock.TradeCode=tblTradeName.TradeCode " +
                           "WHERE  tblTradeName.TradeName LIKE ('%" + textBoxTradeName.Text.Trim() +
                           "%') AND tblStock.Qty>0 AND tblStock.UnitPrice>0";

            dataGridView1.DataSource = Db.GetDataTable(query);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = true;
            LoadTradeName();

            ClearSaleTextBox();
        }
        
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUnitPrice.Text = checkBox2.Checked ? wsPrice : salePrice;
            SingleCalculate();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBoxQty.Clear();
        }
        
        private void textBox5_Click(object sender, EventArgs e)
        {
            textBoxDiscount.Clear();
            textBoxLess.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxTradeCode.Text != "")
                {
                    if (Convert.ToDouble(textBoxQty.Text) > 0)
                    {
                        int ss = dgvfrmSale.Rows.Add();
                        dgvfrmSale.Rows[ss].Cells["tempTradeCode"].Value = textBoxTradeCode.Text;
                        dgvfrmSale.Rows[ss].Cells["tempTradeName"].Value = textBoxTradeName.Text;
                        dgvfrmSale.Rows[ss].Cells["tempUnitPrice"].Value = textBoxUnitPrice.Text;
                        dgvfrmSale.Rows[ss].Cells["tempQty"].Value = textBoxQty.Text;
                        dgvfrmSale.Rows[ss].Cells["tempSubTotal"].Value = textBoxSubTotal.Text;
                        dgvfrmSale.Rows[ss].Cells["tempDiscount"].Value = textBoxDiscount.Text;
                        dgvfrmSale.Rows[ss].Cells["tempTotal"].Value = textBoxGrandTotal.Text;
                        dgvfrmSale.Rows[ss].Cells["tempPurchasePrice"].Value = purchasePrice * Convert.ToDouble(textBoxQty.Text);

                        labelTotalItems.Text = dgvfrmSale.RowCount.ToString();

                        CalculateGridValue();
                        DiscountCalculate();
                        AdjustmentCalculate();
                        PaymentCalculate();

                        ClearSaleTextBox();
                    }
                    else
                    {
                        MessageBox.Show("Please enter quantity", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select Trade Name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvfrmSale_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvfrmSale.Rows[e.RowIndex].Cells["tempSL"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvfrmSale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvfrmSale.Rows.Count > 0)
                {
                    btnCancel.Visible = true;
                    btnDelete.Visible = true;
                    btnAdd.Visible = false;

                    gridIndex = e.RowIndex;
                    label17.Text = dgvfrmSale.Rows[e.RowIndex].Cells["tempTradeName"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                dgvfrmSale.Rows.RemoveAt(gridIndex);
                
                labelTotalItems.Text = dgvfrmSale.RowCount.ToString();

                CalculateGridValue();
                DiscountCalculate();
                AdjustmentCalculate();
                PaymentCalculate();

                gridIndex = 0;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                btnAdd.Visible = true;
                label17.Text = "-";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gridIndex = 0;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;
            label17.Text = "-";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxFDiscount.Text) >= 0)
                {
                    if (Convert.ToDouble(textBoxFDiscount.Text.Trim()) <= Convert.ToDouble(textBoxFSubTotal.Text))
                    {
                        DiscountCalculate();
                        AdjustmentCalculate();
                        PaymentCalculate();
                    }
                    else
                    {
                        textBoxFDiscount.Text = "0.00";
                        textBoxFDiscount.SelectAll();
                    }
                }
            }
            catch
            {
                textBoxFDiscount.Text = "0.00";
                textBoxFDiscount.SelectAll();
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxFPayment.Text) >= 0)
                {
                    PaymentCalculate();
                }
            }
            catch
            {
                textBoxFPayment.Text = "0.00";
                textBoxFPayment.SelectAll();
            }
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            textBoxFDiscount.SelectAll();
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            textBoxFPayment.SelectAll();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnAdd.Visible)
            {
                if (e.KeyCode==Keys.Enter)
                {
                    btnAdd.PerformClick();
                    textBoxTradeName.Focus();
                }
            }
        }
        
        private void SaleReport(string saleInvoice)
        {
            try
            {

                SetSaleInvoiceSize();
                reportViewer1.LocalReport.DataSources.Clear();

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("pInvoiceNo", labelSaleInvoice.Text));
                parameterCollection.Add(new ReportParameter("pPatientId", textBoxPatientId.Text));
                parameterCollection.Add(new ReportParameter("pSalesMan", GlobalSettings.UserName));
                //parameterCollection.Add(new ReportParameter("pSaleDate", DateTime.Now.ToShortDateString()));
                //parameterCollection.Add(new ReportParameter("pSaleTime", DateTime.Now.ToShortTimeString()));
                reportViewer1.LocalReport.SetParameters(parameterCollection);

                var query =
                    "SELECT tblSaleDetails.id, tblSaleDetails.Qty,tblSaleDetails.UnitPrice,tblSaleDetails.Discount, tblSaleDetails.Total, tblTradeName.TradeName " +
                    "FROM tblSaleDetails INNER JOIN tblTradeName ON tblSaleDetails.TradeCode = tblTradeName.TradeCode " +
                    "WHERE InvNo='" + saleInvoice + "'";

                var query1 =
                    "SELECT InvNo, Payment, Total, Adjustment, GrandTotal, Discount, SubTotal, SaleDate, SaleTime, UserName, Refund, TotalDue " +
                    "FROM tblSaleMaster " +
                    "WHERE InvNo='" + saleInvoice + "'";

                ReportDataSource patientInfo=new ReportDataSource("PatientInformation", Db.GetDataTable("SELECT PatientID, PatientName, Address, MobileNo FROM tblSaleMaster WHERE InvNo='"+saleInvoice+"'"));
                ReportDataSource sale = new ReportDataSource("Sale", Db.GetDataTable(query));
                ReportDataSource saleMaster = new ReportDataSource("SaleMaster", Db.GetDataTable(query1));
                ReportDataSource officeDetailsDataSource = new ReportDataSource("OfficeDetails", GlobalSettings.OfficeInfo);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(patientInfo);
                reportViewer1.LocalReport.DataSources.Add(sale);
                reportViewer1.LocalReport.DataSources.Add(saleMaster);
                reportViewer1.LocalReport.DataSources.Add(officeDetailsDataSource);

                reportViewer1.RefreshReport();
                
            }
            catch
            {
                reportViewer1.LocalReport.DataSources.Clear();
            }
            
        }
        
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reportViewer1.CurrentStatus.CanPrint)
            {
                reportViewer1.PrintDialog();
            }
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonSale.PerformClick();
        }
        
        private void textBoxSaleInvoice2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonSearch.PerformClick();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SaleReport(textBoxSaleInvoice1.Text + textBoxSaleInvoice2.Text.Trim());
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dr = Db.GetDataReader("SELECT * FROM tblSaleMaster WHERE MobileNo='" + textBoxMobile.Text.Trim() + "'");
                if (dr.HasRows)
                {
                    dr.Read();
                    textBoxPatientId.Text = dr["PatientID"].ToString();
                    textBoxPatientName.Text = dr["PatientName"].ToString();
                    textBoxAddress.Text = dr["Address"].ToString();
                    dr.Close();
                }
                else
                {
                    textBoxPatientId.Clear();
                    textBoxPatientName.Clear();
                    textBoxAddress.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TradeAndStockDetails();
        }
        
        private void textBoxTradeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                TradeAndStockDetails();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TradeAndStockDetails();
            }
        }

        private void buttonSale_Click(object sender, EventArgs e)
        {
            if (dgvfrmSale.RowCount > 0)
            {
                GenerateInvoice();

                InsertSaleDetails();
                InsertSaleMaster();

                dgvfrmSale.Rows.Clear();

                if (checkBoxPrintSaleReport.Checked)
                {
                    reportViewer1.BringToFront();
                    reportViewer1.Visible = true;
                    SaleReport(labelSaleInvoice.Text);
                }

                textBoxFSubTotal.Text = "0.00";
                textBoxFDiscount.Text = "0.00";
                textBoxFTotal.Text = "0.00";
                textBoxFAdjustment.Text = "0.00";
                textBoxFPayment.Text = "0.00";
                textBoxFDue.Text = "0.00";
                textBoxFChange.Text = "0.00";

                labelTotalItems.Text = "0";

                GenerateInvoice();
            }
        }

        private void textBoxLess_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var lessAmt = Convert.ToDouble(textBoxLess.Text.Trim());
                var subTotal = Convert.ToDouble(textBoxSubTotal.Text);
                var withLess = subTotal-lessAmt;
                if (lessAmt <=textBoxLess.MaxLength)
                {
                    var dis = ((subTotal - withLess) * 100) / subTotal;
                    textBoxDiscount.Text = dis.ToString("N");
                }
                else
                {
                    textBoxLess.Text = "0";
                    textBoxLess.SelectAll();
                    SingleCalculate();
                }
                
            }
            catch (Exception ex)
            {
                textBoxLess.Text = "0";
                textBoxLess.SelectAll();
            }
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxDiscount.Text) >= 0)
                {
                    SingleCalculate();
                }
                else
                {
                    textBoxDiscount.Text = "0";
                    textBoxDiscount.SelectAll();
                }
            }
            catch
            {
                textBoxDiscount.Text = "0";
                textBoxDiscount.SelectAll();
            }
        }

        private void textBoxQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxQty.Text) > 0)
                {
                    if (Convert.ToDouble(textBoxQty.Text.Trim()) <= Convert.ToDouble(labelQty.Text))
                    {
                        SingleCalculate();
                    }
                    else
                    {
                        textBoxQty.Text = labelQty.Text;
                        textBoxQty.SelectAll();
                    }
                }
                else
                {
                    textBoxSubTotal.Text = "0";
                }
            }
            catch
            {
                textBoxGrandTotal.Text = "0";
                textBoxQty.Text = "0";
                textBoxQty.SelectAll();
            }
        }

        private void textBoxLess_Click(object sender, EventArgs e)
        {
            textBoxLess.SelectAll();
            textBoxDiscount.Text = "0";
        }

        private void textBoxFAdjustment_TextChanged(object sender, EventArgs e)
        {
            AdjustmentCalculate();
            PaymentCalculate();
        }

        private void textBoxFAdjustment_Click(object sender, EventArgs e)
        {
            textBoxFAdjustment.SelectAll();
        }

        private void labelTradeClose_Click(object sender, EventArgs e)
        {
            panelTrade.Visible = false;
        }
        
    }
}
