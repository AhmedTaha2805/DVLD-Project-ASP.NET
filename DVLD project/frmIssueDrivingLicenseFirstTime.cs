using ApplicationBuisnessLayer;
using CurrentUserInformation;
using DriversBuisnessLayer;
using LicenseClassesBuisnessLayer;
using LicensesBuisnessLayer;
using LocalDrivingLicenseApplicationsBuisnessLayer;
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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        int CLDLAppID;
        public frmIssueDrivingLicenseFirstTime(int LDLAppID)
        {
            InitializeComponent();
            CLDLAppID = LDLAppID;
            applicationInfoControl1.LoadAppInfo(LDLAppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLocalLicenseApplication LApp = clsLocalLicenseApplication.FindApplication(CLDLAppID);
            clsApplications App = clsApplications.FindApplication(LApp.AppId);
            clsLicenses license = new clsLicenses();
            license.AppID = LApp.AppId;
            license.LicenseClassID = LApp.LicenseClassID;
            license.IssueDate = DateTime.Now;
            int length = clsLicenseClasses.GetValidityLength(license.LicenseClassID);
            license.ExpirationDate = DateTime.Now.AddYears(length);
            license.notes = txtnotes.Text;
            license.PaidFees = clsLicenseClasses.GetLicenseClassFees(license.LicenseClassID);
            license.IsActive = true;
            license.IssueReason = 1;
            license.CreatedByUserID = CurrentUser.user.UserID;
            clsDrivers driver = new clsDrivers();
            driver.PersonID = App.PersonID;
            driver.CreatedByUserID = CurrentUser.user.UserID;
            driver.CreatedDate = DateTime.Now;
            driver.AddDriver();
            license.DriverID = driver.DriverID;
            license.AddLicense();
            App.LastStatusDate = DateTime.Now;
            App.AppStatus = 3;
            App.Update();
            
            MessageBox.Show("License Added Successfully","Congratulations",MessageBoxButtons.OK);
        }
    }
}
