using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmUnion : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private int zillaId = 0;
        private int upazilaId = 0;
        private int unionId = 0;

        public frmUnion()
        {
            InitializeComponent();

            LoadUnionList();
        }

        private void LoadZilaList()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblZilla", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewZillaList.DataSource = dt;
        }

        private void LoadUpazilaList()
        {
            conn.Close();
            conn.Open();
            string query =
                "SELECT tblUpozila.id AS upazilaId, tblUpozila.Name, tblZilla.id AS zillaID, tblZilla.name AS zillaName " +
                "FROM tblUpozila INNER JOIN tblZilla " +
                "ON tblUpozila.ZillaId=tblZilla.id " +
                "WHERE tblUpozila.ZillaId='"+zillaId+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewUpazilaList.DataSource = dt;
        }

        private void LoadUnionList()
        {
            conn.Close();
            conn.Open();
            string query =
                "SELECT tblUnion.*, tblUpozila.Name AS upazilaName, tblUpozila.ZillaId, tblZilla.Name AS zillaName " +
                "FROM tblUnion INNER JOIN tblUpozila ON tblUnion.UpozilaId = tblUpozila.id "+
                "INNER JOIN tblZilla ON tblUpozila.ZillaId = tblZilla.id ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewUnionList.DataSource = dt;

            labelTotal.Text = dataGridViewUnionList.Rows.Count.ToString();
        }

        private bool FindUnion(string unionName)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblUnion WHERE Name='" + unionName + "' AND UpozilaId='" + upazilaId + "'", conn);
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
            dataGridViewZillaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void textBoxZillaName_Click(object sender, EventArgs e)
        {
            panelZila.Visible = true;
            panelUpazila.Visible = false;
            LoadZilaList();
        }
        
        private void dataGridViewZillaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxZillaName.Text = dataGridViewZillaList.Rows[e.RowIndex].Cells["name"].Value.ToString();
            zillaId = Convert.ToInt32(dataGridViewZillaList.Rows[e.RowIndex].Cells["id"].Value.ToString());
            panelZila.Visible = false;
            textBoxUpazilaName.Clear();
            textBoxUnionName.Clear();
            textBoxUpazilaName.Focus();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            frmZilla zilla=new frmZilla();
            zilla.ShowDialog();
        }

        private void textBoxUpazilaName_Click(object sender, EventArgs e)
        {
            panelUpazila.Visible = true;
            LoadUpazilaList();
        }

        private void dataGridViewUpazilaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxUpazilaName.Text = dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uName"].Value.ToString();
            upazilaId = Convert.ToInt32(dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uId"].Value.ToString());
            panelUpazila.Visible = false;
            textBoxUnionName.Clear();
            textBoxUnionName.ReadOnly = false;
            textBoxUnionName.Focus();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            frmUpozila upozila=new frmUpozila();
            upozila.ShowDialog();
        }

        private void dataGridViewUpazilaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUpazilaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewUnionList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUnionList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewUnionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxZillaName.Text = dataGridViewUnionList.Rows[e.RowIndex].Cells["unZillaName"].Value.ToString();
            zillaId = Convert.ToInt32(dataGridViewUnionList.Rows[e.RowIndex].Cells["unZillaId"].Value.ToString());
            textBoxUpazilaName.Text = dataGridViewUnionList.Rows[e.RowIndex].Cells["unUpazalaName"].Value.ToString();
            upazilaId = Convert.ToInt32(dataGridViewUnionList.Rows[e.RowIndex].Cells["unUpazilaId"].Value.ToString());
            textBoxUnionName.Text = dataGridViewUnionList.Rows[e.RowIndex].Cells["unUnionName"].Value.ToString();
            unionId = Convert.ToInt32(dataGridViewUnionList.Rows[e.RowIndex].Cells["unId"].Value.ToString());
            
            buttonSave.Text = "Update";
            textBoxUnionName.ReadOnly = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxUnionName.Text != "")
                {
                    if (!FindUnion(textBoxUnionName.Text.Trim()))
                    {
                        switch (buttonSave.Text)
                        {
                            case "Save":
                                {
                                    conn.Close();
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tblUnion VALUES ('" + textBoxUnionName.Text.Trim() + "','" + upazilaId + "')", conn);
                                    cmd.ExecuteNonQuery();
                                    break;
                                }
                            case "Update":
                                {
                                    conn.Close();
                                    conn.Open();
                                    SqlCommand cmd1 = new SqlCommand("UPDATE tblUnion SET Name='" + textBoxUnionName.Text.Trim() + "', UpozilaId='" + upazilaId + "' WHERE id='" + unionId + "'", conn);
                                    cmd1.ExecuteNonQuery();
                                    buttonSave.Text = "Save";
                                    break;
                                }
                        }

                        LoadUnionList();

                        textBoxUnionName.Clear();
                        textBoxUnionName.Focus();
                    }
                    else
                    {
                        MessageBox.Show(textBoxUnionName.Text + " Union Already Exist", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Union Nmae...", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void textBoxUnionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSave.PerformClick();
            }
        }

        private void labelZilaClose_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
        }

        private void labelUpazilaClose_Click(object sender, EventArgs e)
        {
            panelUpazila.Visible = false;
        }
    }
}
