using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmZilla : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private int zillaID = 0;

        public frmZilla()
        {
            InitializeComponent();

            LoadZilaList();
        }

        private void LoadZilaList()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblZilla",conn);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                dataGridViewZillaList.DataSource = dt;
            }

            labelTotal.Text = dataGridViewZillaList.Rows.Count.ToString();
        }

        private bool FindZilla(string zillaName)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblZilla WHERE Name='"+zillaName+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count > 0;
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

        private void dataGridViewZillaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewZillaList.Rows[e.RowIndex].Cells["sl"].Value = (e.RowIndex + 1).ToString();
        }

        private void textBoxZillaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSave.PerformClick();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxZillaName.Text != "")
                {
                    if (!FindZilla(textBoxZillaName.Text.Trim()))
                    {
                        switch (buttonSave.Text)
                        {
                            case "Save":
                            {
                                conn.Close();
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("INSERT INTO tblZilla VALUES ('" + textBoxZillaName.Text.Trim() + "')", conn);
                                cmd.ExecuteNonQuery();
                                break;
                            }
                            case "Update":
                            {
                                conn.Close();
                                conn.Open();
                                SqlCommand cmd1 = new SqlCommand("UPDATE tblZilla SET Name='" + textBoxZillaName.Text.Trim() + "' WHERE id='"+zillaID+"'", conn);
                                cmd1.ExecuteNonQuery();
                                buttonSave.Text = "Save";
                                break;
                            }
                        } 

                        LoadZilaList();

                        textBoxZillaName.Clear();
                        textBoxZillaName.Focus();
                    }
                    else
                    {
                        MessageBox.Show(textBoxZillaName.Text + " Zilla Already Exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Zilla Nmae...", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewZillaList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxZillaName.Text = dataGridViewZillaList.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            zillaID = Convert.ToInt32(dataGridViewZillaList.Rows[e.RowIndex].Cells["id"].Value.ToString());
            buttonSave.Text = "Update";
        }
    }
}
