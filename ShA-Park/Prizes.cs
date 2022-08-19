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
    public partial class Prizes : Form
    {
        double tickets;

        public Prizes()
        {
            InitializeComponent();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if(txt1.Text == "")
            {
                try { 
            tickets = double.Parse(txt1.Text);
                }
                catch
                {
                    MessageBox.Show("Put tickets");
                    return;
                }
            }
            btnInsert.Visible = !true;
            tickets = double.Parse(txt1.Text);
            txt1.Visible = false;
            lblDisplay.Text = tickets.ToString();
            lblDisplay.Visible = true;
            lblCheck.Visible = true;
            label1.Visible = true;

        }
        private void prize1_Click(object sender, EventArgs e)
        {
            msgBox(400);
        }

        private void prize2_Click(object sender, EventArgs e)
        {
            msgBox(200);
        }

        private void prize3_Click(object sender, EventArgs e)
        {
            msgBox(300);
        }

        private void prize4_Click(object sender, EventArgs e)
        {
            msgBox(150);
        }

        private void prize5_Click(object sender, EventArgs e)
        {
            msgBox(320);
        }

        private void prize6_Click(object sender, EventArgs e)
        {
            msgBox(270);
        }
        private void prize7_Click(object sender, EventArgs e)
        {
            msgBox(400);
        }

        private void prize8_Click(object sender, EventArgs e)
        {
            msgBox(500);
        }

        private void prize9_Click(object sender, EventArgs e)
        {
            msgBox(310);
        }

        private void prize10_Click(object sender, EventArgs e)
        {
            msgBox(700);
        }

        private void prize11_Click(object sender, EventArgs e)
        {
            msgBox(1000);
        }

        private void prize12_Click(object sender, EventArgs e)
        {
            msgBox(1500);
        }

        private void Prizes_Load(object sender, EventArgs e)
        {
            lblDisplay.Visible = false;
            lblCheck.Visible = false;
            label1.Visible = false;
        }
        private void Prizes_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        //My methods:
        private void msgBox(int prz)
        {
            DialogResult x = MessageBox.Show("Are you sure you want to buy this item", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x == DialogResult.No)
            {
                return;
            }
            if (tickets < prz)
                MessageBox.Show("You don't have enough tickets to buy this item", "Insufficient Tickets", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            else
            {
                tickets -= prz;
                lblDisplay.Text = tickets.ToString();
                MessageBox.Show($"Transaction Succesful, You have {tickets} tickets left", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
