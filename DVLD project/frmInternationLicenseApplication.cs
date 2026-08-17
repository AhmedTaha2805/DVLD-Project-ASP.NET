using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DriversBuisnessLayer;
using DTOs;
using DVLD_project.Services;
using InternationalLicensesBuisnessLayer;
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

    public partial class frmInternationLicenseApplication : Form
    {
        int _LicenseID;
        private readonly ApplicationClientService _applicationClientService;
        private readonly InternationalLicenseClientService _internationalLicenseClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        private readonly PeopleClientService _peopleClientService;
        public frmInternationLicenseApplication()
        {
            InitializeComponent();
            _driverClientService = new DriverClientService();
            _licenseClientService = new LicenseClientService();
            _applicationClientService = new ApplicationClientService();
            _internationalLicenseClientService = new InternationalLicenseClientService();
            _peopleClientService = new PeopleClientService();
            this.AcceptButton = searchLicenseControl1.BtnSearch();
        }

        private void frmInternationLicenseApplication_Load(object sender, EventArgs e)
        {
            lbIssueDate.Text = DateTime.Now.ToString();
            lbAppDate.Text = DateTime.Now.ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears(10).ToString();
            lbFees.Text = "51";
            lbUsername.Text = CurrentUser.user.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            var license = await _licenseClientService.FindLicenseByLicenseIDAsync(int.Parse(lbLocalLicenseID.Text));
            var Driver = await _driverClientService.FindDriverByIDAsync(license.DriverId);
            var App = await _applicationClientService.AddApplication(new ApplicationDTO
            {
                ApplicationDate = DateTime.Now,
                ApplicationTypeId = 6,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = 51,
                CreatedByUserId = CurrentUser.user.UserId,
                ApplicantPersonId = Driver.PersonId
            });
            lbAppID.Text = App.ApplicationId.ToString();
            var IntLicense = await _internationalLicenseClientService.AddLicenseAsync(new InternationalLicenseDTO
            {
                ApplicationId = App.ApplicationId,
                DriverId = Driver.DriverId,
                IssuedUsingLocalLicenseId = license.LicenseId,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(1),
                IsActive = true,
                CreatedByUserId = CurrentUser.user.UserId
            });
            lbIntLicenseID.Text = IntLicense.InternationalLicenseId.ToString();
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Added Successfully with id = {IntLicense.InternationalLicenseId}");
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;

        }

        private async void searchLicenseControl1_OnSearchClick_1(int LicenseID)
        {
            lbLocalLicenseID.Text = LicenseID.ToString();
            _LicenseID = LicenseID;
            if (await _internationalLicenseClientService.HasInternationalLicenseAsync(LicenseID))
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;
                MessageBox.Show("Person already has an international license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                lnkShowLicenseHistory.Enabled = true;
            }
            var License = await _licenseClientService.FindLicenseByLicenseIDAsync(LicenseID);
            if (License.LicenseClass != 3)
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;
                MessageBox.Show("License must be class 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            frmShowIntLicense frm = new frmShowIntLicense(int.Parse(lbIntLicenseID.Text));
            frm.ShowDialog();
        }
    }
}
