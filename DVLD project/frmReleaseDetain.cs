using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DetainedLicensesBuisnessLayer;
using DriversBuisnessLayer;
using DTOs;
using DVLD_project.Services;
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
using UsersBuisnessLayer;

namespace DVLD_project
{
    public partial class frmReleaseDetain : Form
    {
        private readonly ApplicationClientService _applicationClientService;
        private readonly DetainedLicenseClientService _detainedLicenseClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        private readonly UserClientService _userClientService;
        private readonly PeopleClientService _peopleClientService;
        int _detainid;
        public frmReleaseDetain(int DetainID = -1)
        {
            InitializeComponent();
            _driverClientService = new DriverClientService();
            _licenseClientService = new LicenseClientService();
            _applicationClientService = new ApplicationClientService();
            _detainedLicenseClientService = new DetainedLicenseClientService();
            _userClientService = new UserClientService();
            _peopleClientService = new PeopleClientService();
            this.AcceptButton = searchLicenseControl1.BtnSearch();
            lbAppFees.Text = "15";
            _detainid = DetainID;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void searchLicenseControl1_OnSearchClick(int LicenseID)
        {
            lbLicenseID.Text = LicenseID.ToString();         

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
            
            if (!await _licenseClientService.IsDetainedAsync(LicenseID))
            {
                btnSave.Enabled = false;
                lnkShowLicenseHistory.Enabled = false;
                lnkShowLicense.Enabled = false;
                MessageBox.Show("This license is not detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                btnSave.Enabled = true;
                lnkShowLicenseHistory.Enabled = true;
                lnkShowLicense.Enabled = true;
            }
            var Detain = await _detainedLicenseClientService.FindByLicenseIdAsync(LicenseID);
            lbDetainID.Text = Detain.DetainId.ToString();
            lbDetainDate.Text = Detain.DetainDate.ToString();
            lbFinefees.Text = Detain.FineFees.ToString();
            lbTotalFees.Text = (Detain.FineFees + int.Parse(lbAppFees.Text)).ToString();
            var user = await _userClientService.FindUserAsync(Detain.CreatedByUserId);
            lbUserName.Text = user.UserName;
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(int.Parse(lbLicenseID.Text));
            frm.ShowDialog();
        }

        private async void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var License = await _licenseClientService.FindLicenseByLicenseIDAsync(int.Parse(lbLicenseID.Text));
            var Driver = await _driverClientService.FindDriverByIDAsync(License.DriverId);
            var Person = await _peopleClientService.FindPersonAsync(Driver.PersonId);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Person.NationalNo);
            frm.ShowDialog();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            
            var Detain = await _detainedLicenseClientService.FindByDetainIdAsync(int.Parse(lbDetainID.Text));
            var License = await _licenseClientService.FindLicenseByLicenseIDAsync(Detain.LicenseId);
            var Driver = await _driverClientService.FindDriverByIDAsync(License.DriverId);
            var ActivateTask = _licenseClientService.ActivateLicenseAsync(License.LicenseId);
            var AppTask = _applicationClientService.AddApplication(new ApplicationDTO
            {
                ApplicantPersonId = Driver.PersonId,
                ApplicationDate = DateTime.Now,
                ApplicationTypeId = 5,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = 15,
                CreatedByUserId = CurrentUser.user.UserId
            });
            await Task.WhenAll(AppTask,ActivateTask);
            var App = AppTask.Result;          
            
            lbReleaseAppID.Text = App.ApplicationId.ToString();
            Detain.ReleaseApplicationId = App.ApplicationId;    
            Detain.ReleaseDate = DateTime.Now;
            Detain.ReleasedByUserId = CurrentUser.user.UserId;
            await _detainedLicenseClientService.ReleaseAsync(Detain.DetainId,Detain);
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Released Successfully");
            searchLicenseControl1.LoadLicenseInfo(License.LicenseId);
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;


        }

        private async void frmReleaseDetain_Load(object sender, EventArgs e)
        {
            if (_detainid != -1)
            {
                var Detain = await _detainedLicenseClientService.FindByDetainIdAsync(_detainid);
                searchLicenseControl1.LoadLicenseInfo(Detain.LicenseId);
                lbLicenseID.Text = Detain.LicenseId.ToString();
                lbDetainID.Text = _detainid.ToString();
                lbDetainDate.Text = Detain.DetainDate.ToString();
                lbFinefees.Text = Detain.FineFees.ToString();
                lbTotalFees.Text = (Detain.FineFees + int.Parse(lbAppFees.Text)).ToString();
                var user = await _userClientService.FindUserAsync(Detain.CreatedByUserId);
                lbUserName.Text = user.UserName;
                searchLicenseControl1.DisableFilter();
            }
        }
    }
}
