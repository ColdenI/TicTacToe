using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            webBrowser1.DocumentText = Properties.Resources.about;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://akylinandrej.wixsite.com/colden-i");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
             Process.Start("https://akylinandrej.wixsite.com/colden-i/tic-tac-toe");
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Process.Start("https://akylinandrej.wixsite.com/colden-i");
        }
    }
}
