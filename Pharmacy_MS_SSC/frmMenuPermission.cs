using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmMenuPermission : Form
    {
        SqlConnection _conn=new SqlConnection(new DbConnection().ConnectionString());
        public frmMenuPermission()
        {
            InitializeComponent();
            LoadRole();
            LoadMenu();
        }

        private void UncheckAll()
        {
            foreach (TreeNode node in treeViewMenuList.Nodes)
            {
                node.Checked = false;
                node.Collapse();

                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = false;
                    node1.Collapse();

                    foreach (TreeNode node2 in node1.Nodes)
                    {
                        node2.Checked = false;
                        node2.Collapse();

                        foreach (TreeNode node3 in node2.Nodes)
                        {
                            node3.Checked = false;
                            node3.Collapse();
                        }
                    }
                }
            }
            
        }

        private void LoadRole()
        {
            _conn.Close();
            _conn.Open();
            var cmd = new SqlCommand("SELECT *FROM tblUserRole", _conn);
            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables.Count <= 0) return;
            comboBoxRoleList.Items.Clear();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                comboBoxRoleList.Items.Add(row["RoleName"]);
            }
        }

        private void LoadMenu()
        {
            treeViewMenuList.Nodes.Clear();

            _conn.Close();
            _conn.Open();
            var cmd1 = new SqlCommand("SELECT MenuPermision FROM tblUserRole WHERE RoleName='" + GlobalSettings.UserRole + "'", _conn);
            var da1 = new SqlDataAdapter(cmd1);
            var ds = new DataSet();
            da1.Fill(ds);

            _conn.Close();
            _conn.Open();
            var query = GlobalSettings.UserRole == GlobalSettings.DevUser ? "SELECT * FROM TBL_MENU" : "SELECT * FROM TBL_MENU WHERE ID IN (" + ds.Tables[0].Rows[0][0] + ")";
            var cmd = new SqlCommand(query, _conn);
            var da = new SqlDataAdapter(cmd);
            var dt=new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["MAIN_MENU_ID"].ToString() == "0")
                    {
                        var tvr=new TreeNode();
                        tvr.Name = row["ID"].ToString();
                        tvr.Text = row["MENU_NAME"].ToString();
                        
                        treeViewMenuList.Nodes.Add(tvr);
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    if (row["MAIN_MENU_ID"].ToString() != "0")
                    {
                        foreach (TreeNode node in treeViewMenuList.Nodes)
                        {
                            if (row["MAIN_MENU_ID"].ToString() == node.Name)
                            {
                                var tvr = new TreeNode();
                                tvr.Name = row["ID"].ToString();
                                tvr.Text = row["MENU_NAME"].ToString();

                                var tn = node;
                                tn.Nodes.Add(tvr);
                            }

                            foreach (TreeNode node1 in node.Nodes)
                            {
                                if (row["MAIN_MENU_ID"].ToString() == node1.Name)
                                {
                                    var tvr = new TreeNode();
                                    tvr.Name = row["ID"].ToString();
                                    tvr.Text = row["MENU_NAME"].ToString();

                                    var tn = node1;
                                    tn.Nodes.Add(tvr);
                                }

                                foreach (TreeNode node2 in node1.Nodes)
                                {
                                    if (row["MAIN_MENU_ID"].ToString() == node2.Name)
                                    {
                                        var tvr = new TreeNode();
                                        tvr.Name = row["ID"].ToString();
                                        tvr.Text = row["MENU_NAME"].ToString();

                                        var tn = node2;
                                        tn.Nodes.Add(tvr);
                                    }
                                }
                            }


                        }

                    }
                }
                
            }

        }
        
        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            _conn.Close();
            _conn.Open();
            var dt = new DataTable();
            var sda = new SqlDataAdapter(@"SELECT RoleName FROM tblUserRole WHERE RoleName=N'" + textBoxRole.Text.Trim() + "'", _conn);
            sda.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                var cmd = new SqlCommand("INSERT INTO tblUserRole (RoleName,MenuPermision) VALUES(N'" + textBoxRole.Text.Trim() + "','0')", _conn);
                cmd.ExecuteNonQuery();
                _conn.Close();

                LoadRole();

                textBoxRole.Clear();
                comboBoxRoleList.Focus();

                textBoxRole.Visible = false;
                buttonAddRole.Visible = false;
            }
            else
            {
                //conn.Close();
                MessageBox.Show("Already Existed.\nTry another.", "Wrong inpur.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxRole.Focus();
            }
        }

        private void comboBoxRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _conn.Close();
            _conn.Open();
            var cmd = new SqlCommand("SELECT *FROM tblUserRole WHERE RoleName='" + comboBoxRoleList.Text + "'", _conn);
            var dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                UncheckAll();

                var cmd1 = new SqlCommand("SELECT ID FROM TBL_MENU WHERE ID IN (" + dr["MenuPermision"] + ")",
                    _conn);
                var da = new SqlDataAdapter(cmd1);
                dr.Close();
                var dt = new DataTable();
                da.Fill(dt);

                #region CheckBox Check like Permition

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (TreeNode node in treeViewMenuList.Nodes)
                        {
                            if (row["ID"].ToString() == node.Name)
                            {
                                node.Checked = true;
                                node.Expand();
                            }

                            foreach (TreeNode node1 in node.Nodes)
                            {
                                if (row["ID"].ToString() == node1.Name)
                                {
                                    node1.Checked = true;
                                    node1.Expand();
                                }

                                foreach (TreeNode node2 in node1.Nodes)
                                {
                                    if (row["ID"].ToString() == node2.Name)
                                    {
                                        node2.Checked = true;
                                        node2.Expand();
                                    }


                                    foreach (TreeNode node3 in node2.Nodes)
                                    {
                                        if (row["ID"].ToString() == node3.Name)
                                        {
                                            node3.Checked = true;
                                            node3.Expand();
                                        }
                                    }
                                }
                            }
                        }
                    }


                }

                #endregion

            }
            else
            {
                //bunifuThinButton21.Visible = false;
            }
        }

        private void pictureBoxAddUser_Click(object sender, EventArgs e)
        {
            if (textBoxRole.Visible == false || buttonAddRole.Visible == false)
            {
                textBoxRole.Visible = true;
                buttonAddRole.Visible = true;
            }
            else
            {
                textBoxRole.Visible = false;
                buttonAddRole.Visible = false;
            }
        }
        
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxRoleList.Text != "")
                {
                    var selectedMenu = "";

                    foreach (TreeNode node in treeViewMenuList.Nodes)
                    {
                        if (node.Checked)
                        {
                            selectedMenu += selectedMenu == "" ? node.Name : "," + node.Name;
                        }

                        foreach (TreeNode node1 in node.Nodes)
                        {
                            if (node1.Checked)
                            {
                                selectedMenu += "," + node1.Name;
                            }

                            foreach (TreeNode node2 in node1.Nodes)
                            {
                                if (node2.Checked)
                                {
                                    selectedMenu += "," + node2.Name;
                                }

                                foreach (TreeNode node3 in node2.Nodes)
                                {
                                    if (node3.Checked)
                                    {
                                        selectedMenu += "," + node3.Name;
                                    }
                                }
                            }

                        }
                    }

                    _conn.Close();
                    _conn.Open();
                    var query = selectedMenu == ""
                        ? "UPDATE tblUserRole SET MenuPermision=0 WHERE RoleName='" + comboBoxRoleList.Text + "'"
                        : "UPDATE tblUserRole SET MenuPermision='" + selectedMenu + "' WHERE RoleName='" +
                          comboBoxRoleList.Text + "'";
                    var cmd2 = new SqlCommand(query, _conn);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Sucessfully Updated... \nRestart application");
                    _conn.Close();
                }
                else
                {
                    MessageBox.Show("Please select user role and try again");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void treeViewMenuList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                foreach (TreeNode node in treeViewMenuList.Nodes)
                {
                    if (node.Text==e.Node.Text)
                    {
                        foreach (TreeNode node1 in node.Nodes)
                        {
                            if (node.Checked==false)
                            {
                                node1.Checked = false;
                            }

                            if (node1.Text==e.Node.Text)
                            {
                                foreach (TreeNode node2 in node1.Nodes)
                                {
                                    if (node1.Checked==false)
                                    {
                                        node2.Checked = false;
                                    }
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
