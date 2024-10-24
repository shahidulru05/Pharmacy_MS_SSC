using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmAddUser : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmAddUser()
        {
            InitializeComponent();
            LoadRole();
            LoadEmpinfoToGrid();
            LoadUserinfoToGrid();
        }
        //Load Data Tot ComboBox
        private void LoadRole()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblUserRole", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                comboBoxUserRole.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    comboBoxUserRole.Items.Add(row["RoleName"]);
                }
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
                    "SELECT tblEmployeeinfo.*, tblDesignation.Name AS designation "+
                    "FROM tblEmployeeinfo INNER JOIN tblDesignation ON tblEmployeeinfo.DesignationID = tblDesignation.Id";

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
                    dataGridView1.Rows[i].Cells[7].Value = ord["designation"].ToString();

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

        private void LoadUserinfoToGrid()
        {
            try
            {
                conn.Close();
                dataGridView2.Rows.Clear();
                var query = "SELECT tblEmployeeinfo.Name, tblUser.* " +
                            "FROM tblEmployeeinfo INNER JOIN " +
                            "tblUser ON tblEmployeeinfo.EmpId = tblUser.EmpID ";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();

                while (ord.Read())
                {
                    int i = dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[1].Value = ord["EmpId"].ToString();
                    dataGridView2.Rows[i].Cells[2].Value = ord["Name"].ToString();
                    dataGridView2.Rows[i].Cells[3].Value = ord["UserName"].ToString();
                    dataGridView2.Rows[i].Cells[4].Value = ord["RoleName"].ToString();
                    dataGridView2.Rows[i].Cells[5].Value = ord["Status"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxEmpId_TextChanged(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT tblEmployeeinfo.*, tblDesignation.Name AS designation FROM tblEmployeeinfo INNER JOIN tblDesignation ON tblEmployeeinfo.DesignationID=tblDesignation.id WHERE EmpId='" + textBoxEmpId.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBoxName.Text = dr["Name"].ToString();
                textBoxMobile.Text = dr["MobileNo"].ToString();
                textBoxDescription.Text = dr["designation"].ToString();



                //find user name
                conn.Close();
                conn.Open();
                var query = "SELECT tblEmployeeinfo.EmpId, tblUser.* " +
                            "FROM tblEmployeeinfo INNER JOIN " +
                            "tblUser ON tblEmployeeinfo.EmpId = tblUser.EmpID " +
                            "WHERE tblEmployeeinfo.EmpId='" + textBoxEmpId.Text + "'";

                var cmd1 = new SqlCommand(query, conn);
                SqlDataReader dr1 = cmd1.ExecuteReader();

                if (dr1.Read())
                {
                    bunifuiOSSwitch1.Value = (bool)dr1["Status"];
                    textBoxUserName.Text = dr1["UserName"].ToString();
                    comboBoxUserRole.Text = dr1["RoleName"].ToString();
                }
                else
                {
                    bunifuiOSSwitch1.Value = false;
                    textBoxUserName.Text = "";
                    comboBoxUserRole.Text = "";
                }


                if (textBoxUserName.Text != "")
                {
                    textBoxUserName.ReadOnly = true;
                    button1.Text = "Update";
                }
                else
                {
                    textBoxUserName.ReadOnly = false;
                    button1.Text = "Save";
                }

                //textBox3.Text = dr["MobileNo"].ToString();
                //textBox4.Text = dr["Designation"].ToString();

                button1.Enabled = true;
            }
            else
            {
                //pictureBox1.Image = Properties.Resources.Customer_BG_Pic;
                button1.Enabled = false;

                textBoxName.Clear();
                textBoxMobile.Clear();
                textBoxDescription.Clear();
                textBoxUserName.Clear();
                textBoxPassword.Text = "12345";
                comboBoxUserRole.Text = "";
                textBoxUserName.ReadOnly = false;
                button1.Text = "Save";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (button1.Text)
                {
                    case "Save":
                        SaveUser();
                        break;
                    case "Update":
                        UpdateUser();
                        break;
                }

                LoadUserinfoToGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveUser()
        {
            if (textBoxEmpId.Text.Trim() != "")
            {
                if (textBoxUserName.Text.Trim() != "")
                {
                    if (comboBoxUserRole.Text.Trim() != "")
                    {
                        conn.Close();
                        conn.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter sda =
                            new SqlDataAdapter(
                                @"SELECT * FROM tblUser WHERE EmpID='" + textBoxEmpId.Text.Trim() + "' OR UserName='" +
                                textBoxUserName.Text.Trim() + "'", conn);
                        sda.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            var ePassword = new Password().Encrypt(textBoxPassword.Text);
                            SqlCommand cmd =
                                new SqlCommand(
                                    "INSERT INTO tblUser VALUES('" + textBoxEmpId.Text.Trim() +
                                    "','" + textBoxUserName.Text.Trim() + "','" + ePassword + "','" +
                                    comboBoxUserRole.Text.Trim() + "','1')", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            // Display a message box with Icon. 
                            DialogResult r1 = MessageBox.Show("The account has been successfully created.", "Success Notice.",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);


                            //All Textbox Clear Code
                            foreach (Control control in Controls)
                            {
                                if (control is TextBox)
                                {
                                    control.Text = "";
                                }
                            }

                            
                            textBoxPassword.Text = "12345";
                            comboBoxUserRole.Text = "";
                        }
                        else
                        {
                            //conn.Close();
                            DialogResult r1 = MessageBox.Show("This username already exists.\n Try Anothers. ", "Error Notice.",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxEmpId.Focus();
                        }
                    }
                    else
                    {
                        //conn.Close();
                        DialogResult r1 = MessageBox.Show("Select User Role.", "Error Notice.", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        textBoxUserName.Focus();
                    }
                }
                else
                {
                    //conn.Close();
                    DialogResult r1 = MessageBox.Show("Please Type Unique UserName.", "Error Notice.", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    textBoxUserName.Focus();
                }
            }
            else
            {
                //conn.Close();
                DialogResult r1 = MessageBox.Show("Select Employee ID", "Error Notice.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBoxEmpId.Focus();
            }
        }

        private void UpdateUser()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblUser SET RoleName='" + comboBoxUserRole.Text.Trim() + "', Status='" + bunifuiOSSwitch1.Value + "' WHERE EmpID='" + textBoxEmpId.Text.Trim() + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            // Display a message box with Icon. 
            DialogResult r1 = MessageBox.Show("This account has been successfully Updated.", "Success Notice.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


            //All Textbox Clear Code

            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }

            textBoxPassword.Text = "12345";
            comboBoxUserRole.Text = "";

        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label6_Click(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand cmd = new SqlCommand("SELECT * FROM tblEmployeeinfo WHERE Name LIKE('%" + textBox7.Text.Trim() + "%')");
                conn.Close();
                conn.Open();
                dataGridView1.Rows.Clear();
                string query =
                    "SELECT tblEmployeeinfo.*, tblDesignation.Name AS designation " +
                    "FROM tblEmployeeinfo INNER JOIN tblDesignation "+
                    "ON tblEmployeeinfo.DesignationID = tblDesignation.Id "+
                    "WHERE tblEmployeeinfo.Name LIKE('%" + textBox7.Text.Trim() + "%')";

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
                    dataGridView1.Rows[i].Cells[7].Value = ord["designation"].ToString();

                }
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Load failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBoxEmpId.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBoxPassword.Focus();
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                dataGridView2.Rows.Clear();
                var query = "SELECT tblEmployeeinfo.Name, tblUser.* " +
                            "FROM tblEmployeeinfo INNER JOIN " +
                            "tblUser ON tblEmployeeinfo.EmpId = tblUser.EmpID " +
                            "WHERE Name LIKE '%" + textBox8.Text + "%' " +
                            "OR tblUser.EmpID LIKE '%" + textBox8.Text + "%' " +
                            "OR UserName LIKE '%" + textBox8.Text + "%' " +
                            "OR RoleName LIKE '%" + textBox8.Text + "%' ";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();

                while (ord.Read())
                {
                    int i = dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[1].Value = ord["EmpId"].ToString();
                    dataGridView2.Rows[i].Cells[2].Value = ord["Name"].ToString();
                    dataGridView2.Rows[i].Cells[3].Value = ord["UserName"].ToString();
                    dataGridView2.Rows[i].Cells[4].Value = ord["RoleName"].ToString();
                    dataGridView2.Rows[i].Cells[5].Value = ord["Status"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                textBoxEmpId.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();

                textBoxPassword.Focus();
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
