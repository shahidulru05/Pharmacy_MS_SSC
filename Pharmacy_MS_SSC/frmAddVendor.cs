using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pharmacy_MS_SSC
{
    public partial class frmAddVendor : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmAddVendor()
        {
            InitializeComponent();
            LoadVendorToGrid();
        }
        private void frmAddVendor_Load(object sender, EventArgs e)
        {

        }
        //User Defind function for View Data created by Babu
        private void LoadVendorToGrid()
        {
            try
            {
                conn.Close();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblVendor");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = ord["id"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = ord["VendorName"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = ord["vAddress"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = ord["vEmail"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = ord["vWebsite"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = ord["vMobile"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch
            {
                conn.Close();
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Program Error in LoadVillageToGrid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void label20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //Textbox Clear
        private void txtClear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        //Save Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
               if (textBox2.Text.Trim() != "")
                {
                   if (textBox3.Text.Trim() != "")
                    {
                       if (textBox4.Text.Trim() != "")
                        {
                            if (textBox5.Text.Trim() != "")
                            {
                                conn.Close();
                                conn.Open();
                                DataTable dt = new DataTable();
                                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT VendorName FROM tblVendor WHERE VendorName='" + textBox1.Text.Trim() + "'", conn);
                                sda.Fill(dt);

                                if (dt.Rows.Count == 0)
                                {
                                    SqlCommand cmd = new SqlCommand("INSERT INTO tblVendor (VendorName,vAddress,vEmail,vWebsite,vMobile) VALUES('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "')", conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    // Display a message box with Icon. 
                                    DialogResult r1 = MessageBox.Show("Data Save Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Called User Defin Function
                                    LoadVendorToGrid();

                                    txtClear();
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
                                DialogResult r1 = MessageBox.Show("Type Mobile Number.... ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox5.Focus();
                            }
                        }
                        else
                        {
                            // Display a message box with Icon. 
                            DialogResult r1 = MessageBox.Show("Type Email Website... ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox4.Focus();
                       }
                    }
                    else
                    {
                        // Display a message box with Icon. 
                        DialogResult r1 = MessageBox.Show("Type Email Address... ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Focus();
                   }
                }
                else
                {
                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Type Address.. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
               }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Type Vendor Name. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }
        //Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                if (textBox2.Text.Trim() != "")
                {
                    if (textBox3.Text.Trim() != "")
                    {
                        if (textBox4.Text.Trim() != "")
                        {
                            if (textBox5.Text.Trim() != "")
                            {
                                conn.Close();
                                conn.Open();
                                DataTable dt = new DataTable();
                                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT VendorName FROM tblVendor WHERE VendorName='" + textBox1.Text.Trim() + "'", conn);
                                sda.Fill(dt);

                                if (dt.Rows.Count == 0)
                                {
                                    conn.Close();
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("UPDATE tblVendor SET VendorName= '" + textBox1.Text.Trim() + "',vAddress= '" + textBox2.Text.Trim() + "',vEmail= '" + textBox3.Text.Trim() + "',vWebsite= '" + textBox4.Text.Trim() + "',vMobile= '" + textBox5.Text.Trim() + "' WHERE id='" + id1 + "'", conn);
                                      
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    // Display a message box with Icon. 
                                    DialogResult r1 = MessageBox.Show("Data Update Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Called User Defin Function
                                    LoadVendorToGrid();

                                    txtClear();
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
                                DialogResult r1 = MessageBox.Show("Type Mobile Number.... ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // Display a message box with Icon. 
                            DialogResult r1 = MessageBox.Show("Type Email Website... ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Display a message box with Icon. 
                        DialogResult r1 = MessageBox.Show("Type Email Address... ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Display a message box with Icon. 
                    DialogResult r1 = MessageBox.Show("Type Address.. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Type Vendor Details.. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       public int id1;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dataGridView1.Rows.Count > 0)
            {
                id1 = int.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                button1.Visible = false;
                button2.Visible = true;
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        
    }
}
