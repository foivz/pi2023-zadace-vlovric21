using HelpDesk.Models;
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
    public partial class FrmUpdate : Form
    {
        public event EventHandler RequestUpdated;
        private Request request;
        private Submittion submittion;
        public FrmUpdate(Request selectedRequest)
        {
            InitializeComponent();
            submittion = new Submittion();
            request = selectedRequest;
            submittion.Id = request.Id;
            submittion.Name = FrmLogin.LoggedSubmitter.Id;
            submittion.Description = request.Description;
            submittion.Date = request.Time;
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            SetFormText();
            txtIdentity.Text = FrmLogin.LoggedSubmitter.ToString();
            txtDate.Text = submittion.Date.ToString();
            txtDescription.Text = submittion.Description;
            
        }
        private void SetFormText()
        {
            Text = "Zahtjev sa ID: " + request.Id.ToString(); ;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var submitter = FrmLogin.LoggedSubmitter;
            string description = txtDescription.Text;
            string status = "Zaprimljen";
            int id = submittion.Id;
            submitter.PerformUpdate(id, description, status, submitter);
            RequestUpdated?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
