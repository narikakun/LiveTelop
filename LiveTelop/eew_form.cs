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
            this.BackColor = System.Drawing.Color.FromArgb(250, 245, 0);
        }

        private void eew_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.eew_form_show = false;
        }
    }
}
