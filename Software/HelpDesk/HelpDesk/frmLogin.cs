using HelpDesk.Models;
using HelpDesk.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDesk
{
    public partial class FrmLogin : Form
    {
        public static Submitter LoggedSubmitter { get; set; }
        public FrmLogin()
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
                LoggedSubmitter = SubmitterRepository.GetSubmitter(txtUsername.Text);
                if(LoggedSubmitter != null && LoggedSubmitter.Password == txtPassword.Text)
                {
                    FrmMain frmMain = new FrmMain();
                    Hide();
                    frmMain.ShowDialog();
                    Close();
                    
                } else
                {
                    MessageBox.Show("Neispravni podatci!", "Neuspješna prijava", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
