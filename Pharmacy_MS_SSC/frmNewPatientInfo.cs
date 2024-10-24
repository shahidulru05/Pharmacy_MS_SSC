using Pharmacy_MS_SSC.Common;
using ShakikulFramework.Method;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Pharmacy_MS_SSC
{
    public partial class frmNewPatientInfo : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());


        public frmNewPatientInfo()
        {
            InitializeComponent();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblPDate.Text = DateTime.Now.ToShortDateString();

            textBox1.Text = CustPtsIDGenerate();
            LoadPatientToGrid();
        }
        // Used Defind Function for Auto Generate Bill No_Dish
        private AutoGenerateInvoice autoGenerateInvoice = new AutoGenerateInvoice();
        private string CustPtsIDGenerate()
        {
            try
            {
                string invoice = "";
                string defaultInvoice = "P1";
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatientID FROM tblPatientInfo ORDER BY id DESC", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    invoice = autoGenerateInvoice.Invoice(dr["PatientID"].ToString(), "P",1);
                }
                else
                {
                    invoice = defaultInvoice;
                }

                return invoice;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            //conn.Close();
            //SqlCommand cmd = new SqlCommand("SELECT PatientID FROM tblPatientInfo ORDER BY id  DESC");
            //cmd.Connection = conn;
            //conn.Open();
            //SqlDataReader sdr = cmd.ExecuteReader();

            //if (sdr.Read())
            //{
            //    string PIDNo = sdr["PatientID"].ToString();
            //    int lastint = int.Parse(PIDNo.Substring(1, 8)) + 1;
            //    sdr.Close();
            //    return "P" + lastint.ToString("00000000");
            //}
            //else
            //{
            //    sdr.Close();
            //    conn.Close();
            //    return "P00000001";
            //}
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
        private void LoadUpozilaToGrid()
        {
            dataGridViewUpazilaList.Rows.Clear();
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblUpozila WHERE ZillaId='" + zillaID + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int i = dataGridViewUpazilaList.Rows.Add();
                dataGridViewUpazilaList.Rows[i].Cells[1].Value = dr["id"].ToString();
                dataGridViewUpazilaList.Rows[i].Cells[2].Value = dr["Name"].ToString();
            }
        }
        //User Defind function for View Data created by Babu
        private int upazilaID;
        private void LoadUnionToGrid()
        {
            dataGridViewUnionList.Rows.Clear();
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM tblUnion WHERE UpozilaId='" + upazilaID + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int i = dataGridViewUnionList.Rows.Add();
                dataGridViewUnionList.Rows[i].Cells[1].Value = dr["id"].ToString();
                dataGridViewUnionList.Rows[i].Cells[2].Value = dr["Name"].ToString();
            }
        }
        //User Defind function for View Data created by Babu
        private int villageID;
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
        private void LoadPatientToGrid()
        {
            conn.Close();
            conn.Open();
            dataGridView1.Rows.Clear();
            string query = "Select tblPatientInfo.*,tblZilla.Name as Zila,tblUpozila.Name as Upozila,tblUnion.Name as UnionName, tblVillage.Name as Village from tblPatientInfo inner join tblZilla on tblPatientInfo.ZilaID = tblZilla.id inner join tblUpozila on tblPatientInfo.UpozilaID = tblUpozila.id inner join tblUnion on tblPatientInfo.UnionID = tblUnion.Id inner join tblVillage on tblPatientInfo.VillageID = tblVillage.Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = dr["PatientID"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr["PatientName"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = dr["FathersName"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = dr["MobileNo"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = dr["Age"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = dr["Gender"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = Convert.ToDateTime(dr["RegDate"]).ToString("dd/MMM/yyyy");
                dataGridView1.Rows[i].Cells[8].Value = dr["Zila"].ToString();
                dataGridView1.Rows[i].Cells[9].Value = dr["Upozila"].ToString();
                dataGridView1.Rows[i].Cells[10].Value = dr["UnionName"].ToString();
                dataGridView1.Rows[i].Cells[11].Value = dr["Village"].ToString();
                dataGridView1.Rows[i].Cells[12].Value = dr["UserName"].ToString();
                dataGridView1.Rows[i].Cells[13].Value = dr["ZilaID"].ToString();
                dataGridView1.Rows[i].Cells[14].Value = dr["UpozilaID"].ToString();
                dataGridView1.Rows[i].Cells[15].Value = dr["UnionID"].ToString();
                dataGridView1.Rows[i].Cells[16].Value = dr["VillageID"].ToString();
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
            this.TopMost = true;
        }

        private void label21_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            lblPDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmZilla fz = new frmZilla();
            fz.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            frmUpozila fu = new frmUpozila();
            fu.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            frmUnion fun = new frmUnion();
            fun.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            frmVillage fv = new frmVillage();
            fv.Show();
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            panelZila.Visible = true;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;
            panelVillage.Visible = false;


            LoadZilaToGrid();
        }

        private void dataGridViewZillaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewZillaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        
        private int zillaID;
        private void dataGridViewZillaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                zillaID = Convert.ToInt32(dataGridViewZillaList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox8.Text = dataGridViewZillaList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelZila.Visible = false;

                textBox7.Clear();
                textBox15.Clear();
                textBox6.Clear();

                textBox7.Focus();
            }
            catch { }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = true;
            panelUnion.Visible = false;
            panelVillage.Visible = false;
            LoadUpozilaToGrid();

        }

        private void dataGridViewUpazilaList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                upazilaID = Convert.ToInt32(dataGridViewUpazilaList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox7.Text = dataGridViewUpazilaList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelUpazila.Visible = false;
                textBox15.Clear();
                textBox15.Focus();

            }
            catch { }
        }
        
        private void textBox15_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = true;
            panelVillage.Visible = false;

            LoadUnionToGrid();
        }

        private int unionID;
        private void dataGridViewUnionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                unionID = Convert.ToInt32(dataGridViewUnionList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox15.Text = dataGridViewUnionList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelUnion.Visible = false;
                textBox6.Focus();
            }
            catch { }
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
            panelUpazila.Visible = false;
            panelUnion.Visible = false;
            panelVillage.Visible = true;
            LoadVillageToGrid();
        }

        private void dataGridViewVillageList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                villageID = Convert.ToInt32(dataGridViewVillageList.Rows[e.RowIndex].Cells[1].Value.ToString());
                textBox6.Text = dataGridViewVillageList.Rows[e.RowIndex].Cells[2].Value.ToString();
                panelVillage.Visible = false;
            }
            catch { }
        }

        private void dataGridViewUpazilaList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUpazilaList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewUnionList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewUnionList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridViewVillageList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewVillageList.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                if (textBox3.Text.Trim() != "")
                {
                    if (textBox4.Text.Trim() != "")
                    {
                        if (textBox5.Text.Trim() != "")
                        {
                            if (comboBox1.Text.Trim() != "")
                            {
                                if (textBox8.Text.Trim() != "")
                                {
                                    if (textBox7.Text.Trim() != "")
                                    {
                                        if (textBox15.Text.Trim() != "")
                                        {
                                            if (textBox6.Text.Trim() != "")
                                            {
                                                //Corrent EmpID Generate
                                                textBox1.Text = CustPtsIDGenerate();

                                                conn.Close();
                                                conn.Open();
                                                DataTable dt = new DataTable();
                                                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM tblPatientInfo WHERE PatientName='" + textBox2.Text.Trim() + "'AND MobileNo='" + textBox4.Text.Trim() + "'", conn);
                                                sda.Fill(dt);

                                                if (dt.Rows.Count == 0)
                                                {
                                                    SqlCommand cmd = new SqlCommand("INSERT INTO tblPatientInfo (PatientID,PatientName,FathersName,MobileNo,Age,Gender,RegDate,ZilaID,UpozilaID,UnionID,VillageID,UserName) VALUES('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + zillaID + "','" + upazilaID + "','" + unionID + "','" + villageID + "','" + GlobalSettings.UserName + "')", conn);
                                                    cmd.ExecuteNonQuery();
                                                    conn.Close();

                                                    // Display a message box with Icon. 
                                                    DialogResult r1 = MessageBox.Show("Data Save Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    // Called User Defin Function
                                                    //CustPtsIDGenerate();

                                                    // txtClear();
                                                    textBox2.Focus();

                                                    //Corrent EmpID Generate
                                                    textBox1.Text = CustPtsIDGenerate();

                                                    LoadPatientToGrid();
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
                                                //conn.Close();
                                                DialogResult r1 = MessageBox.Show("Select Village.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                textBox6.Focus();
                                            }
                                        }
                                        else
                                        {
                                            //conn.Close();
                                            DialogResult r1 = MessageBox.Show("Select Union.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            textBox15.Focus();
                                        }
                                    }
                                    else
                                    {
                                        //conn.Close();
                                        DialogResult r1 = MessageBox.Show("Select Upozila.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBox7.Focus();
                                    }
                                }
                                else
                                {
                                    //conn.Close();
                                    DialogResult r1 = MessageBox.Show("Select Zila.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBox8.Focus();
                                }
                            }
                            else
                            {
                                //conn.Close();
                                DialogResult r1 = MessageBox.Show("Select Gender.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                comboBox1.Focus();
                            }
                        }
                        else
                        {
                            //conn.Close();
                            DialogResult r1 = MessageBox.Show("Type Age.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox5.Focus();
                        }
                    }
                    else
                    {
                        //conn.Close();
                        DialogResult r1 = MessageBox.Show("Type Mobile No.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                    }
                }
                else
                {
                    //conn.Close();
                    DialogResult r1 = MessageBox.Show("Type Father's Name.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
            }
            else
            {
                //conn.Close();
                DialogResult r1 = MessageBox.Show("Type Patient Name.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private string pstID;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                pstID = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                //Zila to Vullage Name 
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox15.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();

                //Zila to Vullage ID
                zillaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[13].Value.ToString());
                upazilaID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[14].Value.ToString());
                unionID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[15].Value.ToString());
                villageID = Convert.ToInt32 (dataGridView1.SelectedRows[0].Cells[16].Value.ToString());


                button1.Visible = false;
                button2.Visible = true;
            }
            else
            {
                // Display a message box with Icon. 
                DialogResult r1 = MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "")
            {
                if (textBox3.Text.Trim() != "")
                {
                    if (textBox4.Text.Trim() != "")
                    {
                        if (textBox5.Text.Trim() != "")
                        {
                            if (comboBox1.Text.Trim() != "")
                            {
                                if (textBox8.Text.Trim() != "")
                                {
                                    if (textBox7.Text.Trim() != "")
                                    {
                                        if (textBox15.Text.Trim() != "")
                                        {
                                            if (textBox6.Text.Trim() != "")
                                            {
                                                //Corrent EmpID Generate
                                                textBox1.Text = CustPtsIDGenerate();

                                                conn.Close();
                                                conn.Open();
                                                DataTable dt = new DataTable();
                                                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM tblPatientInfo WHERE PatientName='" + textBox2.Text.Trim() + "'AND MobileNo='" + textBox4.Text.Trim() + "'", conn);
                                                sda.Fill(dt);

                                                if (dt.Rows.Count == 0)
                                                {
                                                    ////SqlCommand cmd = new SqlCommand("INSERT INTO tblPatientInfo (PatientID,PatientName,FathersName,MobileNo,Age,Gender,RegDate,ZilaID,UpozilaID,UnionID,VillageID,UserName) VALUES('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + comboBox1.Text.Trim() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + zillaID + "','" + upazilaID + "','" + unionID + "','" + villageID + "','" + frmLogin.userName + "')", conn);
                                                    ////cmd.ExecuteNonQuery();
                                                    ////conn.Close();

                                                    conn.Close();
                                                    conn.Open();
                                                    SqlCommand cmd = new SqlCommand("UPDATE tblPatientInfo SET PatientName= '" + textBox2.Text.Trim() + "',FathersName= '" + textBox3.Text.Trim() + "',MobileNo= '" + textBox4.Text.Trim() + "',Age= '" + textBox5.Text.Trim() + "',Gender= '" + comboBox1.Text + "',ZilaID= '" + zillaID + "',UpozilaID= '" + upazilaID + "',UnionID= '" + unionID + "',VillageID= '" + villageID + "', UserName='"+GlobalSettings.UserName+"' WHERE PatientID='" + pstID + "'", conn);
                                                    cmd.ExecuteNonQuery();
                                                    conn.Close();

                                                    // Display a message box with Icon. 
                                                    DialogResult r1 = MessageBox.Show("Data Update Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    foreach (var textBox in Controls.OfType<TextBox>())
                                                    {
                                                        textBox.Clear();
                                                    }

                                                    button1.Visible = true;
                                                    button2.Visible = false;

                                                    LoadPatientToGrid();
                                                    // Called User Defin Function
                                                    //CustPtsIDGenerate();

                                                    // txtClear();
                                                    textBox2.Focus();

                                                    //Corrent EmpID Generate
                                                    textBox1.Text = CustPtsIDGenerate();

                                                    
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
                                                //conn.Close();
                                                DialogResult r1 = MessageBox.Show("Select Village.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                textBox6.Focus();
                                            }
                                        }
                                        else
                                        {
                                            //conn.Close();
                                            DialogResult r1 = MessageBox.Show("Select Union.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            textBox15.Focus();
                                        }
                                    }
                                    else
                                    {
                                        //conn.Close();
                                        DialogResult r1 = MessageBox.Show("Select Upozila.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBox7.Focus();
                                    }
                                }
                                else
                                {
                                    //conn.Close();
                                    DialogResult r1 = MessageBox.Show("Select Zila.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBox8.Focus();
                                }
                            }
                            else
                            {
                                //conn.Close();
                                DialogResult r1 = MessageBox.Show("Select Gender.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                comboBox1.Focus();
                            }
                        }
                        else
                        {
                            //conn.Close();
                            DialogResult r1 = MessageBox.Show("Type Age.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox5.Focus();
                        }
                    }
                    else
                    {
                        //conn.Close();
                        DialogResult r1 = MessageBox.Show("Type Mobile No.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                    }
                }
                else
                {
                    //conn.Close();
                    DialogResult r1 = MessageBox.Show("Type Father's Name.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
            }
            else
            {
                //conn.Close();
                DialogResult r1 = MessageBox.Show("Type Patient Name.", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
        }

        private void labelZilaClose_Click(object sender, EventArgs e)
        {
            panelZila.Visible = false;
        }

        private void labelUpazilaClose_Click(object sender, EventArgs e)
        {
            panelUpazila.Visible = false;
        }

        private void labelUnionClose_Click(object sender, EventArgs e)
        {
            panelUnion.Visible = false;
        }

        private void labelVillageClose_Click(object sender, EventArgs e)
        {
            panelVillage.Visible = false;
        }
    }
}
