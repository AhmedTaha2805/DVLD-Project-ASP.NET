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
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int id)
        {
            InitializeComponent();
            licenseInfoControl1.LoadLicenseInfo(id);
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
