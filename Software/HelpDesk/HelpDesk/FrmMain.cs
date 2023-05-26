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
            dgvRequestList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvRequestList.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


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
            List<Request> requests = RequestRepository.GetRequests(FrmLogin.LoggedSubmitter.Id);
            dgvRequestList.DataSource = requests;

            dgvRequestList.DefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44);
            dgvRequestList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44);
            dgvRequestList.DefaultCellStyle.ForeColor = Color.White;
            dgvRequestList.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44);
            dgvRequestList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 214, 224);
            dgvRequestList.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRequestList.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(44, 44, 44);
            dgvRequestList.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(194, 214, 224);

            dgvRequestList.EnableHeadersVisualStyles = false;


            dgvRequestList.Columns["Id_submitter"].Visible = false;
            dgvRequestList.Columns["Id"].HeaderText = "Broj zahtjeva";
            dgvRequestList.Columns["FullName"].HeaderText = "Zahtjev podnio";
            dgvRequestList.Columns["Time"].HeaderText = "Vrijeme";
            dgvRequestList.Columns["Description"].HeaderText = "Opis";
            dgvRequestList.Columns["undertaken"].HeaderText = "Preuzeo";
            dgvRequestList.Columns["Comment"].HeaderText = "Komentari";

            foreach (DataGridViewColumn column in dgvRequestList.Columns)
            {
                column.HeaderCell.Style.BackColor = Color.FromArgb(44, 44, 44);
                column.HeaderCell.Style.ForeColor = Color.White;
                column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            }

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Request selectedRequest = dgvRequestList.CurrentRow.DataBoundItem as Request;
            if (selectedRequest != null)
            {
                FrmUpdate frmUpdate = new FrmUpdate(selectedRequest);
                frmUpdate.RequestUpdated += FrmUpdate_RequestUpdated;
                frmUpdate.ShowDialog();
            }
        }
        private void FrmUpdate_RequestUpdated(object sender, EventArgs e)
        {
            ShowRequests();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            List<Request> requestsSearch = RequestRepository.GetRequestsSearch(FrmLogin.LoggedSubmitter.Id, search);
            if (requestsSearch.Count == 0)
            {
                MessageBox.Show("Nije pronađen nijedan zahtjev!", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else
            {
            dgvRequestList.DataSource = requestsSearch;

            dgvRequestList.Columns["Id_submitter"].Visible = false;
            dgvRequestList.Columns["Id"].HeaderText = "Broj zahtjeva";
            dgvRequestList.Columns["FullName"].HeaderText = "Zahtjev podnio";
            dgvRequestList.Columns["Time"].HeaderText = "Vrijeme";
            dgvRequestList.Columns["Description"].HeaderText = "Opis";
            dgvRequestList.Columns["undertaken"].HeaderText = "Preuzeo";
            dgvRequestList.Columns["Comment"].HeaderText = "Komentari";
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ShowRequests();
            txtSearch.Text = null;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }
    }
}
