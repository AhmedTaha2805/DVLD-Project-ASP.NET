using DVLD_project.Services;
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
        private readonly LicenseClientService _licenseClientService;
        public SearchLicenseControl()
        {
            InitializeComponent();
            _licenseClientService = new LicenseClientService();
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

        private async void btnSearchLicense_Click(object sender, EventArgs e)
        {
            bool IsFound = false;
            if (!string.IsNullOrWhiteSpace(txtFind.Text))
            {
                IsFound = await licenseInfoControl1.LoadLicenseInfoByID(int.Parse(txtFind.Text));
                
                if (IsFound)
                {
                    var License = await _licenseClientService.FindLicenseByLicenseIDAsync(int.Parse(txtFind.Text));                  

                    SearchClicked(int.Parse(txtFind.Text));
                }
                    
            }
        }

        public async void LoadLicenseInfo(int LicenseID)
        {
            await licenseInfoControl1.LoadLicenseInfoByID(LicenseID);
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
