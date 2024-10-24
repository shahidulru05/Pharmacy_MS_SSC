using System.IO;
using Pharmacy_MS_SSC.Common;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Properties;

namespace Pharmacy_MS_SSC
{
    public partial class frmOfficeDetails : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        frmMain fm = new frmMain();
        
        public frmOfficeDetails()
        {
            InitializeComponent();
            LoadHospitalInformation();
        }

        private int id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (button1.Text)
                {
                    case "Save":
                        SaveHospitalInformation();
                        LoadHospitalInformation();
                        break;
                    case "Update":
                        UpdateHospitalInformation();
                        LoadHospitalInformation();
                        break;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void SaveHospitalInformation()
        {
            if (textBox1.Text!="")
            {
                if (textBox2.Text!="")
                {
                    if (textBox3.Text!="")
                    {
                        ImageConverter imageConverter = new ImageConverter();
                        byte[] bytesImage = (byte[])imageConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

                        conn.Close();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO TBL_OFFICE (HospitalName,Address,PhoneNo,Logo,OFFICE_CODE,STATUS,CURRENT_PERIOD) 
                                                                VALUES('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "',@image,'0','A','"+DateTime.Now.Year+"')", conn);
                        cmd.Parameters.AddWithValue("@image", bytesImage);
                        var isSuccess=cmd.ExecuteNonQuery();
                        if (isSuccess>0)
                        {
                            MessageBox.Show("Office Information Save Successfull.");
                        }
                        else
                        {
                            MessageBox.Show("Office Information Save Failed.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter phone number.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Hospital address.");
                }
            }
            else
            {
                MessageBox.Show("Please enter Hospital Name.");
            }
            //if (textBox1.Text.Trim() != "")
            //{
            //    conn.Close();
            //    conn.Open();
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter sda = new SqlDataAdapter(@"SELECT HospitalName,id FROM TBL_OFFICE WHERE id='1'", conn);
            //    sda.Fill(dt);

            //    if (dt.Rows.Count == 0)
            //    {
            //        SqlCommand cmd =
            //            new SqlCommand(
            //                "INSERT INTO TBL_OFFICE (HospitalName,Address,PhoneNo) VALUES('" + textBox1.Text.Trim() +
            //                "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "')", conn);
            //        cmd.ExecuteNonQuery();
            //        conn.Close();

            //        // Display a message box with Icon. 
            //        DialogResult r1 = MessageBox.Show("Data Save Successfully.", "Success Notice.", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);

            //        // Called User Defin Function
            //        //LoadCategoryToGrid();

            //        textBox1.Text = "";
            //        textBox2.Text = "";
            //        textBox3.Text = "";
            //        textBox1.Focus();
            //    }
            //    else
            //    {
            //        conn.Close();
            //        conn.Open();
            //        SqlCommand cmd =
            //            new SqlCommand(
            //                "UPDATE TBL_OFFICE SET HospitalName= '" + textBox1.Text.Trim() + "', Address= '" +
            //                textBox2.Text.Trim() + "', PhoneNo= '" + textBox3.Text.Trim() + "' WHERE id='" + id + "'", conn);
            //        cmd.ExecuteNonQuery();
            //        conn.Close();
            //        //label3.Text = "SL";

            //        // Display a message box with Icon. 
            //        DialogResult r1 = MessageBox.Show("Data Update Successfully.", "Success Notice.", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    // Display a message box with Icon. 
            //    DialogResult r1 = MessageBox.Show("Type Hospital Name. ", "Error Notice.", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
        }

        private void UpdateHospitalInformation()
        {
            if (textBox1.Text!="")
            {
                if (textBox2.Text!="")
                {
                    if (textBox3.Text!="")
                    {
                        ImageConverter imageConverter = new ImageConverter();
                        byte[] bytesImage = (byte[])imageConverter.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));
 
                        conn.Close();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE TBL_OFFICE SET HospitalName='" + textBox1.Text.Trim() + "', Address='" + textBox2.Text.Trim() + "',PhoneNo='" + textBox3.Text.Trim() + "',Logo=@image", conn);
                            cmd.Parameters.AddWithValue("@image", bytesImage);
                        
                        var isSuccess=cmd.ExecuteNonQuery();
                        if (isSuccess>0)
                        {
                            MessageBox.Show("Office Information Update Successfull.");
                        }
                        else
                        {
                            MessageBox.Show("Office Information Update Failed.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter phone number.");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Hospital address.");
                }
            }
            else
            {
                MessageBox.Show("Please enter Hospital Name.");
            }
            //if (textBox1.Text.Trim() != "")
            //{
            //    conn.Close();
            //    conn.Open();
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter sda = new SqlDataAdapter(@"SELECT HospitalName,id FROM TBL_OFFICE WHERE id='1'", conn);
            //    sda.Fill(dt);

            //    if (dt.Rows.Count == 0)
            //    {
            //        SqlCommand cmd =
            //            new SqlCommand(
            //                "INSERT INTO TBL_OFFICE (HospitalName,Address,PhoneNo) VALUES('" + textBox1.Text.Trim() +
            //                "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "')", conn);
            //        cmd.ExecuteNonQuery();
            //        conn.Close();

            //        // Display a message box with Icon. 
            //        DialogResult r1 = MessageBox.Show("Data Save Successfully.", "Success Notice.", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);

            //        // Called User Defin Function
            //        //LoadCategoryToGrid();

            //        textBox1.Text = "";
            //        textBox2.Text = "";
            //        textBox3.Text = "";
            //        textBox1.Focus();
            //    }
            //    else
            //    {
            //        conn.Close();
            //        conn.Open();
            //        SqlCommand cmd =
            //            new SqlCommand(
            //                "UPDATE TBL_OFFICE SET HospitalName= '" + textBox1.Text.Trim() + "', Address= '" +
            //                textBox2.Text.Trim() + "', PhoneNo= '" + textBox3.Text.Trim() + "' WHERE id='" + id + "'", conn);
            //        cmd.ExecuteNonQuery();
            //        conn.Close();
            //        //label3.Text = "SL";

            //        // Display a message box with Icon. 
            //        DialogResult r1 = MessageBox.Show("Data Update Successfully.", "Success Notice.", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    // Display a message box with Icon. 
            //    DialogResult r1 = MessageBox.Show("Type Hospital Name. ", "Error Notice.", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
        }

        private void LoadHospitalInformation()
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM TBL_OFFICE", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["HospitalName"].ToString();
                textBox2.Text = dr["Address"].ToString();
                textBox3.Text = dr["PhoneNo"].ToString();

                if (dr["Logo"] != DBNull.Value)
                {
                    MemoryStream stream = new MemoryStream((byte[])dr["Logo"]);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                else
                {
                    pictureBox1.Image = Resources.NoImage;
                }

                button1.Text = "Update";
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                pictureBox1.Image = Resources.NoImage;

                button1.Text = "Save";
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

        private void button2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "JPG|*.jpg|PNG|*.png";
            ofd.Multiselect = false;

            if (ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.NoImage;
        }
        
    }
}
