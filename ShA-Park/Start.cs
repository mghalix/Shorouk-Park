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

    public partial class Start : Form
    {
        int Age;
        double balance = 0;
        string display;
        decimal Roller = 50;
        decimal Discovery = 60;
        decimal HorrorHouse = 70;
        decimal FerrisWheel = 60;
        decimal VideoGames = 150;
        public Start()
        {
            InitializeComponent();
        }
        public Start(int age, string name)
        {
            InitializeComponent();
            label17.Text = name;
            this.Age = age;
        }

     
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            check(checkBox1, txt1);
            AgeCondition(checkBox1, txt1);
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            check(checkBox2, txt2);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            check(checkBox3, txt3);
            AgeCondition(checkBox3, txt3);

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            check(checkBox4, txt4);
        }


        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            check(checkBox5, txt5);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Logic();

            txtBalance.Text = display;
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                e.Cancel = !true;
            else
                e.Cancel = true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            balance += int.Parse(BalVal.Text);
            BalVal.Clear();
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            BalDis.Text = balance.ToString();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            Logic();

            txtBalance.Text = display;

            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked)
            {
                DialogResult result = MessageBox.Show($"Your Total Cost is {txtBalance.Text}, do you want to buy?", "Purchasing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    if (balance < double.Parse(txtBalance.Text))
                    {
                        MessageBox.Show("Please Recharge Your Card Before Buying Tickets", "Insuffiecient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        balance -= double.Parse(txtBalance.Text);
                        BalDis.Text = balance.ToString();
                        txtBalance.Text = "0.00";
                        MessageBox.Show($"You have {balance} L.E left in your balance", "Transaction Succesful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            //return;
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            Prizes prize = new Prizes();
            prize.Show();
            this.Hide();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            //for(int i = 1; i<=5; i++)
            //{
            //    txt<i>.DataBindings.Add("Enabled", checkBox<i>, "Checked");
            //}
            // --> How to use the following in for loop

            txt1.DataBindings.Add("Enabled", checkBox1, "Checked");
            txt2.DataBindings.Add("Enabled", checkBox2, "Checked");
            txt3.DataBindings.Add("Enabled", checkBox3, "Checked");
            txt4.DataBindings.Add("Enabled", checkBox4, "Checked");
            txt5.DataBindings.Add("Enabled", checkBox5, "Checked");
            BalVal.MaxLength = 6;
        }
        
        //My methods:

        private void check(CheckBox box, NumericUpDown num)
        {
            if (box.Checked)
            {
                num.ReadOnly = false;
                num.Value = 1;
            }
            else
            {
                num.ReadOnly = true;
                num.Value = 0;
            }
        }
        private void AgeCondition(CheckBox check, NumericUpDown num)
        {
            if (Age < 18 && check.Checked)
            {
                check.Checked = false;
                MessageBox.Show("You must be 13 years or older to play this Game", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void Logic()
        {
            if (txt1.ReadOnly)
            {
                Roller = 0;
            }
            else
            {
                Roller *= txt1.Value;
            }

            if (txt2.ReadOnly)
            {
                Discovery = 0;
            }
            else
            {
                Discovery *= txt2.Value;
            }

            if (txt3.ReadOnly)
            {
                HorrorHouse = 0;
            }
            else
            {
                HorrorHouse *= txt3.Value;
            }

            if (txt4.ReadOnly)
            {
                FerrisWheel = 0;
            }
            else
            {
                FerrisWheel *= txt4.Value;
            }

            if (txt5.ReadOnly)
            {
                VideoGames = 0;
            }
            else
            {
                VideoGames *= txt5.Value;
            }

            display = string.Format(Roller + Discovery + HorrorHouse + FerrisWheel + VideoGames + "");
            txtBalance.Text = display;
            Roller = 50;
            Discovery = 60;
            FerrisWheel = 60;
            HorrorHouse = 70;
            VideoGames = 150;

            if (checkBox1.CheckState == CheckState.Unchecked && checkBox2.CheckState == CheckState.Unchecked && checkBox3.CheckState == CheckState.Unchecked && checkBox4.CheckState == CheckState.Unchecked && checkBox5.CheckState == CheckState.Unchecked)
            {
                MessageBox.Show("Please select a game", "", MessageBoxButtons.OK );

            }
        }

    }
}


