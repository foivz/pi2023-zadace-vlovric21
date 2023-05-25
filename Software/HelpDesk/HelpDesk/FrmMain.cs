using HelpDesk.Models;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void dgvRequestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ShowRequests();
        }
        private void ShowRequests()
        {
            List<Request> requests = RequestRepository.GetRequests();
            dgvRequestList.DataSource = requests;


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmSubmit frmSubmit = new FrmSubmit();
            frmSubmit.RequestSubmitted += FrmSubmit_RequestSubmitted;
            frmSubmit.ShowDialog();
        }
        private void FrmSubmit_RequestSubmitted(object sender, EventArgs e)
        {
            ShowRequests();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Request selectedRequest = dgvRequestList.CurrentRow.DataBoundItem as Request;
            if(selectedRequest != null)
            {
                RequestRepository.DeleteRequest(selectedRequest.Id);
                ShowRequests();
            }
        }
    }
}
