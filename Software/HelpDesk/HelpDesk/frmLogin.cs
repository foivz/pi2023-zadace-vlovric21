using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk
{
    public partial class frmLogin : Form
    {
        string username = "test";
        string password = "test";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                MessageBox.Show("Unesite korisničko ime!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(txtPassword.Text == "")
            {
                MessageBox.Show("Unesite lozinku!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                if(txtUsername.Text == username && txtPassword.Text == password)
                {
                    MessageBox.Show("Uspješna prijava!", "Prijavljeni ste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Neispravni podatci!", "Neuspješna prijava", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
