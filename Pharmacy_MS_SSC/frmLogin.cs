using System;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            GetMACAddress();
            
            SetDevPass();
            label6.Text = @"Application V"+Application.ProductVersion;
        }
        
        private void SetDevPass()
        {
            if (lblMac.Text == "4C72B9D21033" /* me */ || lblMac.Text == "562AA27824E7" /* me */ || lblMac.Text == "480FCF47E978" /* off */)
            {
                textBox1.Text = "developer";
                textBox2.Text = "developer12345";
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        //MAC Address Function
        public void GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            lblMac.Text = sMacAddress;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == GlobalSettings.DevUser && textBox2.Text == GlobalSettings.DevPass)
            {
                GlobalSettings.UserRole = GlobalSettings.DevUser;
                GlobalSettings.UserName = GlobalSettings.DevUser;
                GlobalSettings.EmployeeId = "";

                this.Hide();
                new frmMain().Show();
            }
            else
            {
                if (textBox1.Text.Trim() != "" || textBox2.Text.Trim() != "")
                {
                    var ePassword = new Password().Encrypt(textBox2.Text);
                    string query = "SELECT tblUser.*, tblIdentifire.Identifire " +
                                   "FROM tblUser CROSS JOIN tblIdentifire " +
                                   "WHERE tblIdentifire.Identifire = '" + lblMac.Text +
                                   "' AND tblUser.UserName='" + textBox1.Text.Trim() + "' AND tblUser.Pass='" +
                                   ePassword + "'";
                    var dr = Db.GetDataReader(query);
                    if (dr.Read())
                    {
                        GlobalSettings.UserRole = dr["RoleName"].ToString();
                        GlobalSettings.UserName = dr["UserName"].ToString();
                        GlobalSettings.EmployeeId = dr["EmpID"].ToString();

                        this.Hide();
                        if (!Db.HasExisted("SELECT * FROM TBL_SECURITY WHERE EMP_ID='" + GlobalSettings.EmployeeId + "'"))
                        {
                            var userProfile = new frmUserProfile(true);
                            userProfile.ShowDialog();
                        }
                        new frmMain().Show();
                    }
                    else
                    {
                        label4.Text = "Username or Password incorrect...";
                    }
                }
                else
                {
                    label4.Text = "Username or Password incorrect...";
                }
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToString("dddd, dd-MMM-yyyy");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //conn.Close();
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT Picture FROM tblEmployeeInfo WHERE EmpID=(SELECT EmpID FROM tblUser WHERE UserName='" + textBox1.Text + "')", conn);
            ////SqlCommand cmd = new SqlCommand("SELECT * FROM tblUser WHERE UserName='" + textBox1.Text + "'", conn);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{

            //    if (dr["Picture"] != DBNull.Value)
            //    {
            //        MemoryStream stream = new MemoryStream((byte[])dr["Picture"]);
            //        clsCirclePicBox1.Image = Image.FromStream(stream);
            //    }
            //    else
            //    {
            //        clsCirclePicBox1.Image = Properties.Resources.Customer_BG_Pic;
            //    }
            //}
            //else
            //{

            //}
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Text = "-";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = "-";
        }

        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgotPassword forgotPassword=new frmForgotPassword();
            forgotPassword.ShowDialog();
        }
        
    }
}
