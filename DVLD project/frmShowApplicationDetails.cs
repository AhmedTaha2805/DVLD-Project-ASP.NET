using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class frmShowApplicationDetails : Form
    {
        int _id;
        public frmShowApplicationDetails(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmShowApplicationDetails_Load(object sender, EventArgs e)
        {
            await applicationInfoControl1.LoadAppInfo(_id);
        }
    }
}
