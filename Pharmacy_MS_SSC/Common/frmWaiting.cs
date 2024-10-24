using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_MS_SSC.Common
{
    public partial class frmWaiting : Form
    {
        public Action Worker { get; set; }

        public frmWaiting()
        {
            InitializeComponent();
            TopMost = true;
        }

        public static void InvokeAction(Control control, MethodInvoker action)
        {
            bool invokeRequired = control.InvokeRequired;
            if (invokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        public frmWaiting(Action worker)
        {
            InitializeComponent();
            if (worker==null)
            {
                throw new ArgumentNullException();
            }

            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Worker==null) return;
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(ss => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
