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
        int _detainid;
        public frmReleaseDetain(int DetainID = -1)
        {
            InitializeComponent();
            _applicationClientService = new ApplicationClientService();
            _detainedLicenseClientService = new DetainedLicenseClientService();
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
            clsLicenses License = clsLicenses.FindLicenseByLicenseID(LicenseID);

            if (clsLicenses.IsExpired(LicenseID, DateTime.Now))
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
            
            if (!License.IsDetained())
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
            clsUsers user = clsUsers.FindUser(Detain.CreatedByUserId);
            lbUserName.Text = user.UserName;
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(int.Parse(lbLicenseID.Text));
            frm.ShowDialog();
        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicenses License = clsLicenses.FindLicenseByLicenseID(int.Parse(lbLicenseID.Text));
            clsDrivers Driver = clsDrivers.FindDriverByID(License.DriverID);
            clsPeople Person = clsPeople.FindPerson(Driver.PersonID);
            frmShowLicenseHistory frm = new frmShowLicenseHistory(Person.NationalNum);
            frm.ShowDialog();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            
            var Detain = await _detainedLicenseClientService.FindByDetainIdAsync(int.Parse(lbDetainID.Text));
            clsLicenses License = clsLicenses.FindLicenseByLicenseID(Detain.LicenseId);
            clsDrivers Driver = clsDrivers.FindDriverByID(License.DriverID);
            clsLicenses.ActivateLicense(License.LicenseID);
            var App = await _applicationClientService.AddApplication(new ApplicationDTO
            {
                ApplicantPersonId = Driver.PersonID,
                ApplicationDate = DateTime.Now,
                ApplicationTypeId = 5,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = 15,
                CreatedByUserId = CurrentUser.user.UserID          
            });          
            
            lbReleaseAppID.Text = App.ApplicationId.ToString();
            Detain.ReleaseApplicationId = App.ApplicationId;    
            Detain.ReleaseDate = DateTime.Now;
            Detain.ReleasedByUserId = CurrentUser.user.UserID;
            await _detainedLicenseClientService.ReleaseAsync(Detain.DetainId,Detain);
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Released Successfully");
            searchLicenseControl1.LoadLicenseInfo(License.LicenseID);
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
                clsUsers user = clsUsers.FindUser(Detain.CreatedByUserId);
                lbUserName.Text = user.UserName;
                searchLicenseControl1.DisableFilter();
            }
        }
    }
}
