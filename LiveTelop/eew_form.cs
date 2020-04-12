using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveTelop
{
    public partial class eew_form : Form
    {
        Form1 f1;

        public eew_form(Form1 f)
        {
            InitializeComponent();
            f1 = f;
        }

        private void eew_form_Load(object sender, EventArgs e)
        {
            f1.eew_form_show = true;
            if (Properties.Settings.Default.EEWSize.Width == 0) Properties.Settings.Default.Upgrade();
            if (Properties.Settings.Default.EEWSize.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {

            }
            else
            {
                this.WindowState = Properties.Settings.Default.EEWState;
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                this.Location = Properties.Settings.Default.EEWLocation;
                this.Size = Properties.Settings.Default.EEWSize;
            }
        }

        private void eew_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.eew_form_show = false;
        }
    }
}
