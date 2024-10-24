using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmDbBackup : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());
        
        public frmDbBackup()
        {
            InitializeComponent();
            PermissionLoad();
        }

        private void PermissionLoad()
        {
            if (GlobalSettings.UserName==GlobalSettings.DevUser)
            {
                this.Height = 340;
                groupBox2.Enabled = true;
                groupBox2.Visible = true;
            }
            else
            {
                this.Height = 180;
                groupBox2.Enabled = false;
                groupBox2.Visible = false;
            }


        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath + @"\";
                bunifuImageButton2.Enabled = true;
            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            using (var frmWait=new frmWaiting(BackupDB))
            {
                frmWait.ShowDialog(this);
            }
            textBox1.Clear();
            bunifuImageButton2.Enabled = false;
        }

        private void BackupDB()
        {
            try
            {
                conn.Close();
                conn.Open();
                string query = "BACKUP DATABASE " + dbCon.databaseName + " TO  DISK = N'" + textBox1.Text + dbCon.databaseName +
                               DateTime.Now.ToString("_dddd_dd-MMM-yyyy_HH-mm-ss") + ".bak'";

                        query += "ALTER DATABASE " + dbCon.databaseName + " SET MULTI_USER";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.ToString(), "Location Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Select Backup File";
            ofd.Filter = "Backup File(*.bak)|*.bak";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
                textBox3.Text = ofd.SafeFileName;

                bunifuImageButton4.Enabled = true;
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            using (var waitFrm=new frmWaiting(RestoreDB))
            {
                waitFrm.ShowDialog(this);
            }
            textBox2.Clear();
            textBox3.Clear();
            bunifuImageButton4.Enabled = false;
        }

        private void RestoreDB()
        {
            try
            {
                conn.Close();
                conn.Open();
                string query = "USE MASTER; ";
                query += "ALTER DATABASE " + dbCon.databaseName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ";
                query += "RESTORE DATABASE " + dbCon.databaseName + " FROM DISK = N'" + textBox2.Text.Trim() + "' WITH REPLACE; ";
                query += "ALTER DATABASE " + dbCon.databaseName + " SET MULTI_USER";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Backup path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
