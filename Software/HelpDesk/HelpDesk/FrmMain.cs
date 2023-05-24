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
    }
}
