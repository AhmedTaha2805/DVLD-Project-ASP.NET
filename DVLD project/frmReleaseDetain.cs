using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DetainedLicensesBuisnessLayer;
using DriversBuisnessLayer;
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
        
        public frmReleaseDetain(int DetainID = -1)
        {
            InitializeComponent();
            this.AcceptButton = searchLicenseControl1.BtnSearch();
            lbAppFees.Text = "15";
            if (DetainID != -1)
            {
                clsDetainedLicenses Detain = clsDetainedLicenses.FindDetainByDetainID(DetainID);
                searchLicenseControl1.LoadLicenseInfo(Detain.LicenseID);
                lbLicenseID.Text = Detain.LicenseID.ToString();
                lbDetainID.Text = DetainID.ToString();
                lbDetainDate.Text = Detain.DetainDate.ToString();
                lbFinefees.Text = Detain.FineFees.ToString();            
                lbTotalFees.Text = (Detain.FineFees + int.Parse(lbAppFees.Text)).ToString();
                clsUsers user = clsUsers.FindUser(Detain.CreatedByUserID);
                lbUserName.Text = user.UserName;
                searchLicenseControl1.DisableFilter();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchLicenseControl1_OnSearchClick(int LicenseID)
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
            clsDetainedLicenses Detain = clsDetainedLicenses.FindDetainByLicenseID(LicenseID);
            lbDetainID.Text = Detain.DetainID.ToString();
            lbDetainDate.Text = Detain.DetainDate.ToString();
            lbFinefees.Text = Detain.FineFees.ToString();
            lbTotalFees.Text = (Detain.FineFees + int.Parse(lbAppFees.Text)).ToString();
            clsUsers user = clsUsers.FindUser(Detain.CreatedByUserID);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (searchLicenseControl1.IsNull())
            {
                return;
            }
            
            clsDetainedLicenses Detain = clsDetainedLicenses.FindDetainByDetainID(int.Parse(lbDetainID.Text));
            clsLicenses License = clsLicenses.FindLicenseByLicenseID(Detain.LicenseID);
            clsDrivers Driver = clsDrivers.FindDriverByID(License.DriverID);
            clsApplications App = new clsApplications();
            clsLicenses.ActivateLicense(License.LicenseID);
            App.PersonID = Driver.PersonID;
            App.AppDate = DateTime.Now;
            App.AppTypeID = 5;
            App.AppStatus = 3;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = 15;
            App.UserID = CurrentUser.user.UserID;
            App.AddApplication();
            lbReleaseAppID.Text = App.AppID.ToString();
            Detain.ReleaseAppID = App.AppID;    
            Detain.ReleaseDate = DateTime.Now;
            Detain.ReleasedByUserID = CurrentUser.user.UserID;
            Detain.Release();
            searchLicenseControl1.DisableFilter();
            btnSave.Enabled = false;
            MessageBox.Show($"License Released Successfully");
            searchLicenseControl1.LoadLicenseInfo(License.LicenseID);
            lnkShowLicense.Enabled = true;
            lnkShowLicenseHistory.Enabled = true;


        }
    }
}
