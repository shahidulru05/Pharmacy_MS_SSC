using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pharmacy_MS_SSC.Common
{
    public partial class frmGlobalSetting : Form
    {
        public frmGlobalSetting()
        {
            InitializeComponent();
            LoadPreviousSettings();
        }

        private void LoadPreviousSettings()
        {
            comboBoxSaleMemoInch.Text = GlobalSettings.SaleMemoSize.ToString();
            checkBoxInputSample.Checked = GlobalSettings.InputSamplePrice;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var inputSample = checkBoxInputSample.Checked ? 77 : 0;

            var query = "UPDATE TBL_MENU_SETTING SET CODE = '" + comboBoxSaleMemoInch.Text + "' WHERE ID=1;";
            query += "UPDATE TBL_MENU_SETTING SET CODE = '" + inputSample + "' WHERE ID=2;";

            var isUpdate = Db.QueryExecute(query);
            MessageBox.Show(isUpdate ? "Setting update complete\nPlease restart the application and affect this change" : "Error");
            Application.Restart();

        }
    }
}
