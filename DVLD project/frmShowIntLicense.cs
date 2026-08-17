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
        int _LicenseID;
        public frmShowIntLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void frmShowIntLicense_Load(object sender, EventArgs e)
        {
            await intLicenseInfoControl1.LoadLicenseInfo(_LicenseID);
        }
    }
}
