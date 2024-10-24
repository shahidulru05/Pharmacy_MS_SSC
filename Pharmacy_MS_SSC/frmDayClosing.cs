using System;
using System.Windows.Forms;

namespace Pharmacy_MS_SSC
{
    public partial class frmDayClosing : Form
    {
        public frmDayClosing()
        {
            InitializeComponent();
        }


        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labelPin_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }
    }
}
