using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;
using Pharmacy_MS_SSC.Reports;
using Pharmacy_MS_SSC.Properties;

namespace Pharmacy_MS_SSC
{
    public partial class frmMain : Form
    {
        // SQL connection        
        //static readonly DbConnection dbCon = new DbConnection();
        //private readonly SqlConnection _conn = new SqlConnection(dbCon.ConnectionString());

        //private SqlCommand _cmd;
        //private SqlDataReader _dr;
        //private SqlDataAdapter _da;
        //private DataTable _dt;

        private frmWaiting fw = new frmWaiting();

        public frmMain()
        {
            InitializeComponent();

            fw.Show();
            Application.DoEvents();

            HideMenu();

            LoadCurrentPeriod();
            LoadOfficeInformation();

            GetByMenu();
            LoginSession();

            LowStockRemainder();
            ExpiringSoon();

            fw.Close();
        }
        
        private void LoadMenuSetting()
        {
            var dt = Db.GetDataTable("SELECT * FROM TBL_MENU_SETTING");
            if (dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    switch (row["ID"].ToString())
                    {
                        case "1":
                            GlobalSettings.SaleMemoSize = Convert.ToDouble(row["CODE"].ToString());
                            break;
                        case "2":
                            GlobalSettings.InputSamplePrice = row["CODE"].ToString() == "77";
                            break;
                    }
                }
            }
        }

        private void LowStockRemainder()
        {
            var dr = Db.GetDataReader("SELECT COUNT(*) AS TOTAL FROM tblStock WHERE Qty<=REMAINDER_QTY");
            
            buttonStockRemainder.Text = dr.Read() ? dr["TOTAL"].ToString() : "error";
        }

