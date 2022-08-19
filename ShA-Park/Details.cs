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
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome welc = new Welcome();
            this.Hide();
            welc.Show();
        }
    }
}
