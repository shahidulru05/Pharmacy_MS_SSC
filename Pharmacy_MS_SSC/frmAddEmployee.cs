using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using Pharmacy_MS_SSC.Properties;

namespace Pharmacy_MS_SSC
{
    public partial class frmAddEmployee : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());


        public frmAddEmployee()
        {
            InitializeComponent();
            textBox1.Text = CustEmpIDGenerate();
            LoadEmpinfoToGrid();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
        // Used Defind Function for Auto Generate Bill No_Dish
        private string CustEmpIDGenerate()
        {
            conn.Close();
            SqlCommand cmd = new SqlCommand("SELECT EmpId FROM tblEmployeeinfo ORDER BY id  DESC");
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                string BillNo = sdr["EmpId"].ToString();
                int lastint = int.Parse(BillNo.Substring(1, 4)) + 1;
                sdr.Close();
                return "E" + lastint.ToString("0000");
            }
            else
            {
                sdr.Close();
                conn.Close();
                return "E0001";
            }
        }

        //User Defind function for View Data created by Babu
        private void LoadVillageToGrid()
        {
            dataGridViewVillageList.Rows.Clear();
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblVillage WHERE UnionId='" + unionID + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int i = dataGridViewVillageList.Rows.Add();
                dataGridViewVillageList.Rows[i].Cells[1].Value = dr["id"].ToString();
                dataGridViewVillageList.Rows[i].Cells[2].Value = dr["Name"].ToString();
            }
        }
        //User Defind function for View Data created by Babu
        private void LoadUpozilaToGrid()
        {
            dataGridViewUpazilaList.Rows.Clear();
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblUpozila WHERE ZillaId='"+zillaID+"'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int i = dataGridViewUpazilaList.Rows.Add();
                dataGridViewUpazilaList.Rows[i].Cells[1].Value = dr["id"].ToString();
                dataGridViewUpazilaList.Rows[i].Cells[2].Value = dr["Name"].ToString();
            }
        }
        //User Defind function for View Data created by Babu
        private void LoadZilaToGrid()
        {
            dataGridViewZillaList.Rows.Clear();
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblZilla", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int i = dataGridViewZillaList.Rows.Add();
                dataGridViewZillaList.Rows[i].Cells[1].Value = dr["id"].ToString();
                dataGridViewZillaList.Rows[i].Cells[2].Value = dr["Name"].ToString();
            }
        }
        //User Defind function for View Data created by Babu
        private void LoadUnionToGrid()
        {
            dataGridViewUnionList.Rows.Clear();
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblUnion WHERE UpozilaId='"+upazilaID+"'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int i = dataGridViewUnionList.Rows.Add();
                dataGridViewUnionList.Rows[i].Cells[1].Value = dr["id"].ToString();
                dataGridViewUnionList.Rows[i].Cells[2].Value = dr["Name"].ToString();
            }
        }

        //User Defind function for View Data created by Babu
        private void LoadDesignationToGrid()
        {
            try
            {
                conn.Close();
                dataGridView5.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDesignation");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView5.Rows.Add();
                    dataGridView5.Rows[i].Cells[1].Value = ord["id"].ToString();
                    dataGridView5.Rows[i].Cells[2].Value = ord["Name"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Program Error in LoadDesignationToGrid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //User Defind function for View Data created by Babu
        private void LoadEmpinfoToGrid()
        {
            try
            {
                conn.Close();
                conn.Open();
                dataGridView1.Rows.Clear();
                string query =
                    "SELECT tblEmployeeinfo.id, tblEmployeeinfo.EmpId, tblEmployeeinfo.Name, tblEmployeeinfo.FName, tblEmployeeinfo.MobileNo, " +
                    "tblEmployeeinfo.Status, tblVillage.Name AS villageName, tblUpozila.Name AS upazilaName, tblZilla.Name AS zillaName, " +
                    "tblEmployeeinfo.JoiningDate, tblDesignation.Name AS designation , tblZilla.id AS zillaId, tblUpozila.id AS upazilaId, " +
                    "tblUnion.Id AS unionId, tblVillage.Id AS villageId, tblDesignation.Id AS designationId, tblUnion.Name AS unionName " +
                    "FROM tblUnion INNER JOIN tblEmployeeinfo ON tblUnion.Id = tblEmployeeinfo.UnionID " +
                    "INNER JOIN tblUpozila " +
                    "INNER JOIN tblZilla ON tblUpozila.ZillaId = tblZilla.id ON tblUnion.UpozilaId = tblUpozila.id AND tblEmployeeinfo.ZillaID = tblZilla.id AND tblEmployeeinfo.UpozilaID = tblUpozila.id INNER JOIN " +
                    "tblVillage ON tblUnion.Id = tblVillage.UnionId AND tblEmployeeinfo.VillageID = tblVillage.Id INNER JOIN " +
                    "tblDesignation ON tblEmployeeinfo.DesignationID = tblDesignation.Id";

                SqlCommand cmd = new SqlCommand(query,conn);
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = ord["id"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = ord["EmpId"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = ord["Name"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = ord["FName"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = ord["MobileNo"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = ord["Status"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = ord["zillaName"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = ord["upazilaName"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = ord["unionName"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = ord["villageName"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = Convert.ToDateTime(ord["JoiningDate"]).ToString("dd/MMM/yyyy");
                    dataGridView1.Rows[i].Cells[12].Value = ord["designation"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = ord["zillaId"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = ord["upazilaId"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = ord["unionId"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = ord["villageId"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = ord["designationId"].ToString();
                }
                ord.Close();
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Program Error in LoadDesignationToGrid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmAddEmployee_Load(object sender, EventArgs e)
        {

        }
        private void txtClear()
        {
            textBox2.Clear();
            textBox3.Clear(); 
            textBox4.Clear(); 
            comboBox1.Text="";
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox11.Clear();
        }
        //Save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                if (textBox3.Text.Trim() != "")
                {
                    if (textBox4.Text.Trim() != "")
                    {
                        if (comboBox1.Text.Trim() != "")
                        {
                            if (textBox5.Text.Trim() != "")
                            {
                                if (textBox6.Text.Trim() != "")
                                {
                                    if (textBox7.Text.Trim() != "")
                                    {
                                        if (textBox11.Text.Trim() != "")
                                        {
                                            //Corrent EmpID Generate
                                            textBox1.Text = CustEmpIDGenerate();

                                            conn.Close();
                                            conn.Open();
                                            DataTable dt = new DataTable();
                                            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM tblEmployeeinfo WHERE Name='" + textBox2.Text.Trim() + "'AND MobileNo='" + textBox4.Text.Trim() + "'", conn);
                                            sda.Fill(dt);

                                            if (dt.Rows.Count == 0)
                                            {
                                                ImageConverter imageConverter=new ImageConverter();
                                                byte[] bytesImage = (byte[]) imageConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

                                                SqlCommand cmd = new SqlCommand("INSERT INTO tblEmployeeinfo VALUES('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" + zillaID + "','" + upazilaID + "','" + unionID + "','" + villageID + "','" + dateTimePicker4.Value.ToShortDateString() + "','" + designationID + "', @image)", conn);
                                                cmd.Parameters.AddWithValue("@image", bytesImage);
                                                cmd.ExecuteNonQuery();
                                                conn.Close();

                                                // Display a message box with Icon. 
                                                DialogResult r1 = MessageBox.Show("Data Save Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                // Called User Defin Function
                                                LoadEmpinfoToGrid();

                                                txtClear();
                                                textBox2.Focus();

                                                //Corrent EmpID Generate
                                                textBox1.Text = CustEmpIDGenerate();
                                            }
                                            else
                                            {
                                                //conn.Close();
                                                DialogResult r1 = MessageBox.Show("Already Existed.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                textBox1.Focus();
                                            }
                                        }
                                        else
                                        {
                                            // Display a message box with Icon. 
                                            DialogResult r1 = MessageBox.Show("Select Designation.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            textBox11.Focus();
                                        }
                                    }
                                    else
                                    {
                                        // Display a message box with Icon. 
                                        DialogResult r1 = MessageBox.Show("Select Zilla.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBox7.Focus();
                                    }
                                }
                                else
                                {
                                    // Display a message box with Icon. 
                                    DialogResult r1 = MessageBox.Show("Select Upozila.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBox6.Focus();
                                }
                            }
                            else
                            {
                                // Display a message box with Icon. 
                                DialogResult r1 = MessageBox.Show("Select Village.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox5.Focus();
                            }
                        }
                        else
                        {
                            // Display a message box with Icon. 
                            DialogResult r1 = MessageBox.Show("Select Employee Status.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            comboBox1.Focus();
                        }
                    }
                    else
                    {
                        // Display a message box with Icon. 
                        DialogResult r1 = MessageBox.Show("Type Mobile No.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                    }
                }
                else
                {
                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Type Fathers' Name. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Type Employee's Name.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label23_Click(object sender, EventArgs e)
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

        private void label25_Click(object sender, EventArgs e)
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

        private void label26_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            frmVillage fv = new frmVillage();
            fv.ShowDialog();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;
            panelVillage.Visible = true;
            panelDesig.Visible = false;

           LoadVillageToGrid();
        }
        
        private void textBox6_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = true;
            panelUnion.Visible = false;
            panelVillage.Visible = false;
            panelDesig.Visible = false;

            unionID = 0;
            villageID = 0;

            textBox8.Clear();
            textBox5.Clear();

            LoadUpozilaToGrid();
        }
        
        private void textBox7_Click(object sender, EventArgs e)
        {
            panelZila.Visible = true;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;
            panelVillage.Visible = false;
            panelDesig.Visible = false;

            upazilaID = 0;
            unionID = 0;
            villageID = 0;

            textBox6.Clear();
            textBox8.Clear();
            textBox5.Clear();

            LoadZilaToGrid();
        }
        
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            frmDesignation fd = new frmDesignation();
            fd.Show();
        }
        
        private void textBox11_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;
            panelVillage.Visible = false;
            panelDesig.Visible = true;

            LoadDesignationToGrid();
        }

        private int designationID;
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView5.Rows.Count > 0)
            {
                designationID=Convert.ToInt32(dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox11.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelDesig.Visible = false;
                textBox6.Focus();
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmUpozila fn = new frmUpozila();
            fn.ShowDialog();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            frmZilla fz = new frmZilla();
            fz.ShowDialog();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                dataGridView1.Rows.Clear();
                string query =
                    "SELECT tblEmployeeinfo.id, tblEmployeeinfo.EmpId, tblEmployeeinfo.Name, tblEmployeeinfo.FName, tblEmployeeinfo.MobileNo, " +
                    "tblEmployeeinfo.Status, tblVillage.Name AS villageName, tblUpozila.Name AS upazilaName, tblZilla.Name AS zillaName, " +
                    "tblEmployeeinfo.JoiningDate, tblDesignation.Name AS designation , tblZilla.id AS zillaId, tblUpozila.id AS upazilaId, " +
                    "tblUnion.Id AS unionId, tblVillage.Id AS villageId, tblDesignation.Id AS designationId, tblUnion.Name AS unionName " +
                    "FROM tblUnion INNER JOIN tblEmployeeinfo ON tblUnion.Id = tblEmployeeinfo.UnionID " +
                    "INNER JOIN tblUpozila " +
                    "INNER JOIN tblZilla ON tblUpozila.ZillaId = tblZilla.id ON tblUnion.UpozilaId = tblUpozila.id AND tblEmployeeinfo.ZillaID = tblZilla.id AND tblEmployeeinfo.UpozilaID = tblUpozila.id INNER JOIN " +
                    "tblVillage ON tblUnion.Id = tblVillage.UnionId AND tblEmployeeinfo.VillageID = tblVillage.Id INNER JOIN " +
                    "tblDesignation ON tblEmployeeinfo.DesignationID = tblDesignation.Id " +
                    "WHERE tblEmployeeinfo.Name LIKE('" + textBox10.Text.Trim() + "%')";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = ord["id"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = ord["EmpId"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = ord["Name"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = ord["FName"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = ord["MobileNo"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = ord["Status"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = ord["zillaName"].ToString();
                    dataGridView1.Rows[i].Cells[8].Value = ord["upazilaName"].ToString();
                    dataGridView1.Rows[i].Cells[9].Value = ord["unionName"].ToString();
                    dataGridView1.Rows[i].Cells[10].Value = ord["villageName"].ToString();
                    dataGridView1.Rows[i].Cells[11].Value = Convert.ToDateTime(ord["JoiningDate"]).ToString("dd/MMM/yyyy");
                    dataGridView1.Rows[i].Cells[12].Value = ord["designation"].ToString();
                    dataGridView1.Rows[i].Cells[13].Value = ord["zillaId"].ToString();
                    dataGridView1.Rows[i].Cells[14].Value = ord["upazilaId"].ToString();
                    dataGridView1.Rows[i].Cells[15].Value = ord["unionId"].ToString();
                    dataGridView1.Rows[i].Cells[16].Value = ord["villageId"].ToString();
                    dataGridView1.Rows[i].Cells[17].Value = ord["designationId"].ToString();
                }

                ord.Close();
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Program Error in LoadZillaToGrid", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private int zillaID;
        private void dataGridViewZillaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                zillaID = Convert.ToInt32(dataGridViewZillaList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox7.Text = dataGridViewZillaList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelZila.Visible = false;
                textBox6.Focus();
            }
            catch { }
        }

        private int upazilaID;
        private void dataGridViewUpazilaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                upazilaID = Convert.ToInt32(dataGridViewUpazilaList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox6.Text = dataGridViewUpazilaList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelUpazila.Visible = false;
                textBox8.Focus();
            }
            catch { }
        }

        private void dataGridViewZillaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewZillaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewUpazilaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUpazilaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = true;
            panelVillage.Visible = false;
            panelDesig.Visible = false;

            villageID = 0;

            textBox5.Clear();

            LoadUnionToGrid();
        }

        private int unionID;
        private void dataGridViewUnionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                unionID = Convert.ToInt32(dataGridViewUnionList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox8.Text = dataGridViewUnionList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelUnion.Visible = false;
                textBox5.Focus();
            }
            catch { }
            
        }

        private int villageID;
        private void dataGridViewVillageList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                villageID = Convert.ToInt32(dataGridViewVillageList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox5.Text = dataGridViewVillageList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelVillage.Visible = false;
                dateTimePicker4.Focus();
            }
            catch { }
        }

        private void dataGridViewUnionList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUnionList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewVillageList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewVillageList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            frmUnion un=new frmUnion();
            un.ShowDialog();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView5_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView5.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.NoImage;
        }

        private void labelDesigClose_Click(object sender, EventArgs e)
        {
            panelDesig.Visible = false;
        }

        private void labelVillageClose_Click(object sender, EventArgs e)
        {
            panelVillage.Visible = false;
        }

        private void labelUnionClose_Click(object sender, EventArgs e)
        {
            panelUnion.Visible = false;
        }

        private void labelUpazilaClose_Click(object sender, EventArgs e)
        {
            panelUpazila.Visible = false;
        }

        private void labelZilaClose_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
        }

    }
}
