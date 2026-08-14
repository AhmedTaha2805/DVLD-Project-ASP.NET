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
        public frmDetainLicense()
        {
            InitializeComponent();
            _detainedLicenseClientService = new DetainedLicenseClientService();
            this.AcceptButton = searchLicenseControl1.BtnSearch();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchLicenseControl1_OnSearchClick(int LicenseID)
        {
            lbLicenseID.Text = LicenseID.ToString();
            _LicenseID = LicenseID;
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
            if (!clsLicenses.IsLicenseActive(LicenseID))
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
            if (License.IsDetained())
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
                CreatedByUserId = CurrentUser.user.UserID,
            });
            clsLicenses.DeActivateLicense(_LicenseID);
        
            lbDetainID.Text = DetainedLicense.DetainId.ToString();
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Detained Successfully");
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;
        }
    }
}
