using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ShA_Park
{
  public partial class frmLogin : Form, IShowPassword
  {
    int Age;
    FileStream fs;
    StreamReader sr;
    public frmLogin()
    {
      InitializeComponent();
    }
    public frmLogin(int age)
    {
      InitializeComponent();
      this.Age = age;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      fs.Seek(0, SeekOrigin.Begin);
      string line;

      if (txtUsername.Text == "" || txtPassword.Text == "")
      {
        MessageBox.Show("Please enter Complete Username and Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }


      while ((line = sr.ReadLine()) != null)
      {
        string[] field = line.Split('|');

        if (txtUsername.Text.ToLower() == field[2].ToLower() && txtPassword.Text == field[3])
        {
          Age = int.Parse(field[1]);
          sr.Close();
          Start start = new Start(Age, $"Welcome {char.ToUpper(field[0][0]) + field[0].Substring(1).ToLower()}"); //Convert first letter of the name to a character so we can make it capital -- then use the substring method to select the start index after the first letter to prevent including it twice and make sure the rest of the name is small
          this.Hide();
          start.Show();
          return;
        }
      }
    
      MessageBox.Show("Wrong Username or Password. Please try again", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      txtPassword.Text = "";
      txtPassword.Focus();
    }

    private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
    {
      ShowPassword();
    }

    private void frmLogin_Load(object sender, EventArgs e)
    {
      ShowPassword();
      fs = new FileStream("Clientinfo.txt", FileMode.OpenOrCreate, FileAccess.Read);
      sr = new StreamReader(fs);

    }
    private void button2_Click(object sender, EventArgs e)
    {
      txtPassword.Clear();
      txtUsername.Clear();
    }

    private void label6_Click(object sender, EventArgs e)
    {
      fs.Close();
      frmRegister frm = new frmRegister();
      this.Hide();
      frm.ShowDialog();

    }
    public void ShowPassword()
    {
      txtPassword.MaxLength = 14;

      if (!checkbxShowPass.Checked)
      {
        txtPassword.PasswordChar = '•';
      }
      else
      {
        txtPassword.PasswordChar = '\0';
      }
    }

  }
}
