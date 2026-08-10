using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DriversBuisnessLayer;
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
        public frmReplacment()
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

        private void frmReplacment_Load(object sender, EventArgs e)
        {
            lbAppDate.Text = DateTime.Now.ToString();          
            lbAppfees.Text = "5";
            lbUsername.Text = CurrentUser.user.UserName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            clsApplications App = new clsApplications();
            App.AppDate = Convert.ToDateTime(lbAppDate.Text);
            if (rbDamaged.Checked)
            {
                App.AppTypeID = 3;
            }
            else
            {
                App.AppTypeID = 4;
            }
            App.AppStatus = 3;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = Convert.ToInt32(lbAppfees.Text);
            App.UserID = CurrentUser.user.UserID;
            clsLicenses OldLicense = clsLicenses.FindLicenseByLicenseID(int.Parse(lbOldLicenseID.Text));
            clsLicenses.DeActivateLicense(_LicenseID);
            clsDrivers Driver = clsDrivers.FindDriverByID(OldLicense.DriverID);
            App.PersonID = Driver.PersonID;
            App.AddApplication();
            lbReplacmentAppID.Text = App.AppID.ToString();
            clsLicenses NewLicense = new clsLicenses();
            NewLicense.AppID = App.AppID;
            NewLicense.DriverID = Driver.DriverID;
            NewLicense.LicenseClassID = OldLicense.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClasses.GetValidityLength(NewLicense.LicenseClassID));
            NewLicense.notes ="";
            NewLicense.PaidFees = clsLicenseClasses.GetLicenseClassFees(OldLicense.LicenseClassID);
            NewLicense.IsActive = true;
            if (rbDamaged.Checked)
            {
                NewLicense.IssueReason = 3;
            }
            else
            {
                NewLicense.IssueReason = 4;
            }
            
            NewLicense.CreatedByUserID = CurrentUser.user.UserID;
            NewLicense.AddLicense();
            lbReplacedLicenseID.Text = NewLicense.LicenseID.ToString();
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Replacedd Successfully with id = {NewLicense.LicenseID}");
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