        private void LoadCurrentPeriod()
        {
            try
            {
                var dr = Db.GetDataReader("SELECT CURRENT_PERIOD FROM TBL_OFFICE WHERE STATUS='A'");
                if (dr.Read())
                {
                    var softCurrentPeriod = Convert.ToInt32(GlobalSettings.OfficeInfo.Rows[0]["CURRENT_PERIOD"].ToString());
                    var phyCurrentPeriod = DateTime.Today.Year;
                    
                    if (softCurrentPeriod < phyCurrentPeriod)
                    {
                        if (MessageBox.Show("Your software current period is [ " + softCurrentPeriod + " ] and Physically your current period is [ " + DateTime.Today.Year + " ] click update your software current period", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (MessageBox.Show("Are you sure update software current period [ " + softCurrentPeriod + " ] to [ " + phyCurrentPeriod + " ]", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                var isUpdate = Db.QueryExecute("UPDATE TBL_OFFICE SET CURRENT_PERIOD='" + phyCurrentPeriod +
                                                               "' WHERE STATUS='A' AND CURRENT_PERIOD='" + softCurrentPeriod +
                                                               "'");
                                if (isUpdate)
                                {
                                    MessageBox.Show("Restart your application");
                                    Application.Exit();
                                }
                            }
                        }
                    }
                    else if (softCurrentPeriod > phyCurrentPeriod)
                    {
                        MessageBox.Show("The current Period is problem");
                        Application.Exit();
                    }

                    Settings.Default.CURRENT_PERIOD = softCurrentPeriod.ToString();
                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void updateMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wait=new frmWaiting();
            wait.Show();
            Application.DoEvents();

            var menuCmd = "";

            #region MenuList


            if (!SelectMenu("fileToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('1','fileToolStripMenuItem', 'File', '0'); ";
            }

            if (!SelectMenu("officeDetailsToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('2','officeDetailsToolStripMenuItem', 'Office Details', '1'); ";
            }

            if (!SelectMenu("addDataToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('3','addDataToolStripMenuItem', 'Add Data', '0'); ";
            }

            if (!SelectMenu("newPatientInformationToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('4','newPatientInformationToolStripMenuItem', 'Patient Information', '3'); ";
            }

            if (!SelectMenu("newEmployeesInformationToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('5','newEmployeesInformationToolStripMenuItem', 'Employee Information', '3'); ";
            }

            if (!SelectMenu("employeeDesignationToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('6','employeeDesignationToolStripMenuItem', 'Employee Designation', '5'); ";
            }

            if (!SelectMenu("addAddressToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('7','addAddressToolStripMenuItem', 'Add Address', '3'); ";
            }

            if (!SelectMenu("addNewZilaNameToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('8','addNewZilaNameToolStripMenuItem', 'Add Zilla Name', '7'); ";
            }

            if (!SelectMenu("addNewUpozilaNameToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('9','addNewUpozilaNameToolStripMenuItem', 'Add Upazila', '7'); ";
            }

            if (!SelectMenu("addNewUnionToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('10','addNewUnionToolStripMenuItem', 'Add Union', '7'); ";
            }

            if (!SelectMenu("addNewVillageNameToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('11','addNewVillageNameToolStripMenuItem', 'Add Village', '7'); ";
            }

            if (!SelectMenu("medicineToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('12','medicineToolStripMenuItem', 'Medicine', '3'); ";
            }

            if (!SelectMenu("addCategoriToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('13','addCategoriToolStripMenuItem', 'Add Category', '12'); ";
            }

            if (!SelectMenu("genericNameToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('14','genericNameToolStripMenuItem', 'Generic Name', '12'); ";
            }

            if (!SelectMenu("addVendorToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('15','addVendorToolStripMenuItem', 'Add Vendor', '12'); ";
            }

            if (!SelectMenu("tredeNameToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('16','tredeNameToolStripMenuItem', 'Trade Name', '12'); ";
            }

            if (!SelectMenu("paymentGatewayToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('17','paymentGatewayToolStripMenuItem', 'Payment Gateway', '3'); ";
            }

            if (!SelectMenu("pharmacyToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('18','pharmacyToolStripMenuItem', 'Pharmacy', '0'); ";
            }

            if (!SelectMenu("saleToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('19','saleToolStripMenuItem', 'Sale', '18'); ";
            }

            if (!SelectMenu("saleReturnToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('20','saleReturnToolStripMenuItem', 'Sale Return', '19'); ";
            }

            if (!SelectMenu("purchaseToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('21','purchaseToolStripMenuItem', 'Purchase', '18'); ";
            }

            if (!SelectMenu("purchaseReturnToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('210','purchaseReturnToolStripMenuItem', 'Purchase Return', '21'); ";
            }

            if (!SelectMenu("stockUpdateToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('22','stockUpdateToolStripMenuItem', 'Stock Update', '18'); ";
            }

            if (!SelectMenu("dueCollectionToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('23','dueCollectionToolStripMenuItem', 'Due Collection', '18'); ";
            }

            if (!SelectMenu("vendorPaymentToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('24','vendorPaymentToolStripMenuItem', 'Vendor Payment', '18'); ";
            }

            if (!SelectMenu("reportsToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('25','reportsToolStripMenuItem', 'Report', '0'); ";
            }

            if (!SelectMenu("purchaseReportToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('26','purchaseReportToolStripMenuItem', 'Purchase Report', '25'); ";
            }

            if (!SelectMenu("purchaseReturnReportToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('2625','purchaseReturnReportToolStripMenuItem', 'Purchase Return', '26'); ";
            }

            if (!SelectMenu("expenseReportToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('27','expenseReportToolStripMenuItem', 'Expense Report', '25'); ";
            }

            if (!SelectMenu("saleReportToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('28','saleReportToolStripMenuItem', 'Sale Report', '25'); ";
            }

            if (!SelectMenu("stockReportToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('29','stockReportToolStripMenuItem', 'Stock Report', '25'); ";
            }

            if (!SelectMenu("dueCollectionReportToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('30','dueCollectionReportToolStripMenuItem', 'Due Collection Report', '25'); ";
            }

            if (!SelectMenu("vendorPaymentReportToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('31','vendorPaymentReportToolStripMenuItem', 'Vendor Payment Report', '25'); ";
            }

            if (!SelectMenu("ledgerToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('32','ledgerToolStripMenuItem', 'Ledger', '25'); ";
            }

            if (!SelectMenu("usersToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('33','usersToolStripMenuItem', 'User Management', '0'); ";
            }

            if (!SelectMenu("createUserToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('34','createUserToolStripMenuItem', 'Create User', '33'); ";
            }

            if (!SelectMenu("addRoleAndPermissionToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('35','addRoleAndPermissionToolStripMenuItem', 'Add Role And Permission', '33'); ";
            }

            if (!SelectMenu("userProfileToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('36','userProfileToolStripMenuItem', 'User Profile', '33'); ";
            }

            if (!SelectMenu("dataBackupToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('37','dataBackupToolStripMenuItem', 'Data Backup', '0'); ";
            }

            if (!SelectMenu("expenseToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('38','expenseToolStripMenuItem', 'Expense', '0'); ";
            }

            if (!SelectMenu("archiveToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('39','archiveToolStripMenuItem', 'Archive', '25'); ";
            }

            if (!SelectMenu("medicineUpdateToolStripMenuItem"))
            {
                menuCmd += "INSERT INTO TBL_MENU (ID, MENU_ITEM_NAME, MENU_NAME, MAIN_MENU_ID) VALUES ('40','medicineUpdateToolStripMenuItem', 'Medicine Update', '18'); ";
            }
            


            #endregion

            #region Insert setting menu

            // Invoice Inch = 2,3
            if (!SelectMenuSetting("1"))
            {
                menuCmd += "INSERT INTO TBL_MENU_SETTING VALUES (1, 'SaleInvoiceInch', 2);";
            }

            //Input Sample Type Price (purchase time) = 77
            if (!SelectMenuSetting("2"))
            {
                menuCmd += "INSERT INTO TBL_MENU_SETTING VALUES (2, 'InputSamplePrice', 0);";
            }


            #endregion

            if (string.IsNullOrEmpty(menuCmd))
            {
                MessageBox.Show("No update available");
            }
            else
            {
                MessageBox.Show(Db.QueryExecute(menuCmd) ? "Successfully Update...\nPlease Restart Application" : "Failed...");
            }

            wait.Close();

        }

        private bool SelectMenu(string menuItemName)
        {
            return Db.GetDataReader("SELECT MENU_ITEM_NAME FROM TBL_MENU WHERE MENU_ITEM_NAME='" + menuItemName + "'")
                .Read();
        }

        private bool SelectMenuSetting(string id)
        {
            return Db.GetDataReader("SELECT MENU_OPTION FROM TBL_MENU_SETTING WHERE ID='" + id + "'").Read();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadMenuSetting();
        }

        // Search Expiring Soon
        private void ExpiringSoon()
        {
            try
            {
                var query = "SELECT tblPurchase.ManufactureDate, tblPurchase.ExpiryDate, " +
                            "tblTradeName.TradeCode, tblStock.Qty " +
                            "FROM tblPurchase INNER JOIN tblTradeName ON tblPurchase.TradeCode=tblTradeName.TradeCode " +
                            "INNER JOIN tblStock ON tblTradeName.TradeCode=tblStock.TradeCode "+
                            "WHERE tblStock.Qty>0 AND tblStock.UnitPrice>0 AND tblPurchase.STATUS <> 'SO' ";
                
                var dt = Db.GetDataTable(query);
                var day = 0;

                foreach (DataRow row in dt.Rows)
                {
                    var exd = Convert.ToDateTime(row["ExpiryDate"].ToString()).Date;
                    var tex = exd - DateTime.Today.Date;
                    day += tex.Days <= 30 ? 1 : 0;
                }

                buttonExpiryQty.Text = day.ToString();
            }
            catch 
            {
                //
            }
        }

        //Login Session
        private void LoginSession()
        {
            try
            {
                if (GlobalSettings.EmployeeId == "")
                {
                    label2.Text = GlobalSettings.UserName;
                    label1.Text = "";
                }
                else
                {
                    var dr = Db.GetDataReader(
                        "SELECT tblEmployeeinfo.Name, tblDesignation.Name AS designation FROM tblEmployeeinfo INNER JOIN tblDesignation ON tblEmployeeinfo.DesignationID=tblDesignation.id WHERE tblEmployeeinfo.EmpId= '" +
                        GlobalSettings.EmployeeId + "'");
                    if (dr.HasRows)
                    {
                        dr.Read();
                        label2.Text = dr["Name"].ToString();
                        label1.Text = dr["designation"].ToString();
                    }
                }
            }
            catch
            {
                //
            }
        }

        private void GetByMenu()
        {
            if (GlobalSettings.UserRole == GlobalSettings.DevUser)
            {
                DevMenuShow();
                GlobalSettings.AddToArchive = true;
            }
            else
            {
                UserMenuShow();
            }
        }

        private void UserMenuShow()
        {
            try
            {
                var ds = Db.GetDataSet("SELECT MenuPermision FROM tblUserRole WHERE RoleName='" +
                                       GlobalSettings.UserRole + "'");

                var dt = Db.GetDataTable("SELECT * FROM TBL_MENU WHERE ID IN (" + ds.Tables[0].Rows[0][0] + ")");

                foreach (DataRow dataRow in dt.Rows)
                {
                    //for main menu
                    foreach (ToolStripMenuItem menuItem in menuStripMain.Items)
                    {
                        if (dataRow["MENU_ITEM_NAME"].ToString() == menuItem.Name)
                        {
                            menuItem.Visible = true;
                        }

                        //for sub menu in main menu
                        foreach (ToolStripMenuItem dropDownItem1 in menuItem.DropDownItems)
                        {
                            if (dataRow["ID"].ToString() == "39")
                            {
                                GlobalSettings.AddToArchive = true;
                            }
                            
                            if (dataRow["MENU_ITEM_NAME"].ToString() == dropDownItem1.Name)
                            {
                                dropDownItem1.Visible = true;
                            }

                            //for sub menu in sub menu
                            foreach (ToolStripMenuItem dropDownItem2 in dropDownItem1.DropDownItems)
                            {
                                if (dataRow["MENU_ITEM_NAME"].ToString() == dropDownItem2.Name)
                                {
                                    dropDownItem2.Visible = true;
                                }

                                //for sub menu in sub menu
                                foreach (ToolStripMenuItem dropDownItem3 in dropDownItem2.DropDownItems)
                                {
                                    if (dataRow["MENU_ITEM_NAME"].ToString() == dropDownItem2.Name)
                                    {
                                        dropDownItem3.Visible = true;
                                    }

                                    //for sub menu in sub menu
                                    foreach (ToolStripMenuItem dropDownItem4 in dropDownItem3.DropDownItems)
                                    {
                                        if (dataRow["MENU_ITEM_NAME"].ToString() == dropDownItem2.Name)
                                        {
                                            dropDownItem4.Visible = true;
                                        }

                                        //for sub menu in sub menu
                                        foreach (ToolStripMenuItem dropDownItem5 in dropDownItem4.DropDownItems)
                                        {
                                            if (dataRow["MENU_ITEM_NAME"].ToString() == dropDownItem2.Name)
                                            {
                                                dropDownItem5.Visible = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void DevMenuShow()
        {
            foreach (ToolStripMenuItem menuItem in menuStripMain.Items)
            {
                menuItem.Visible = true;

                foreach (ToolStripMenuItem dropDownItem1 in menuItem.DropDownItems)
                {
                    dropDownItem1.Visible = true;

                    foreach (ToolStripMenuItem dropDownItem2 in dropDownItem1.DropDownItems)
                    {
                        dropDownItem2.Visible = true;

                        foreach (ToolStripMenuItem dropDownItem3 in dropDownItem2.DropDownItems)
                        {
                            dropDownItem3.Visible = true;

                            foreach (ToolStripMenuItem dropDownItem4 in dropDownItem3.DropDownItems)
                            {
                                dropDownItem4.Visible = true;

                                foreach (ToolStripMenuItem dropDownItem5 in dropDownItem4.DropDownItems)
                                {
                                    dropDownItem5.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void HideMenu()
        {
            foreach (ToolStripMenuItem menuItem in menuStripMain.Items)
            {
                menuItem.Visible = false;

                foreach (ToolStripMenuItem dropDownItem1 in menuItem.DropDownItems)
                {
                    dropDownItem1.Visible = false;

                    foreach (ToolStripMenuItem dropDownItem2 in dropDownItem1.DropDownItems)
                    {
                        dropDownItem2.Visible = false;

                        foreach (ToolStripMenuItem dropDownItem3 in dropDownItem2.DropDownItems)
                        {
                            dropDownItem3.Visible = false;

                            foreach (ToolStripMenuItem dropDownItem4 in dropDownItem3.DropDownItems)
                            {
                                dropDownItem4.Visible = false;

                                foreach (ToolStripMenuItem dropDownItem5 in dropDownItem4.DropDownItems)
                                {
                                    dropDownItem5.Visible = false;
                                }
                            }
                        }
                    }
                }
            }

            //logoutToolStripMenuItem1.Visible = true;
        }

        public void LoadOfficeInformation()
        {
            try
            {
                label8.Text = GlobalSettings.OfficeInfo.Rows[0]["HospitalName"].ToString();
                label9.Text = GlobalSettings.OfficeInfo.Rows[0]["Address"].ToString();
                label11.Text = GlobalSettings.OfficeInfo.Rows[0]["PhoneNo"].ToString();
                labelYear.Text = " [ " + Settings.Default.CURRENT_PERIOD + " ]";


                if (GlobalSettings.OfficeInfo.Rows[0]["Logo"] != DBNull.Value)
                {
                    MemoryStream stream = new MemoryStream((byte[]) GlobalSettings.OfficeInfo.Rows[0]["Logo"]);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                else
                {
                    pictureBox1.Image = Resources.NoImage;
                }

            }
            catch
            {
                //
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to logout?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                Application.Exit();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void newPatientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewPatientInfo fnp = new frmNewPatientInfo();
            fnp.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblPDate.Text = DateTime.Now.ToString("dddd, dd-MMM-yyyy");
        }
        
        private void addNewVillageNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVillage village=new frmVillage();
            village.Show();
        }

        private void addNewUpozilaNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpozila upozila=new frmUpozila();
            upozila.Show();
        }

        private void addNewZilaNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZilla frmZila1=new frmZilla();
            frmZila1.Show();
        }
        
        private void addCategoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCategory fc = new frmAddCategory();
            fc.Show();
        }

        private void addVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddVendor fv = new frmAddVendor();
            fv.Show();
        }

        private void genericNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenericName fg = new frmGenericName();
            fg.Show();
        }

        private void tredeNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTradeName ft = new frmTradeName();
            ft.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase fp = new frmPurchase();
            fp.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSale fs = new frmSale();
            fs.Show();
        }

        private void hospitalsDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOfficeDetails fh = new frmOfficeDetails();
            fh.Show();
        }
        
        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUser au = new frmAddUser();
            au.Show();
        }
        
        private void newEmployeesInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEmployee de = new frmAddEmployee();
            de.Show();
        }

        private void employeeDesignationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesignation fd = new frmDesignation();
            fd.Show();
        }

        private void dataBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDbBackup dbb = new frmDbBackup();
            dbb.Show();
        }

        private void stockUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockUpdate fsu = new frmStockUpdate();
            fsu.Show();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseReport purchaseReport = new frmPurchaseReport();
            purchaseReport.Show();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            LoadOfficeInformation();
            if (panelLowStock.Visible)
            {
                LowStockRemainder();
            }
        }

        private void addNewUnionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnion union=new frmUnion();
            union.Show();
        }

        private void saleReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleReturn saleReturn=new frmSaleReturn();
            saleReturn.Show();
        }
        
        private void paymentGatewayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGateway gateway=new frmGateway();
            gateway.Show();
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExpenseReport report=new frmExpenseReport();
            report.Show();
        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saleReport= new frmSaleReport();
            saleReport.Show();
        }

        private void rEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmREG reg=new frmREG();
            reg.ShowDialog();
        }

        private void dayClosingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDayClosing dayClosing=new frmDayClosing();
            dayClosing.ShowDialog();
        }
        
        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReport f = new frmStockReport();
            f.Show();
        }
        
        private void dueCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDueCollection dueCollection=new frmDueCollection();
            dueCollection.Show();
        }

        private void vendorPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorPayment payment=new frmVendorPayment();
            payment.Show();
        }

        private void dueCollectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDueCollectionReport dueCollectionReport=new frmDueCollectionReport();
            dueCollectionReport.Show();
        }

        private void vendorPaymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorPaymentReport paymentReport=new frmVendorPaymentReport();
            paymentReport.Show();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLedger frmLedger=new frmLedger();
            frmLedger.Show();

        }

        private void expenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmExpense expense=new frmExpense();
            expense.Show();
        }
        
        private void addRoleAndPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenuPermission menuPermission=new frmMenuPermission();
            menuPermission.Show();
        }

        private void buttonExpiryQty_Click(object sender, EventArgs e)
        {
            frmExpiringItemsSearch itemsSearch = new frmExpiringItemsSearch();
            itemsSearch.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            buttonExpiryQty.PerformClick();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            buttonExpiryQty.PerformClick();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            buttonStockRemainder.PerformClick();
        }

        private void buttonStockRemainder_Click(object sender, EventArgs e)
        {
            frmStockRemainder remainder=new frmStockRemainder();
            remainder.Show();
        }

        private void globalSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGlobalSetting globalSetting=new frmGlobalSetting();
            globalSetting.ShowDialog();
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserProfile userProfile=new frmUserProfile();
            userProfile.ShowDialog();
        }

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArchiveReport archiveReport=new frmArchiveReport();
            archiveReport.Show();
        }

        private void medicineUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmMedicineUpdate().Show();
        }

        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmPurchaseReturn().Show();
        }

        private void purchaseReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmPurchaseReturnReport().Show();
        }
        

       
    }
}
