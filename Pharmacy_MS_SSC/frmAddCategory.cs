using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmAddCategory : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmAddCategory()
        {
            InitializeComponent();
            LoadCategoryToGrid();
        }

        private void frmAddCategores_Load(object sender, EventArgs e)
        {

        }
        //User Defind function for View Data created by Babu
        private void LoadCategoryToGrid()
        {
            try
            {
                conn.Close();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategory");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cID"].Value = ord["id"].ToString();
                    dataGridView1.Rows[i].Cells["cCategores"].Value = ord["CategoryName"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Program Error in LoadCategoryToGrid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                conn.Close();
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT CategoryName FROM tblCategory WHERE CategoryName='" + textBox1.Text.Trim() + "'", conn);
                sda.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblCategory (CategoryName) VALUES('" + textBox1.Text.Trim() + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Data Save Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Called User Defin Function
                    LoadCategoryToGrid();

                    textBox1.Text = "";
                    textBox1.Focus();

                }
                else
                {
                    //conn.Close();
                    DialogResult r1 = MessageBox.Show("Already Exist", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Type Categores. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                conn.Close();
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT CategoryName FROM tblCategory WHERE CategoryName= '" + textBox1.Text.Trim() + "'", conn);
                sda.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    conn.Close();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tblCategory SET CategoryName= '" + textBox1.Text.Trim() + "' WHERE id='" + id + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //label3.Text = "SL";

                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Data Update Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Called User Defin Function
                    LoadCategoryToGrid();

                    textBox1.Text = "";
                    textBox1.Focus();

                    button1.Visible = true;
                    button2.Visible = false;

                }
                else
                {
                    //conn.Close();
                    DialogResult r1 = MessageBox.Show("Already Exist", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Type Categores. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int id;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                id = int.Parse(dataGridView1.SelectedRows[0].Cells["cID"].Value.ToString());
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["cCategores"].Value.ToString();

                button1.Visible = false;
                button2.Visible = true;
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        
    }
}
