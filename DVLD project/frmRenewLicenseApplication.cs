using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DriversBuisnessLayer;
using DTOs;
using DVLD_project.Services;
using InternationalLicensesBuisnessLayer;
using LicenseClassesBuisnessLayer;
using LicensesBuisnessLayer;
using PeopleBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class frmRenewLicenseApplication : Form
    {
        int _LicenseID;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        private readonly PeopleClientService _peopleClientService;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
            _licenseClientService = new LicenseClientService();
            _applicationClientService = new ApplicationClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _driverClientService = new DriverClientService();
            _peopleClientService = new PeopleClientService();
            this.AcceptButton = searchLicenseControl1.BtnSearch();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void searchLicenseControl1_OnSearchClick(int LicenseID)
        {
            lbOldLicenseID.Text = LicenseID.ToString();
            _LicenseID = LicenseID;
            var License = await _licenseClientService.FindLicenseByLicenseIDAsync(LicenseID);
            lbLicenseFees.Text = (await _licenseClassClientService.GetLicenseClassFeesById(License.LicenseClass)).ToString();
            lbTotalFees.Text = (int.Parse(lbLicenseFees.Text) + int.Parse(lbAppFees.Text)).ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears(await _licenseClassClientService.GetLicenseClassValidityLengthById(License.LicenseClass)).ToString();
            if (!await _licenseClientService.IsExpiredAsync(LicenseID, DateTime.Now)) 
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;
                MessageBox.Show("License has not expired yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                lnkShowLicenseHistory.Enabled = true;
            }
            if (!await _licenseClientService.IsLicenseActiveAsync(LicenseID))
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;
                MessageBox.Show("This License is not active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                lnkShowLicenseHistory.Enabled = true;
            }
            
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            lbAppDate.Text = DateTime.Now.ToString();
            lbIssueDate.Text = DateTime.Now.ToString();
            lbAppFees.Text = "7";
            lbUsername.Text = CurrentUser.user.UserName;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            
            var OldLicense = await _licenseClientService.FindLicenseByLicenseIDAsync(int.Parse(lbOldLicenseID.Text));
            await _licenseClientService.DeActivateLicenseAsync(_LicenseID);
            var Driver = await _driverClientService.FindDriverByIDAsync(OldLicense.DriverId);
            var App = await _applicationClientService.AddApplication(new ApplicationDTO
            {
                ApplicantPersonId = Driver.PersonId,
                ApplicationDate = DateTime.Now,
                ApplicationTypeId = 2,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = 7,
                CreatedByUserId = CurrentUser.user.UserId
            });
            lbRenewAppID.Text = App.ApplicationId.ToString();
            var NewLicense = await _licenseClientService.AddLicenseAsync(new LicenseDTO
            {
                ApplicationId = App.ApplicationId,
                DriverId = Driver.DriverId,
                LicenseClass = OldLicense.LicenseClass,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(await _licenseClassClientService.GetLicenseClassValidityLengthById(OldLicense.LicenseClass)),
                Notes = txtnotes.Text,
                PaidFees = decimal.Parse(lbLicenseFees.Text),
                IsActive = true,
                IssueReason = 2,
                CreatedByUserId = CurrentUser.user.UserId
            });
            lbRenewedLicenseID.Text = NewLicense.LicenseId.ToString();         
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Renewd Successfully with id = {NewLicense.LicenseId}");
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;
        }

        private async void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var License = await _licenseClientService.FindLicenseByLicenseIDAsync(_LicenseID);
            var Driver = await _driverClientService.FindDriverByIDAsync(License.DriverId);
            var Person = await _peopleClientService.FindPersonAsync(Driver.PersonId);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Person.NationalNo);
            frm.ShowDialog();
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(int.Parse(lbRenewedLicenseID.Text));
            frm.ShowDialog();
        }
    }
}
