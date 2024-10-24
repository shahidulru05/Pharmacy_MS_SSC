using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmForgotPassword : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        private string _questionField;
        private string _answerField;
        public frmForgotPassword()
        {
            InitializeComponent();
        }
        
        private void labelClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        private void label21_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM TBL_SECURITY WHERE EMP_ID='" + GlobalSettings.EmployeeId +

                                     "' AND " + _questionField + " = '" + textBoxSecurityQuestion.Text + "' AND " +
                                     _answerField + " = '" + new Password().Encrypt(textBoxAnswer.Text) + "'", conn);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                panelSecurity.Visible = false;
                textBoxUserNamePassword.Text = GlobalSettings.UserName;
                panelSetNewPassword.Visible = true;
            }
            else
            {
                MessageBox.Show("Wrong identity");
            }
        }

        private void textBoxUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM tblUser WHERE UserName='"+textBoxUserName.Text+"'", conn);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    GlobalSettings.EmployeeId = dr["EmpID"].ToString();
                    GlobalSettings.UserName = dr["UserName"].ToString();

                    var sec = DateTime.Now.Second;
                    var question = sec - (2 * (sec / 2));
                    _questionField = question == 0 ? "Q2" : "Q1";
                    _answerField = question == 0 ? "ANS2" : "ANS1";

                    dr.Close();
                    conn.Close();
                    conn.Open();
                    cmd = new SqlCommand("SELECT " + _questionField + " FROM TBL_SECURITY WHERE EMP_ID='" + GlobalSettings.EmployeeId + "' ", conn);
                    var dr1 = cmd.ExecuteReader();
                    
                    if (dr1.Read())
                    {
                        textBoxSecurityQuestion.Text = dr1[_questionField].ToString();
                    }
                    else
                    {
                        textBoxSecurityQuestion.Text = "..........?";
                        panelSecurity.Enabled = false;
                        MessageBox.Show("You, dos't set security question...");

                    }

                    panelUserName.Visible = false;
                    panelSecurity.Visible = true;
                }
                else
                {
                    MessageBox.Show("Wrong Username please try again");
                }
            }
        }

        private void textBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text==textBoxConfirmPassword.Text && textBoxNewPassword.Text != "" && textBoxConfirmPassword.Text != "")
            {
                labelMatchPasswordMessage.Text = "Matched";
                labelMatchPasswordMessage.ForeColor = Color.Green;
                buttonSetNewPassword.Enabled = true;
            }
            else
            {
                labelMatchPasswordMessage.Text = "Mismatch";
                labelMatchPasswordMessage.ForeColor = Color.Red;
                buttonSetNewPassword.Enabled = false;
            }
        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNewPassword.Text == textBoxConfirmPassword.Text && textBoxNewPassword.Text != "" && textBoxConfirmPassword.Text != "")
            {
                labelMatchPasswordMessage.Text = "Matched";
                labelMatchPasswordMessage.ForeColor = Color.Green;
                buttonSetNewPassword.Enabled = true;
            }
            else
            {
                labelMatchPasswordMessage.Text = "Mismatch";
                labelMatchPasswordMessage.ForeColor = Color.Red;
                buttonSetNewPassword.Enabled = false;
            }
        }

        private void buttonSetNewPassword_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?\nForgot your password.")==DialogResult.OK)
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("UPDATE tblUser SET Pass='"+new Password().Encrypt(textBoxConfirmPassword.Text)+
                                         "' WHERE EmpID='"+GlobalSettings.EmployeeId+"' AND UserName='"+GlobalSettings.UserName+"'", conn);
                var isUpdate = cmd.ExecuteNonQuery();
                if (isUpdate>0)
                {
                    MessageBox.Show("Your new password has been successfully updated\nNow restart your application and enjoy the new password");
                    Application.Restart();
                }
            }
        }

        private void pictureBoxShowPassword_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxShowPassword.Image = Resources.eye_visible;
            textBoxNewPassword.UseSystemPasswordChar = false;
            textBoxConfirmPassword.UseSystemPasswordChar = false;
        }

        private void pictureBoxShowPassword_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxShowPassword.Image = Resources.eye_invisible;
            textBoxNewPassword.UseSystemPasswordChar = true;
            textBoxConfirmPassword.UseSystemPasswordChar = true;
        }

    }
}
