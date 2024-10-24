using Pharmacy_MS_SSC.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pharmacy_MS_SSC
{
    public partial class frmTradeName : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        int categoryID;
        int genericID;
        int vendorID;

        public frmTradeName()
        {
            InitializeComponent();
        }


        private void GetRemainderQty(string tradeCode)
        {
            conn.Close();
            conn.Open();
            var cmd = new SqlCommand("SELECT * FROM tblStock WHERE TradeCode='" + tradeCode + "'", conn);
            var dr = cmd.ExecuteReader();
            textBoxRemainderQty.Text = dr.Read() ? dr["REMAINDER_QTY"].ToString() : "20";
        }

        private void frmTradeName_Load(object sender, EventArgs e)
        {

        }
        
        private void LoadTradeNameToGrid(bool allItems = false)
        {
            try
            {
                var query = "SELECT T.*, C.CategoryName, G.GenericName, V.VendorName " +
                            "FROM tblTradeName AS T " +
                            "LEFT JOIN tblCategory AS C ON T.CategoryID = C.id " +
                            "LEFT JOIN tblGenericName AS G ON T.GenericID = G.id " +
                            "LEFT JOIN tblVendor AS V ON T.VendorID = V.id ";

                if (allItems)
                {
                    query += "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBox6.Text))
                    {
                        query += "WHERE T.TradeCode ='" + textBox6.Text.Trim() + "' " +
                                 "OR T.TradeName LIKE('%" + textBox6.Text.Trim() + "%') " +
                                 "OR C.CategoryName LIKE('%" + textBox6.Text.Trim() + "%') " +
                                 "OR G.GenericName LIKE('%" + textBox6.Text.Trim() + "%') " +
                                 "OR V.VendorName LIKE('%" + textBox6.Text.Trim() + "%')";
                    }
                    else
                    {
                        query += "WHERE 0<>0";
                    }
                }

                var dt = Db.GetDataTable(query);

                dataGridView1.DataSource = dt;

                labelTradeCount.Text = "Total Trade: " + dataGridView1.RowCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //User Defind function for View Data created by Babu
        private void LoadCategoryToGrid()
        {
            try
            {
                conn.Close();
                dataGridView2.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategory");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = ord["id"].ToString();
                    dataGridView2.Rows[i].Cells[1].Value = ord["CategoryName"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                // Display a message box with Icon. 
                MessageBox.Show(ex.ToString() , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //User Defind function for View Data created by Babu
        private void LoadGenericNameToGrid()
        {
            try
            {
                conn.Close();
                dataGridView3.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblGenericName");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells[0].Value = ord["id"].ToString();
                    dataGridView3.Rows[i].Cells[1].Value = ord["GenericName"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                // Display a message box with Icon. 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //User Defind function for View Data created by Babu
        private void LoadVendorToGrid()
        {
            try
            {
                conn.Close();
                dataGridView4.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblVendor");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView4.Rows.Add();
                    dataGridView4.Rows[i].Cells[0].Value = ord["id"].ToString();
                    dataGridView4.Rows[i].Cells[1].Value = ord["VendorName"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                // Display a message box with Icon. 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                dataGridView2.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategory WHERE CategoryName LIKE('" + textBoxCategorName.Text.Trim() + "%')");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView2.Rows.Add();
                    dataGridView2.Rows[i].Cells[0].Value = ord["id"].ToString();
                    dataGridView2.Rows[i].Cells[1].Value = ord["CategoryName"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                // Display a message box with Icon. 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //Textbox Clear
        private void ClearField()
        {
            textBoxTradeCode.Clear();
            textBoxTradeName.Clear();
            textBoxCategorName.Clear();
            textBoxGenericName.Clear();
            textBoxVendorName.Clear();
            textBoxRemainderQty.Clear();
            textBoxLocation.Clear();

            _tradeCode = "";

            textBoxTradeCode.Focus();
        }
        //Save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxTradeCode.Text.Trim() != "")
            {
                if (textBoxTradeName.Text.Trim() != "")
                {
                    if (textBoxCategorName.Text.Trim() != "")
                    {
                        if (textBoxGenericName.Text.Trim() != "")
                        {
                            if (textBoxVendorName.Text.Trim() != "")
                            {
                                if (textBoxRemainderQty.Text!="")
                                {
                                    conn.Close();
                                    conn.Open();
                                    var dt = new DataTable();
                                    var sda = new SqlDataAdapter(@"SELECT * FROM tblTradeName WHERE TradeCode='" + textBoxTradeCode.Text.Trim() + "' OR TradeName='" + textBoxTradeName.Text.Trim() + "'", conn);
                                    sda.Fill(dt);

                                    if (dt.Rows.Count == 0)
                                    {
                                        //insert into TradeName table
                                        conn.Close();
                                        conn.Open();
                                        SqlCommand cmd = new SqlCommand("INSERT INTO tblTradeName (AccountCode,TradeCode,TradeName,CategoryID,GenericID,VendorID, RACK_NAME) " +
                                                                        "VALUES('" + cBoxAccountCode.Text.Trim() + "','" + textBoxTradeCode.Text.Trim() + 
                                                                        "','" + textBoxTradeName.Text.Trim() + "','" + categoryID + "','" + genericID + 
                                                                        "','" + vendorID + "','"+textBoxLocation.Text.Trim()+"')", conn);
                                        cmd.ExecuteNonQuery();
                                    
                                        conn.Close();
                                        conn.Open();
                                        SqlCommand cmdd;

                                        cmdd = new SqlCommand(
                                            "INSERT INTO tblStock (TradeCode,Qty,wsPrice,SaleMRP,UnitPrice, REMAINDER_QTY) VALUES( '" +
                                            textBoxTradeCode.Text.Trim() + "','0','0','0','0', '" +
                                            Convert.ToInt32(textBoxRemainderQty.Text.Trim()) + "')", conn);
                                        

                                        cmdd.ExecuteNonQuery();
                                        conn.Close();

                                        // Display a message box with Icon. 
                                        MessageBox.Show("Data Save Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LoadTradeNameToGrid();
                                        ClearField();
                                        textBoxTradeCode.Focus();

                                    }
                                    else
                                    {
                                        //conn.Close();
                                        MessageBox.Show("Already Exist", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBoxTradeCode.Focus();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Please enter remainder quantity");
                                }
                            }
                            else
                            {
                                // Display a message box with Icon. 
                                MessageBox.Show("Select Vendor. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxVendorName.Focus();
                            }
                        }
                        else
                        {
                            // Display a message box with Icon. 
                            MessageBox.Show("Select Generic Name. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxGenericName.Focus();
                        }
                    }
                    else
                    {
                        // Display a message box with Icon. 
                        MessageBox.Show("Select Category. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxCategorName.Focus();
                    }
                }
                else
                {
                    // Display a message box with Icon. 
                    MessageBox.Show("Type Trade Name. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxTradeName.Focus();
                }
            }
            else
            {
                // Display a message box with Icon. 
                MessageBox.Show("Type Trade Code. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTradeCode.Focus();
            }
        }

        private void cBoxAccountCode_KeyDown(object sender, KeyEventArgs e)
        {
            //Combobox Readonly
            e.SuppressKeyPress = true;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            panelCategory.Visible = true;
            LoadCategoryToGrid();
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                dataGridView3.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblGenericName WHERE GenericName LIKE('" + textBoxGenericName.Text.Trim() + "%')");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView3.Rows.Add();
                    dataGridView3.Rows[i].Cells[0].Value = ord["id"].ToString();
                    dataGridView3.Rows[i].Cells[1].Value = ord["GenericName"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                // Display a message box with Icon. 
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                dataGridView4.Rows.Clear();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblVendor WHERE VendorName LIKE('" + textBoxVendorName.Text.Trim() + "%')");
                cmd.Connection = conn;
                conn.Open();
                SqlDataReader ord = cmd.ExecuteReader();
                while (ord.Read())
                {
                    int i = dataGridView4.Rows.Add();
                    dataGridView4.Rows[i].Cells[0].Value = ord["id"].ToString();
                    dataGridView4.Rows[i].Cells[1].Value = ord["VendorName"].ToString();
                }
                ord.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                // Display a message box with Icon. 
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            panelCategory.Visible = true;
            LoadCategoryToGrid();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0) 
            {
                categoryID = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                textBoxCategorName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                panelCategory.Visible = false;
                textBoxGenericName.Focus();
            }
            else
            {
                // Display a message box with Icon. 
                MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            panelGeneric.Visible = true;
            LoadGenericNameToGrid();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            panelGeneric.Visible = true;
            LoadGenericNameToGrid();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                genericID = int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
                textBoxGenericName.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
                panelGeneric.Visible = false;
                textBoxGenericName.Focus();
            }
            else
            {
                // Display a message box with Icon. 
                MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            frmAddCategory fc = new frmAddCategory();
            fc.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            frmGenericName fg = new frmGenericName();
            fg.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            frmAddVendor fg = new frmAddVendor();
            fg.Show();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            panelVendor.Visible = true;
            LoadVendorToGrid();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            panelVendor.Visible = true;
            LoadVendorToGrid();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
            {
                vendorID = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                textBoxVendorName.Text = dataGridView4.SelectedRows[0].Cells[1].Value.ToString();
                panelVendor.Visible = false;
                button1.Focus();
            }
            else
            {
                // Display a message box with Icon. 
                MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxTradeCode.Text.Trim() != "")
            {
                if (textBoxTradeName.Text.Trim() != "")
                {
                    if (textBoxCategorName.Text.Trim() != "")
                    {
                        if (textBoxGenericName.Text.Trim() != "")
                        {
                            if (textBoxVendorName.Text.Trim() != "")
                            {
                                if (textBoxRemainderQty.Text.Trim() != "")
                                {
                                    conn.Close();
                                    conn.Open();
                                    DataTable dt = new DataTable();
                                    SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM tblTradeName WHERE TradeCode='" + textBoxTradeCode.Text.Trim() + "' AND TradeName='" + textBoxTradeName.Text.Trim() + "' AND id<>'" + id + "'", conn);
                                    sda.Fill(dt);

                                    if (dt.Rows.Count == 0)
                                    {
                                        conn.Close();
                                        conn.Open();
                                        var query = "UPDATE tblTradeName SET AccountCode= '" +
                                                    cBoxAccountCode.Text.Trim() + "', TradeName= '" + 
                                                    textBoxTradeName.Text.Trim() + "', CategoryID= '" + 
                                                    categoryID + "', GenericID= '" + genericID + 
                                                    "', VendorID= '" + vendorID + "', RACK_NAME='" +
                                                    textBoxLocation.Text.Trim() + 
                                                    "' WHERE id='" + id + "'";

                                        query += "UPDATE tblStock SET REMAINDER_QTY='" + Convert.ToInt32(textBoxRemainderQty.Text.Trim()) + "' WHERE TradeCode='"+_tradeCode+"'";
                                        

                                        var cmd = new SqlCommand(query, conn);

                                        cmd.ExecuteNonQuery();
                                    
                                        conn.Close();
                                        conn.Open();

                                        // Display a message box with Icon. 
                                        MessageBox.Show("Data Update Successfully.", "Success Notice.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        ClearField();
                                        LoadTradeNameToGrid();
                                        button1.Visible = true;
                                        button2.Visible = false;
                                    
                                    }
                                    else
                                    {
                                        //conn.Close();
                                        MessageBox.Show("Already Exist", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBoxTradeCode.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please enter remainder quantity");
                                }
                            }
                            else
                            {
                                // Display a message box with Icon. 
                                MessageBox.Show("Select Vendor. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBoxVendorName.Focus();
                            }
                        }
                        else
                        {
                            // Display a message box with Icon. 
                            MessageBox.Show("Select Generic Name. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBoxGenericName.Focus();
                        }
                    }
                    else
                    {
                        // Display a message box with Icon. 
                        MessageBox.Show("Select Category. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxCategorName.Focus();
                    }
                }
                else
                {
                    // Display a message box with Icon. 
                    MessageBox.Show("Type Trade Name. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxTradeName.Focus();
                }
            }
            else
            {
                // Display a message box with Icon. 
                MessageBox.Show("Type Trade Code. ", "Error Notice.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxTradeCode.Focus();
            }
        }

        public int id;
        private string _tradeCode;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                id = int.Parse(dataGridView1.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value.ToString());
                _tradeCode = dataGridView1.SelectedRows[0].Cells["TradeCodeDataGridViewTextBoxColumn"].Value.ToString();

                cBoxAccountCode.Text = dataGridView1.SelectedRows[0].Cells["AccountCodeDataGridViewTextBoxColumn"].Value.ToString();
                textBoxTradeCode.Text = _tradeCode;
                textBoxTradeName.Text = dataGridView1.SelectedRows[0].Cells["TradeNameDataGridViewTextBoxColumn"].Value.ToString();
                textBoxLocation.Text = dataGridView1.SelectedRows[0].Cells["ColumnRACK_NAME"].Value.ToString();
                textBoxCategorName.Text = dataGridView1.SelectedRows[0].Cells["CategoryNameDataGridViewTextBoxColumn"].Value.ToString();
                textBoxGenericName.Text = dataGridView1.SelectedRows[0].Cells["GenericNameDataGridViewTextBoxColumn"].Value.ToString();
                textBoxVendorName.Text = dataGridView1.SelectedRows[0].Cells["VendorNameDataGridViewTextBoxColumn"].Value.ToString();
                categoryID = int.Parse(dataGridView1.SelectedRows[0].Cells["CategoryIDDataGridViewTextBoxColumn"].Value.ToString());
                genericID = int.Parse(dataGridView1.SelectedRows[0].Cells["GenericIDDataGridViewTextBoxColumn"].Value.ToString());
                vendorID = int.Parse(dataGridView1.SelectedRows[0].Cells["VendorIDDataGridViewTextBoxColumn"].Value.ToString());

                GetRemainderQty(textBoxTradeCode.Text);

                button1.Visible = false;
                button2.Visible = true;
            }
            else
            {
                MessageBox.Show("Click on the Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTradeNameToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Cells["sl"].Value = (e.RowIndex + 1).ToString();
        }
        
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void linkLabelViewAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadTradeNameToGrid(true);
        }

        private void labelCategoryClose_Click(object sender, EventArgs e)
        {
            panelCategory.Visible = false;
        }

        private void labelGenericClose_Click(object sender, EventArgs e)
        {
            panelGeneric.Visible = false;
        }

        private void labelVendorClose_Click(object sender, EventArgs e)
        {
            panelVendor.Visible = false;
        }

     }
}
