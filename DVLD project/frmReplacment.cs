using ApplicationBuisnessLayer;
using CurrentUserInformation;
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
    public partial class frmReplacment : Form
    {
        int _LicenseID;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly ApplicationClientService _applicationClientService;
        private readonly LicenseClientService _licenseClientService;
        private readonly DriverClientService _driverClientService;
        public frmReplacment()
        {
            InitializeComponent();
            _licenseClassClientService = new LicenseClassClientService();
            _licenseClassClientService = new LicenseClassClientService();
            _applicationClientService = new ApplicationClientService();
            _driverClientService = new DriverClientService();
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
            if (! await _licenseClientService.IsLicenseActiveAsync(LicenseID))
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

        private void frmReplacment_Load(object sender, EventArgs e)
        {
            lbAppDate.Text = DateTime.Now.ToString();          
            lbAppfees.Text = "5";
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
                ApplicationDate = Convert.ToDateTime(lbAppDate.Text),
                ApplicationTypeId = rbDamaged.Checked ? 3 : 4,
                ApplicationStatus = 3,
                LastStatusDate = DateTime.Now,
                PaidFees = Convert.ToInt32(lbAppfees.Text),
                CreatedByUserId = CurrentUser.user.UserId
            });
            lbReplacmentAppID.Text = App.ApplicationId.ToString();
            bool IsDamaged = rbDamaged.Checked;     
            var NewLicense = await _licenseClientService.AddLicenseAsync(new LicenseDTO
            {
                ApplicationId = App.ApplicationId,
                DriverId = Driver.DriverId,
                LicenseClass = OldLicense.LicenseClass,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(await _licenseClassClientService.GetLicenseClassValidityLengthById(OldLicense.LicenseClass)),
                Notes = "",
                PaidFees = await _licenseClassClientService.GetLicenseClassFeesById(OldLicense.LicenseClass),
                IsActive = true,
                IssueReason = (Byte)(IsDamaged ? 3 : 4),
                CreatedByUserId = CurrentUser.user.UserId
            });
            lbReplacedLicenseID.Text = NewLicense.LicenseId.ToString();
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Replacedd Successfully with id = {NewLicense.LicenseId}");
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;
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
            frmLicenseInfo frm = new frmLicenseInfo(int.Parse(lbReplacedLicenseID.Text));
            frm.ShowDialog();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLost.Checked)
            {
                lbMode.Text = "Replacment For Lost License";
                lbAppfees.Text = "10";
            }
            else
            {
                lbMode.Text = "Replacment For Damaged License";
                lbAppfees.Text = "5";
            }
        }
    }
}
