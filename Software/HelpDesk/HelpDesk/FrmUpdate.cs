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
        private Request request;
        public FrmUpdate(Request selectedRequest)
        {
            InitializeComponent();
            request = selectedRequest;
        }

        private void FrmUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
