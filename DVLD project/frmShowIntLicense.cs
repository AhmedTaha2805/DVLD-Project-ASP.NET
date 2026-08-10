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
    public partial class frmShowIntLicense : Form
    {
        public frmShowIntLicense(int LicenseID)
        {
            InitializeComponent();
            intLicenseInfoControl1.LoadLicenseInfo(LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
