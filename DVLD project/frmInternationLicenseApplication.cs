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
        public frmInternationLicenseApplication()
        {
            InitializeComponent();
            _applicationClientService = new ApplicationClientService();
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
            clsLicenses license = clsLicenses.FindLicenseByLicenseID(int.Parse(lbLocalLicenseID.Text));
            clsDrivers Driver = clsDrivers.FindDriverByID(license.DriverID);
            var App = await _applicationClientService.AddApplication(new ApplicationDTO
            {
                ApplicationDate = DateTime.Now,
                ApplicationTypeId = 6,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = 51,
                CreatedByUserId = CurrentUser.user.UserID,
                ApplicantPersonId = Driver.PersonID
            });
            lbAppID.Text = App.ApplicationId.ToString();
            clsIntLicenses intLicense = new clsIntLicenses();
            intLicense.AppID = App.ApplicationId;
            intLicense.DriverID = Driver.DriverID;
            intLicense.LocalLicenseID = license.LicenseID;
            intLicense.IssueDate = DateTime.Now;
            intLicense.ExpirationDate = DateTime.Now.AddYears(1);
            intLicense.IsActive = true;
            intLicense.CreatedByUserID = CurrentUser.user.UserID;
            intLicense.AddLicense();
            lbIntLicenseID.Text = intLicense.LicenseID.ToString();
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Added Successfully with id = {intLicense.LicenseID}");
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;

        }

        private void searchLicenseControl1_OnSearchClick_1(int LicenseID)
        {
            lbLocalLicenseID.Text = LicenseID.ToString();
            _LicenseID = LicenseID;
            if (clsIntLicenses.HasInternationalLicense(LicenseID))
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
            clsLicenses License = clsLicenses.FindLicenseByLicenseID(LicenseID);
            if (License.LicenseClassID != 3)
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

            if (!clsLicenses.IsLicenseActive(LicenseID))
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

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses License = clsLicenses.FindLicenseByLicenseID(_LicenseID);
            clsDrivers Driver = clsDrivers.FindDriverByID(License.DriverID);
            clsPeople Person = clsPeople.FindPerson(Driver.PersonID);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Person.NationalNum);
            frm.ShowDialog();
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowIntLicense frm = new frmShowIntLicense(int.Parse(lbIntLicenseID.Text));
            frm.ShowDialog();
        }
    }
}
