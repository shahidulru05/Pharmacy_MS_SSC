using System;
using System.CodeDom;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using Pharmacy_MS_SSC.Properties;
using ShakikulFramework.Method;

namespace Pharmacy_MS_SSC
{
    public partial class frmUserProfile : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmUserProfile()
        {
            InitializeComponent();
            LoadAddress();
            LoadProfile();
        }

        public frmUserProfile(bool fromLogin)
        {
            InitializeComponent();
            LoadAddress();
            LoadProfile();

            tabPagePersonalInformation.Enabled = false;
            groupBoxChangePassword.Enabled = false;
            tabControlUserProfile.SelectedTab = tabPageSecurity;
            labelTitle.Text = "Set Security Question";
        }

        private bool CheckPassword(string password)
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT Pass FROM tblUser WHERE EmpID='"+GlobalSettings.EmployeeId+
                                     "' AND UserName='"+GlobalSettings.UserName+"' AND Pass='" + 
                                     new Password().Encrypt(password) + "'", conn);
            return cmd.ExecuteReader().Read();
        }

        private void LoadSecurityQuestion()
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM TBL_SECURITY WHERE EMP_ID='"+GlobalSettings.EmployeeId+"'", conn);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBoxQ1.Text = dr["Q1"].ToString();
                textBoxAns1.Text = new Password().Decrypt( dr["ANS1"].ToString());
                textBoxQ2.Text = dr["Q2"].ToString();
                textBoxAns2.Text = new Password().Decrypt(dr["ANS2"].ToString());
                buttonUpdateSecurityQ.Text = "Update Security Question";
            }
        }

        private void LoadProfile()
        {
            try
            {
                conn.Close();
                conn.Open();
                var query = "SELECT E.*, Z.Name ZILA_NAME, U.Name UPOZILA_NAME, UN.Name UNION_NAME, V.Name VILLAGE_NAME " +
                            "FROM tblEmployeeInfo E " +
                            "LEFT JOIN tblZilla Z ON E.ZillaID=Z.id " +
                            "LEFT JOIN tblUpozila U ON E.UpozilaID=U.id " +
                            "LEFT JOIN tblUnion UN ON E.UnionID=UN.Id " +
                            "LEFT JOIN tblVillage V ON E.VillageID=V.Id " +
                            "WHERE E.EmpId='" + GlobalSettings.EmployeeId + "'";
                var cmd = new SqlCommand(query, conn);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // Personal Information
                    textBoxEmpId.Text = GlobalSettings.EmployeeId;
                    textBoxUserName.Text = GlobalSettings.UserName;
                    textBoxName.Text = dr["Name"].ToString();
                    textBoxFName.Text = dr["FName"].ToString();
                    textBoxMobileNo.Text = dr["MobileNo"].ToString();

                    if (dr["EMP_PICTURE"] != DBNull.Value)
                    {
                        var stream = new MemoryStream((byte[])dr["EMP_PICTURE"]);
                        pictureBoxProfilePicture.Image = stream.Length > 0 ? Image.FromStream(stream) : Resources.NoImage;
                    }


                    // Address
                    var zilaName = dr["ZILA_NAME"].ToString();
                    var upozilaName = dr["UPOZILA_NAME"].ToString();
                    var unionName = dr["UNION_NAME"].ToString();
                    var villageName = dr["VILLAGE_NAME"].ToString();

                    // Address
                    comboBoxZila.Text = zilaName;
                    comboBoxUpozila.Text = upozilaName;
                    comboBoxUnion.Text = unionName;
                    comboBoxVillage.Text = villageName;

                    LoadSecurityQuestion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadAddress()
        {
            conn.Close();
            conn.Open();

            comboBoxZila.DisplayMember = "Name";
            comboBoxZila.ValueMember = "Id";

            comboBoxUpozila.DisplayMember = "Name";
            comboBoxUpozila.ValueMember = "Id";

            comboBoxUnion.DisplayMember = "Name";
            comboBoxUnion.ValueMember = "Id";

            comboBoxVillage.DisplayMember = "Name";
            comboBoxVillage.ValueMember = "Id";

            var query = "SELECT * FROM tblZilla ";
            query += "SELECT * FROM tblUpozila ";
            query += "SELECT * FROM tblUnion ";
            query += "SELECT * FROM tblVillage";

            var cmd = new SqlCommand(query, conn);
            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);

            comboBoxZila.DataSource = ds.Tables[0];
            comboBoxUpozila.DataSource = ds.Tables[1];
            comboBoxUnion.DataSource = ds.Tables[2];
            comboBoxVillage.DataSource = ds.Tables[3];
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var imageConverter = new ImageConverter();
            byte[] bytesImage = (byte[]) imageConverter.ConvertTo(pictureBoxProfilePicture.Image, Type.GetType("System.Byte[]"));

            if (MessageBox.Show("Are you sure?\nUpdate your information","Confirmation",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                conn.Close();
                conn.Open();
                var query = "UPDATE tblEmployeeInfo SET Name='" + textBoxName.Text.Trim() + "', FName='" +
                            textBoxFName.Text.Trim() + "', MobileNo='" + textBoxMobileNo.Text.Trim() +
                            "', ZillaID='" + comboBoxZila.SelectedValue + "', UpozilaID='" + comboBoxUpozila.SelectedValue +
                            "', UnionID='" + comboBoxUnion.SelectedValue + "', VillageID='" + comboBoxVillage.SelectedValue +
                            "', EMP_PICTURE=@image WHERE EmpId='" + GlobalSettings.EmployeeId + "'";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@image", bytesImage);
                cmd.ExecuteNonQuery();
            }

        }

        private void comboBoxZila_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM tblUpozila WHERE ZillaId='"+comboBoxZila.SelectedValue+"'",conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                comboBoxUpozila.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBoxUpozila_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM tblUnion WHERE UpozilaId='" + comboBoxUpozila.SelectedValue + "'",conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                comboBoxUnion.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBoxUnion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM tblVillage WHERE UnionId='" + comboBoxUnion.SelectedValue + "'",conn);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                comboBoxVillage.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonBrowsePicture_Click(object sender, EventArgs e)
        {
            var ofd=new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBoxProfilePicture.ImageLocation = ofd.FileName;
            }

        }

        private void buttonClearImage_Click(object sender, EventArgs e)
        {
            pictureBoxProfilePicture.Image = Resources.NoImage;
        }

        private void pictureBoxAns1View_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxAns1.UseSystemPasswordChar = false;
            pictureBoxAns1View.Image = Resources.eye_visible;
        }

        private void pictureBoxAns1View_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxAns1.UseSystemPasswordChar = true;
            pictureBoxAns1View.Image = Resources.eye_invisible;
        }

        private void pictureBoxAns2View_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxAns2.UseSystemPasswordChar = false;
            pictureBoxAns2View.Image = Resources.eye_visible;
        }

        private void pictureBoxAns2View_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxAns2.UseSystemPasswordChar = true;
            pictureBoxAns2View.Image = Resources.eye_invisible;
        }

        private void pictureBoxOldPass_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxOldPass.UseSystemPasswordChar = false;
            pictureBoxOldPass.Image = Resources.eye_visible;

        }

        private void pictureBoxOldPass_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxOldPass.UseSystemPasswordChar = true;
            pictureBoxOldPass.Image = Resources.eye_invisible;
        }

        private void pictureBoxNewPass_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxNewPass.UseSystemPasswordChar = false;
            textBoxConfirmPass.UseSystemPasswordChar = false;
            pictureBoxNewPass.Image = Resources.eye_visible;
        }

        private void pictureBoxNewPass_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxNewPass.UseSystemPasswordChar = true;
            textBoxConfirmPass.UseSystemPasswordChar = true;
            pictureBoxNewPass.Image = Resources.eye_invisible;
        }

        private void textBoxNewPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNewPass.Text == textBoxConfirmPass.Text && textBoxNewPass.Text !="" && textBoxConfirmPass.Text!="")
            {
                labelMatchPassword.Text = @"Match";
                labelMatchPassword.ForeColor = Color.Green;
                buttonChangePass.Enabled = true;
            }
            else
            {
                labelMatchPassword.Text = @"Mismatch";
                labelMatchPassword.ForeColor = Color.Red;
                buttonChangePass.Enabled = false;
            }
        }

        private void textBoxConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNewPass.Text == textBoxConfirmPass.Text && textBoxNewPass.Text != "" && textBoxConfirmPass.Text != "")
            {
                labelMatchPassword.Text = @"Match";
                labelMatchPassword.ForeColor = Color.Green;
                buttonChangePass.Enabled = true;
            }
            else
            {
                labelMatchPassword.Text = @"Mismatch";
                labelMatchPassword.ForeColor = Color.Red;
                buttonChangePass.Enabled = false;
            }
        }

        private void buttonUpdateSecurityQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxQ1.Text!="" && textBoxAns1.Text !="" && textBoxQ2.Text != "" && textBoxAns2.Text !="" && textBoxCurrentPassword.Text!="")
                {
                    if (CheckPassword(textBoxCurrentPassword.Text))
                    {
                        conn.Close();
                        conn.Open();
                        var query = "";

                        var a1 = new Password().Encrypt(textBoxAns1.Text.Trim());
                        var a2 = new Password().Encrypt(textBoxAns2.Text.Trim());

                        if (buttonUpdateSecurityQ.Text == "Update Security Question")
                        {
                            query = "UPDATE TBL_SECURITY SET Q1='" + textBoxQ1.Text.Trim() + "', ANS1='" + a1 +
                                    "', Q2='" + textBoxQ2.Text.Trim() + "', ANS2='" + a2 +
                                    "' WHERE EMP_ID='" + GlobalSettings.EmployeeId + "'";
                        }
                        else
                        {
                            query = "INSERT INTO TBL_SECURITY(EMP_ID,Q1,ANS1,Q2,ANS2) VALUES ('" + GlobalSettings.EmployeeId + "','"
                                    + textBoxQ1.Text.Trim() + "', '" + a1 + "', '" + textBoxQ2.Text.Trim() + "', '" + a2 + "')";
                        }

                        var cmd = new SqlCommand(query, conn);

                        var isConfirm = cmd.ExecuteNonQuery();
                        MessageBox.Show(isConfirm > 0 ? "Successfully updated" : "Failed try again");
                    }
                    else
                    {
                        MessageBox.Show("Please check password and try again");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all security field and try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckPassword(textBoxOldPass.Text))
                {
                    var ePass = new Password().Encrypt(textBoxConfirmPass.Text);
                    conn.Close();
                    conn.Open();
                    var cmd = new SqlCommand("UPDATE tblUser SET Pass='"+ePass+"' WHERE EmpID='"+
                                             GlobalSettings.EmployeeId + "' AND UserName = '"+GlobalSettings.UserName+"'", conn);
                    var isUpdate = cmd.ExecuteNonQuery();
                    if (isUpdate>0)
                    {
                        MessageBox.Show("Password changed successfully\nNow restart application");
                        Application.Restart();
                    }
                }
                else
                {
                    MessageBox.Show("Please check old password and try again");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
