using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalDrivingLicenseApplicationsBuisnessLayer;
using ApplicationBuisnessLayer;
using ApplicationTypesBuisnessLayer;
using LicenseClassesBuisnessLayer;
using PeopleBuisnessLayer;
using UsersBuisnessLayer;

namespace DVLD_project
{
    public partial class ApplicationInfoControl : UserControl
    {
        public ApplicationInfoControl()
        {
            InitializeComponent();                
        }

        public void LoadAppInfo(int LDLAppID)
        {
            clsLocalLicenseApplication licenseApplication = clsLocalLicenseApplication.FindApplication(LDLAppID);
            lbLDLAppID.Text = LDLAppID.ToString();
            lbLicenseClass.Text = clsLicenseClasses.GetLicenseClassName(licenseApplication.LicenseClassID);
            lbPassedTests.Text = $"{clsLocalLicenseApplication.FindNumberOfPassedTests(LDLAppID).ToString()}/3";
            clsApplications App = clsApplications.FindApplication(licenseApplication.AppId);
            lbAppID.Text = App.AppID.ToString();
            lbStatus.Text = clsApplications.GetStatus(App.AppStatus);
            lbFees.Text = App.PaidFees.ToString();
            lbType.Text = clsApplicationTypes.GetApplicationType(App.AppTypeID);
            clsPeople person = clsPeople.FindPerson(App.PersonID);
            lbApplicantName.Text = $"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName} ";
            lbDate.Text = App.AppDate.ToString();
            lbStatusDate.Text = App.LastStatusDate.ToString();
            clsUsers User = clsUsers.FindUser(App.UserID);
            lbUserName.Text = User.UserName;
            if(lbStatus.Text == "Completed"){
                lnkShowLicense.Enabled = true;
            }

        }

        private int GetPersonID()
        {
            clsApplications App = clsApplications.FindApplication(int.Parse(lbAppID.Text));
            return App.PersonID;
        }

        public int AppID()
        {
            return Convert.ToInt32(lbAppID.Text);
        }


        private void lnkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(GetPersonID());
            frm.ShowDialog();
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(int.Parse(lbLDLAppID.Text));
            frm.ShowDialog();

        }
    }
}
