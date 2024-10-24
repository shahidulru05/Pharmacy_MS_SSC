using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmGateway : Form
    {

        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private int gatewayTableId;

        public frmGateway()
        {
            InitializeComponent();

            LoadGatewayList();
        }

        private void LoadGatewayList()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblPayGateway",conn);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }
        private bool GateByName(string name)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblPayGateway WHERE Name='" + name + "'",conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr.Read();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxGatewayName.Text!="")
                {
                    if (!GateByName(textBoxGatewayName.Text.Trim()))
                    {
                        conn.Close();
                        conn.Open();
                        SqlCommand cmd =new SqlCommand("INSERT INTO tblPayGateway VALUES ('" + textBoxGatewayName.Text.Trim() + "')", conn);
                        var isSaved = cmd.ExecuteNonQuery();
                        if (isSaved>0)
                        {
                            LoadGatewayList();
                        }
                    }
                    else
                    {
                        MessageBox.Show(textBoxGatewayName.Text+" gateway is already exist /n please try another and try again","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxGatewayName.Text != "")
                {
                    if (!GateByName(textBoxGatewayName.Text.Trim()))
                    {
                        conn.Close();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE tblPayGateway SET Name = '" + textBoxGatewayName.Text.Trim() + "' WHERE Id='" + gatewayTableId + "'", conn);
                        var isUpdate = cmd.ExecuteNonQuery();
                        if (isUpdate > 0)
                        {
                            LoadGatewayList();
                            buttonUpdate.Visible = false;
                            buttonSave.Visible = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(textBoxGatewayName.Text + " gateway is already exist /n please try another and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.RowCount>0)
                {
                    gatewayTableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["gatewayId"].Value.ToString());
                    textBoxGatewayName.Text = dataGridView1.Rows[e.RowIndex].Cells["gatewayName"].Value.ToString();

                    buttonUpdate.Visible = true;
                    buttonSave.Visible = false;
                }
            }
            catch
            {
                gatewayTableId = 0;
                textBoxGatewayName.Clear();
                buttonUpdate.Visible = false;
                buttonSave.Visible = true;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["sl"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
