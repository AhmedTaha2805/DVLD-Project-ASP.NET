using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DriversBuisnessLayer;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_project
{
    public partial class frmRenewLicenseApplication : Form
    {
        int _LicenseID;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
            this.AcceptButton = searchLicenseControl1.BtnSearch();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchLicenseControl1_OnSearchClick(int LicenseID)
        {
            lbOldLicenseID.Text = LicenseID.ToString();
            _LicenseID = LicenseID;
            clsLicenses License = clsLicenses.FindLicenseByLicenseID(LicenseID);
            lbLicenseFees.Text = clsLicenseClasses.GetLicenseClassFees(License.LicenseClassID).ToString();
            lbTotalFees.Text = (int.Parse(lbLicenseFees.Text) + int.Parse(lbAppFees.Text)).ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears(clsLicenseClasses.GetValidityLength(License.LicenseClassID)).ToString();
            if (!clsLicenses.IsExpired(LicenseID, DateTime.Now)) 
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

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            lbAppDate.Text = DateTime.Now.ToString();
            lbIssueDate.Text = DateTime.Now.ToString();
            lbAppFees.Text = "7";
            lbUsername.Text = CurrentUser.user.UserName;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            clsApplications App = new clsApplications();
            App.AppDate = DateTime.Now;
            App.AppTypeID = 2;
            App.AppStatus = 3;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = 7;
            App.UserID = CurrentUser.user.UserID;
            clsLicenses OldLicense = clsLicenses.FindLicenseByLicenseID(int.Parse(lbOldLicenseID.Text));
            clsLicenses.DeActivateLicense(_LicenseID);
            clsDrivers Driver = clsDrivers.FindDriverByID(OldLicense.DriverID);
            App.PersonID = Driver.PersonID;
            App.AddApplication();
            lbRenewAppID.Text = App.AppID.ToString();
            clsLicenses NewLicense = new clsLicenses();
            NewLicense.AppID = App.AppID;
            NewLicense.DriverID = Driver.DriverID;
            NewLicense.LicenseClassID = OldLicense.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.GetValidityLength(NewLicense.LicenseClassID));
            NewLicense.notes = txtnotes.Text;
            NewLicense.PaidFees = int.Parse(lbLicenseFees.Text);
            NewLicense.IsActive = true;
            NewLicense.IssueReason = 2;
            NewLicense.CreatedByUserID = CurrentUser.user.UserID;
            NewLicense.AddLicense();
            lbRenewedLicenseID.Text = NewLicense.LicenseID.ToString();         
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Renewd Successfully with id = {NewLicense.LicenseID}");
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;
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
            frmLicenseInfo frm = new frmLicenseInfo(int.Parse(lbRenewedLicenseID.Text));
            frm.ShowDialog();
        }
    }
}
