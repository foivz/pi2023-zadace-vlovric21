using HelpDesk.Repositories;
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
    public partial class FrmSubmit : Form
    {
        public event EventHandler RequestSubmitted;
        public FrmSubmit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var submitter = FrmLogin.LoggedSubmitter;
            string description = txtDescription.Text;
            string status = "Zaprimljen";
            submitter.PerformSubmittion(6, description, status, submitter);
            RequestSubmitted?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void txtIdentity_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmSubmit_Load(object sender, EventArgs e)
        {
            txtIdentity.Text = FrmLogin.LoggedSubmitter.ToString();
            txtDate.Text = DateTime.Now.ToString();
        }
    }
}
