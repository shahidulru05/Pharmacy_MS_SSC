using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmVillage : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private int zillaId = 0;
        private int upazilaId = 0;
        private int unionId = 0;
        private int villageId = 0;

        public frmVillage()
        {
            InitializeComponent();

            LoadVillageList();
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
                "WHERE tblUpozila.ZillaId='" + zillaId + "'";
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
                "SELECT tblUnion.*, tblUpozila.Name AS upazilaName " +
                "FROM tblUnion INNER JOIN tblUpozila " +
                "ON tblUnion.UpozilaId=tblUpozila.id " +
                "WHERE tblUnion.UpozilaId='" + upazilaId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewUnionList.DataSource = dt;
        }

        private bool FindVillage()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblVillage WHERE Name='" + textBoxVillageName.Text.Trim() + "' AND UnionId='" + unionId + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows.Count > 0;
        }

        private void LoadVillageList()
        {
            conn.Close();
            conn.Open();
            string query =
                "SELECT tblVillage.*,tblUnion.Name AS unionName, tblUpozila.Name AS upazilaName, tblZilla.Name AS zillaName " +
                "FROM tblVillage INNER JOIN tblUnion " +
                "ON tblVillage.UnionId=tblUnion.id " +
                "INNER JOIN tblUpozila " +
                "ON tblUnion.UpozilaId=tblUpozila.id " +
                "INNER JOIN tblZilla " +
                "ON tblUpozila.ZillaId=tblZilla.id ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewVillageList.DataSource = dt;

            labelTotal.Text = dataGridViewVillageList.Rows.Count.ToString();
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

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;

            frmZilla zilla=new frmZilla();
            zilla.ShowDialog();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;

            frmUpozila upozila=new frmUpozila();
            upozila.ShowDialog();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;

            frmUnion union=new frmUnion();
            union.ShowDialog();
        }

        private void textBoxZillaName_Click(object sender, EventArgs e)
        {
            panelZila.Visible = true;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;
            LoadZilaList();
        }

        private void textBoxUpazilaName_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = true;
            panelUnion.Visible = false;
            LoadUpazilaList();
        }

        private void textBoxUnionName_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = true;
            LoadUnionList();
        }

        private void dataGridViewZillaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxZillaName.Text = dataGridViewZillaList.Rows[e.RowIndex].Cells["name"].Value.ToString();
            zillaId = Convert.ToInt32(dataGridViewZillaList.Rows[e.RowIndex].Cells["id"].Value.ToString());
            panelZila.Visible = false;
            textBoxUpazilaName.Clear();
            textBoxUnionName.Clear();
            textBoxVillageName.Clear();
            textBoxUpazilaName.Focus();
        }

        private void dataGridViewUpazilaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxUpazilaName.Text = dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uName"].Value.ToString();
            upazilaId = Convert.ToInt32(dataGridViewUpazilaList.Rows[e.RowIndex].Cells["uId"].Value.ToString());
            panelUpazila.Visible = false;
            textBoxVillageName.Clear();
            textBoxUnionName.Clear();
            textBoxUnionName.Focus();
        }

        private void dataGridViewUnionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxUnionName.Text = dataGridViewUnionList.Rows[e.RowIndex].Cells["unUnionName"].Value.ToString();
            unionId = Convert.ToInt32(dataGridViewUnionList.Rows[e.RowIndex].Cells["unId"].Value.ToString());
            panelUnion.Visible = false;
            textBoxVillageName.Clear();
            textBoxVillageName.ReadOnly = false;
            textBoxVillageName.Focus();
        }

        private void dataGridViewZillaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewZillaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewUpazilaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUpazilaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewUnionList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUnionList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewVillageList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewVillageList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                panelZila.Visible = false;
                panelUpazila.Visible = false;
                panelUnion.Visible = false;
                
                if (textBoxVillageName.Text != "")
                {
                    if (!FindVillage())
                    {
                        switch (buttonSave.Text)
                        {
                            case "Save":
                                {
                                    conn.Close();
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tblVillage VALUES ('" + textBoxVillageName.Text.Trim() + "','" + unionId + "')", conn);
                                    cmd.ExecuteNonQuery();
                                    break;
                                }
                            case "Update":
                                {
                                    conn.Close();
                                    conn.Open();
                                    SqlCommand cmd1 = new SqlCommand("UPDATE tblVillage SET Name='" + textBoxVillageName.Text.Trim() + "', UnionId='" + unionId + "' WHERE id='" + villageId + "'", conn);
                                    cmd1.ExecuteNonQuery();
                                    buttonSave.Text = "Save";
                                    textBoxZillaName.Clear();
                                    textBoxUpazilaName.Clear();
                                    textBoxUnionName.Clear();
                                    break;
                                }
                        }

                        LoadVillageList();

                        textBoxVillageName.Clear();
                        textBoxVillageName.Focus();
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

        private void dataGridViewVillageList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxZillaName.Text = dataGridViewVillageList.Rows[e.RowIndex].Cells["vlZillaName"].Value.ToString();
            textBoxUpazilaName.Text = dataGridViewVillageList.Rows[e.RowIndex].Cells["vlUpazilaName"].Value.ToString();
            textBoxUnionName.Text = dataGridViewVillageList.Rows[e.RowIndex].Cells["vlUnionName"].Value.ToString();
            textBoxVillageName.Text = dataGridViewVillageList.Rows[e.RowIndex].Cells["vlVillageName"].Value.ToString();
            villageId = Convert.ToInt32(dataGridViewVillageList.Rows[e.RowIndex].Cells["vlid"].Value.ToString());
            unionId = Convert.ToInt32(dataGridViewVillageList.Rows[e.RowIndex].Cells["vlUnionId"].Value.ToString());

            buttonSave.Text = "Update";
            textBoxVillageName.Focus();
            textBoxVillageName.ReadOnly = false;
        }

        private void textBoxVillageName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonSave.PerformClick();
            }
        }

        private void dataGridViewZillaList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labelZilaClose_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
        }

        private void labelUpazilaClose_Click(object sender, EventArgs e)
        {
            panelUpazila.Visible = false;
        }

        private void labelUnionClose_Click(object sender, EventArgs e)
        {
            panelUnion.Visible = false;
        }
    }
}
