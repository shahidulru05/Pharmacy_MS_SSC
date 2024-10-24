using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmExpense : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private SqlDataReader dr;

        public frmExpense()
        {
            InitializeComponent();

            GenerateInvoice();
            LoadExpenseTemp();
        }

        private void GenerateInvoice()
        {
            try
            {
                var year = Settings.Default.CURRENT_PERIOD;
                string defaultInvoice = "EX-" + year + "1";
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT INV_NO FROM tblExpense WHERE id = (SELECT MAX(id) AS ID FROM tblExpense)", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() && !dr.IsDBNull(0))
                {
                    var db_invoice = dr["INV_NO"].ToString();
                    var db_inv_year = db_invoice.Substring(3, 4);
                    labelInvoiceNo.Text = Convert.ToInt32(db_inv_year) < Convert.ToInt32(year)
                        ? defaultInvoice
                        : new AutoGenerateInvoice().Invoice(db_invoice, "EX-" + year, 1);
                }
                else
                {
                    labelInvoiceNo.Text = defaultInvoice;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExpenseTemp()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT tblExpense_temp.*, tblPayGateway.Name FROM tblExpense_temp INNER JOIN tblPayGateway ON tblExpense_temp.PayGatewayId = tblPayGateway.Id WHERE UserName='" + GlobalSettings.UserName + "'", conn);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count>0)
            {
                dataGridViewTemp.DataSource = dt;
                buttonFinalPosting.Visible = true;
            }
            else
            {
                dataGridViewTemp.DataSource = dt;
                buttonFinalPosting.Visible = false;
            }

            labelExpenseCount.Text = dataGridViewTemp.RowCount.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }
        
        private void frmExpense_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewGateway.DataSource = Db.GetDataTable("SELECT * FROM tblPayGateway");
                panelGateway.Visible = true;
            }
            catch 
            {
                panelGateway.Visible = false;
            }
        }

        private void dataGridViewGateway_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gatewayId = Convert.ToInt32(dataGridViewGateway.Rows[e.RowIndex].Cells["gatewayId1"].Value);
                textBox1.Text = dataGridViewGateway.Rows[e.RowIndex].Cells["gatewayName1"].Value.ToString();
                panelGateway.Visible = false;
            }
            catch
            {
                panelGateway.Visible = false;
            }
        }

        private void dataGridViewGateway_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewGateway.Rows[e.RowIndex].Cells["sl1"].Value = (e.RowIndex + 1).ToString();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            frmGateway gateway=new frmGateway();
            gateway.TopMost = true;
            gateway.ShowDialog();
        }

        int gatewayId;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && richTextBox1.Text!="" && gatewayId!=0)
                {
                    conn.Close();
                    conn.Open();
                    string query = "INSERT INTO tblExpense_temp(Date,PayGatewayId,Amount,Person,Description, UserName)VALUES('" + dateTimePicker4.Value.ToString("M/d/yyyy") + "','" + gatewayId + "','" + double.Parse(textBox2.Text.Trim()) + "','" + textBox3.Text.Trim() + "','" + richTextBox1.Text.Trim() + "','" + GlobalSettings.UserName + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var isSaved = cmd.ExecuteNonQuery();
                    if (isSaved>0)
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        richTextBox1.Clear();
                        gatewayId = 0;
                    }
                    LoadExpenseTemp();
                }
                else
                {
                    MessageBox.Show("Pleaswe fill all field's and try again","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewTemp_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewTemp.Rows[e.RowIndex].Cells["SL"].Value = (e.RowIndex + 1).ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && richTextBox1.Text != "" && gatewayId != 0)
                {
                    conn.Close();
                    conn.Open();
                    string query = "UPDATE tblExpense_temp SET Date= '" + dateTimePicker4.Value.ToShortDateString() + "', PayGatewayId= '" + gatewayId + "',Amount= '" + double.Parse(textBox2.Text.Trim()) + "',Person= '" + textBox3.Text.Trim() + "',Description= '" + richTextBox1.Text.Trim() + "', UserName= '" + GlobalSettings.UserName + "' WHERE ID='"+getTempId+"'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var isUpdate = cmd.ExecuteNonQuery();
                    if (isUpdate > 0)
                    {
                        gatewayId = 0;
                        getTempId = 0;
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        buttonAdd.Visible = true;
                        buttonUpdate.Visible = false;
                        buttonDelete.Visible = false;
                        buttonCancel.Visible = false;
                        LoadExpenseTemp();
                    }
                    LoadExpenseTemp();
                }
                else
                {
                    MessageBox.Show("Pleaswe fill all field's and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int getTempId;
        private void dataGridViewTemp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewTemp.RowCount>0)
                {
                    getTempId = Convert.ToInt32(dataGridViewTemp.Rows[e.RowIndex].Cells["tempId"].Value.ToString());
                    dateTimePicker4.Text = dataGridViewTemp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    gatewayId = Convert.ToInt32(dataGridViewTemp.Rows[e.RowIndex].Cells["PayGatewayId"].Value.ToString());
                    textBox1.Text = dataGridViewTemp.Rows[e.RowIndex].Cells["PayGateway"].Value.ToString();
                    textBox2.Text = dataGridViewTemp.Rows[e.RowIndex].Cells["Amount"].Value.ToString();
                    textBox3.Text = dataGridViewTemp.Rows[e.RowIndex].Cells["Person"].Value.ToString();
                    richTextBox1.Text = dataGridViewTemp.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                    panelGateway.Visible = false;
                    buttonAdd.Visible = false;
                    buttonUpdate.Visible = true;
                    buttonDelete.Visible = true;
                    buttonCancel.Visible = true;
                }
                else
                {
                    getTempId = 0;
                    gatewayId = 0;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    richTextBox1.Clear();
                }
            }
            catch 
            {
                getTempId = 0;
                gatewayId = 0;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Clear();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            gatewayId = 0;
            getTempId = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            buttonAdd.Visible = true;
            buttonUpdate.Visible = false;
            buttonDelete.Visible = false;
            buttonCancel.Visible = false;
            LoadExpenseTemp();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE tblExpense_temp WHERE ID='" + getTempId + "'", conn);
                var isDelete = cmd.ExecuteNonQuery();
                if (isDelete > 0)
                {
                    gatewayId = 0;
                    getTempId = 0;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    buttonAdd.Visible = true;
                    buttonUpdate.Visible = false;
                    buttonDelete.Visible = false;
                    buttonCancel.Visible = false;
                    LoadExpenseTemp();
                }

                LoadExpenseTemp();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonFinalPosting_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTemp.RowCount>0)
                {
                    var dg = dataGridViewTemp;
                    var query = "";
                    var queryDelete = "";
                    var queryStatement = "";
                    double debit = 0;

                    for (var i = 0; i < dg.RowCount; i++)
                    {
                        query +=
                            "INSERT INTO tblExpense(INV_NO, Date,PayGatewayId,Amount,Person,Description, UserName)VALUES('"+labelInvoiceNo.Text+"','" +
                            Convert.ToDateTime(dg.Rows[i].Cells["Date"].Value).ToString("M/d/yyyy") + "','" + dg.Rows[i].Cells["PayGatewayId"].Value + "','" +
                            Convert.ToDouble(dg.Rows[i].Cells["Amount"].Value) + "','" + dg.Rows[i].Cells["Person"].Value + "','" +
                            dg.Rows[i].Cells["Description"].Value + "','" + dg.Rows[i].Cells["UserName"].Value + "')";
                        
                        queryDelete +="DELETE tblExpense_temp WHERE ID='"+dg.Rows[i].Cells["tempId"].Value+"'";
                    }

                    GenerateInvoice();
                    conn.Close();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    var isSaved = cmd.ExecuteNonQuery();
                    if (isSaved>0)
                    {
                        conn.Close();
                        conn.Open();
                        cmd = new SqlCommand(queryDelete, conn);
                        var isDelete = cmd.ExecuteNonQuery();
                        if (isDelete>0)
                        {
                            gatewayId = 0;
                            getTempId = 0;
                            buttonAdd.Visible = true;
                            buttonUpdate.Visible = false;
                            buttonDelete.Visible = false;
                            buttonCancel.Visible = false;
                        }

                    }


                }

                GenerateInvoice();
                LoadExpenseTemp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==46 && textBox2.Text.IndexOf(".")!=-1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar!=46)
            {
                e.Handled = true;
            }
        }

        private void labelGatwayClose_Click(object sender, EventArgs e)
        {
            panelGateway.Visible = false;
        }

    }
}
