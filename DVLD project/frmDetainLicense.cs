using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DetainedLicensesBuisnessLayer;
using DriversBuisnessLayer;
using DTOs;
using DVLD_project.Services;
using LicenseClassesBuisnessLayer;
using LicensesBuisnessLayer;
using PeopleBuisnessLayer;
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
    public partial class frmDetainLicense : Form
    {
        int _LicenseID;
        private readonly DetainedLicenseClientService _detainedLicenseClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        public frmDetainLicense()
        {
            InitializeComponent();
            _driverClientService = new DriverClientService();
            _licenseClientService = new LicenseClientService();
            _detainedLicenseClientService = new DetainedLicenseClientService();
            this.AcceptButton = searchLicenseControl1.BtnSearch();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void searchLicenseControl1_OnSearchClick(int LicenseID)
        {
            lbLicenseID.Text = LicenseID.ToString();
            _LicenseID = LicenseID;
            var License = await _licenseClientService.FindLicenseByLicenseIDAsync(LicenseID);
            
            if (await _licenseClientService.IsExpiredAsync(LicenseID, DateTime.Now))
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;   
                lnkShowLicense.Enabled = false;
                MessageBox.Show("License has expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                lnkShowLicenseHistory.Enabled = true;
                lnkShowLicense.Enabled = true;
            }
            if (! await _licenseClientService.IsLicenseActiveAsync(LicenseID))
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;
                lnkShowLicense.Enabled = false;
                MessageBox.Show("This License is not active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                lnkShowLicenseHistory.Enabled = true;
                lnkShowLicense.Enabled = true;
            }
            if (await _licenseClientService.IsDetainedAsync(LicenseID))
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;
                lnkShowLicense.Enabled = false;
                MessageBox.Show("This license is already detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                lnkShowLicenseHistory.Enabled = true;
                lnkShowLicense.Enabled = true;
            }
            //if (License.WasDetainedAndReleased())
            //{
            //    btnSave.Enabled = false;
            //    lnkShowLicenseHistory.Enabled = false;
            //    lnkShowLicense.Enabled = false;
            //    MessageBox.Show("The license Detain has already been released", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //{
            //    btnSave.Enabled = true;
            //    lnkShowLicenseHistory.Enabled = true;
            //    lnkShowLicense.Enabled = true;
            //}            
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lbDetainDate.Text = DateTime.Now.ToString();
            lbUserName.Text = CurrentUser.user.UserName;
        }

        private async void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var License = await _licenseClientService.FindLicenseByLicenseIDAsync(_LicenseID);
            var Driver = await _driverClientService.FindDriverByIDAsync(License.DriverId);
            clsPeople Person = clsPeople.FindPerson(Driver.PersonId);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Person.NationalNum);
            frm.ShowDialog();
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {           
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            var DetainedLicense = await _detainedLicenseClientService.DetainAsync(new DetainedLicenseDTO
            {
                LicenseId = _LicenseID,
                DetainDate = DateTime.Now,
                FineFees = 150,
                CreatedByUserId = CurrentUser.user.UserId,
            });
            await _licenseClientService.DeActivateLicenseAsync(_LicenseID);
        
            lbDetainID.Text = DetainedLicense.DetainId.ToString();
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Detained Successfully");
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;
        }
    }
}
