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
  public partial class frmRegister : Form, IShowPassword
  {
    public FileStream fs;
    public StreamWriter sw;
    public StreamReader sr;


    public frmRegister()
    {
      InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {

      fs.Seek(0, SeekOrigin.Begin);
      string line;

      while ((line = sr.ReadLine()) != null)
      {
        string[] field = line.Split('|');
        if (txtUsername.Text.ToLower() == field[2])
        {
          MessageBox.Show("Username already exists, please choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtUsername.Clear();
          return;
        }
      }
      if (txtUsername.Text == "" || txtPassword.Text == "" || txtComPassword.Text == "" || txtAge.Text == "" || txtName.Text == "")
        MessageBox.Show("Registration Failed. Please fill in all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else if (txtPassword.Text == txtComPassword.Text)
      {
        fs.Seek(0, SeekOrigin.End);
        sw.WriteLine($"{txtName.Text}|{txtAge.Text}|{txtUsername.Text.ToLower()}|{txtPassword.Text}");
        sw.Close();
        fs.Close();

        /*
        StreamWriter sw = new StreamWriter("Client information.txt");
        sw.WriteLine(txtName.Text);
        sw.WriteLine(txtAge.Text);
        sw.WriteLine(txtUsername.Text.ToLower());
        sw.WriteLine(txtPassword.Text);
        sw.Flush();
        sw.Close();
        */

        label6_Click(sender, e);
        MessageBox.Show("Your Account has been Succesfully Created", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        MessageBox.Show("Passwords does not match.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtPassword.Clear();
        txtComPassword.Clear();
        txtPassword.Focus();
        
      }
    }

    private void checkbxShowPass_CheckedChanged(object sender, EventArgs e)
    {
      ShowPassword();
    }

    private void label6_Click(object sender, EventArgs e)
    {
      sw.Close();
      fs.Close();
      frmLogin frm = new frmLogin();
      this.Hide();
      frm.Show();
    }

    private void frmRegister_Load(object sender, EventArgs e)
    {
      ShowPassword();
      fs = new FileStream("ClientInfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
      sw = new StreamWriter(fs);
      sr = new StreamReader(fs);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      txtName.Clear();
      txtAge.Clear();
      txtUsername.Clear();
      txtPassword.Clear();
      txtComPassword.Clear();
    }
    public void ShowPassword()
    {
      txtPassword.MaxLength = 14;
      txtComPassword.MaxLength = 14;

      if (!checkbxShowPass.Checked)
      {
        txtPassword.PasswordChar = '•';
        txtComPassword.PasswordChar = '•';
      }
      else
      {
        txtPassword.PasswordChar = '\0';
        txtComPassword.PasswordChar = '\0';
      }
    }
  }
}
