using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_MS_SSC.Common;

namespace Pharmacy_MS_SSC
{
    public partial class frmREG : Form
    {
        // SQL connection        
        static DbConnection dbCon = new DbConnection();
        SqlConnection conn = new SqlConnection(dbCon.ConnectionString());

        public frmREG()
        {
            InitializeComponent();

            GetMACAddress();
        }

        public void GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }

            textBoxIdentifire.Text = sMacAddress;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblIdentifire (Identifire) VALUES('" + textBoxIdentifire.Text.Trim() + "')", conn);
            cmd.ExecuteNonQuery();

            textBoxIdentifire.Clear();

        }
    }
}
