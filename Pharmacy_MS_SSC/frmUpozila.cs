using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmUpozila : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private int zillaId = 0;
        private int upazilaId = 0;
        public frmUpozila()
        {
            InitializeComponent();

            LoadUpazilaList();
        }

        private void LoadZilaList()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblZilla", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridViewZillaList.DataSource = dt;
            }

        }

        private void LoadUpazilaList()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT tblUpozila.id AS upazilaId, tblUpozila.Name, tblZilla.id AS zillaID, tblZilla.name AS zillaName FROM tblUpozila INNER JOIN tblZilla ON tblUpozila.ZillaId=tblZilla.id", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridViewUpazilaList.DataSource = dt;
            }

            labelTotal.Text = dataGridViewUpazilaList.Rows.Count.ToString();
        }

        private bool FindUpazila(string upazilaName)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblUpozila WHERE Name='" + upazilaName + "' AND ZillaId='"+zillaId+"'", conn);
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

        private void textBoxZillaName_Click(object sender, EventArgs e)
        {
            panelZila.Visible = true;
            LoadZilaList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxUpazilaName.Text != "")
                {
                    if (!FindUpazila(textBoxUpazilaName.Text.Trim()))
                    {
                        switch (buttonSave.Text)
                        {
                            case "Save":
                                {
                                    conn.Close();
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tblUpozila VALUES ('" + textBoxUpazilaName.Text.Trim() + "','" + zillaId + "')", conn);
                                    cmd.ExecuteNonQuery();
                                    break;
                                }
                            case "Update":
                                {
                                    conn.Close();
                                    conn.Open();
                                    SqlCommand cmd1 = new SqlCommand("UPDATE tblUpozila SET Name='" + textBoxUpazilaName.Text.Trim() + "', ZillaId='"+zillaId+"' WHERE id='" + upazilaId + "'", conn);
                                    cmd1.ExecuteNonQuery();
                                    buttonSave.Text = "Save";
                                    break;
                                }
                        }

                        LoadUpazilaList();

                        textBoxUpazilaName.Clear();
                        textBoxUpazilaName.Focus();
                    }
                    else
                    {
                        MessageBox.Show(textBoxUpazilaName.Text + " Upazila Already Exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Upazila Nmae...", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewZillaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewZillaList.Rows[e.RowIndex].Cells["sl"].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewZillaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxZillaName.Text = dataGridViewZillaList.Rows[e.RowIndex].Cells["name"].Value.ToString();
            zillaId = Convert.ToInt32(dataGridViewZillaList.Rows[e.RowIndex].Cells["id"].Value.ToString());
            panelZila.Visible = false;
            textBoxUpazilaName.ReadOnly = false;
            textBoxUpazilaName.Focus();
        }

        private void textBoxUpazilaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSave.PerformClick();
            }
        }

        private void dataGridViewUpazilaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUpazilaList.Rows[e.RowIndex].Cells["usl"].Value = (e.RowIndex + 1).ToString();

        }

        private void dataGridViewUpazilaList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxZillaName.Text = dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uZilla"].Value.ToString();
            zillaId = Convert.ToInt32(dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uZillaId"].Value.ToString());
            textBoxUpazilaName.Text = dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uName"].Value.ToString();
            upazilaId = Convert.ToInt32(dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uId"].Value.ToString());
            buttonSave.Text = "Update";
            textBoxUpazilaName.ReadOnly = false;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;

            frmZilla zilla=new frmZilla();
            zilla.ShowDialog();


        }

        private void labelZilaClose_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
        }

    }
}
