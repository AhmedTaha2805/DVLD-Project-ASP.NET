using InternationalLicensesBuisnessLayer;
using LicensesBuisnessLayer;
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
    public partial class SearchLicenseControl : UserControl
    {
        public SearchLicenseControl()
        {
            InitializeComponent();
        }

        public event Action<int> OnSearchClick;

        protected virtual void SearchClicked(int LicenseID)
        {
            Action<int> handler = OnSearchClick;
            if (handler != null)
            {
                handler(LicenseID);
            }
        }

        public Button BtnSearch()
        {
            return(btnSearchLicense);
        }

        private void btnSearchLicense_Click(object sender, EventArgs e)
        {
            bool IsFound = false;
            if (!string.IsNullOrWhiteSpace(txtFind.Text))
            {
                IsFound = licenseInfoControl1.LoadLicenseInfoByID(int.Parse(txtFind.Text));
                
                if (IsFound)
                {
                    clsLicenses License = clsLicenses.FindLicenseByLicenseID(int.Parse(txtFind.Text));                  

                    SearchClicked(int.Parse(txtFind.Text));
                }
                    
            }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            licenseInfoControl1.LoadLicenseInfoByID(LicenseID);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void DisableFilter()
        {
            groupBox1.Enabled = false;
        }

        public bool IsNull()
        {
            return (licenseInfoControl1.IsNull());
        }

        

    }
}
