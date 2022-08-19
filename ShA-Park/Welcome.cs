using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShA_Park
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult x = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
                e.Cancel = !true;
            else
                e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }

        private void Purchase_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Details detail = new Details();
            detail.Show();
            this.Hide();
        }
    }
}
