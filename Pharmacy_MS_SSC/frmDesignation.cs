using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pharmacy_MS_SSC
{
    public partial class frmDesignation : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmDesignation()
        {
            InitializeComponent();
            LoadDesignationToGrid();
        }
        private int Id;
        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
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
        //User Defind function for View Data created by Babu
        private void LoadDesignationToGrid()
        {
            try
            {
                conn.Close();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDesignation");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = ord["Id"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = ord["Name"].ToString();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                conn.Close();
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT Name FROM tblDesignation WHERE Name='" + textBox1.Text.Trim() + "'", conn);
                sda.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblDesignation (Name) VALUES('" + textBox1.Text.Trim() + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Data Save Successfully..", "Confirmation.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Called User Defin Function
                    //LoadVillageToGrid();

                    textBox1.Clear();
                    textBox1.Focus();
                    LoadDesignationToGrid();
                }
                else
                {
                    //conn.Close();
                    DialogResult r1 = MessageBox.Show("This Name is Allredy Existing", "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Please Type Designation. ", "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() != "")
            {
                conn.Close();
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT Name FROM tblDesignation WHERE Name='" + textBox1.Text.Trim() + "'", conn);
                sda.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    conn.Close();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblDesignation SET Name= '" + textBox1.Text.Trim() + "' WHERE Id='" + Id + "'", conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Data Update Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    // Called User Defin Function
                    //LoadVillageToGrid();

                    textBox1.Clear();
                    textBox1.Focus();
                    LoadDesignationToGrid();

                    button1.Visible = true;
                    button2.Visible = false;
                }
                else
                {
                    //conn.Close();
                    DialogResult r1 = MessageBox.Show("This Name is Allredy Existing", "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Please Type Designation. ", "Error Message.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                button1.Visible = false;
                button2.Visible = true;
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
