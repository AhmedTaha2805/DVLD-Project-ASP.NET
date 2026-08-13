using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CountriesBuisnessLayer;
using LicenseClassesBuisnessLayer;
using ApplicationBuisnessLayer;
using LocalDrivingLicenseApplicationsBuisnessLayer;
using CurrentUserInformation;
using UsersBuisnessLayer;
using DVLD_project.Services;
using DTOs;

namespace DVLD_project
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        int LAppID = -1;
        private readonly LicenseClassClientService _licenseClassClientService;
        private readonly ApplicationClientService _applicationClientService;
        public frmNewLocalDrivingLicenseApplication(int id = -1)
        {
            InitializeComponent();
            _licenseClassClientService = new LicenseClassClientService();
            _applicationClientService = new ApplicationClientService();
            this.AcceptButton = personDetailsWithFilter1.BtnSearch();
            lbDate.Text = DateTime.Now.ToString();
            lbFees.Text = "15";
            lbUsername.Text = CurrentUser.user.UserName;
            LAppID = id;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = ApplicationInfoTab;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int personid = personDetailsWithFilter1.GetPersonID();
            int LicenseClassID = await _licenseClassClientService.GetLicenseClassIdByClassName(cbLicenseClass.Text);

            if (personid == -1)
            {
                MessageBox.Show("Choose a person","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (clsLocalLicenseApplication.ThereIsDuplicateApp(personid, LicenseClassID))
            {
                MessageBox.Show("You have made this application before", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            if (string.IsNullOrEmpty(cbLicenseClass.Text))
            {
                MessageBox.Show("Choose a License Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LAppID != -1)
            {
                clsLocalLicenseApplication LApp = clsLocalLicenseApplication.FindApplication(LAppID);
                await _applicationClientService.UpdateApplicationByPersonId(LApp.AppId, personid);
                clsLocalLicenseApplication.UpdateApplication(LAppID, LicenseClassID);
                MessageBox.Show("Application Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            else
            {
                var App = await _applicationClientService.AddApplication(new ApplicationDTO
                {
                    ApplicantPersonId = personid,
                    ApplicationDate = Convert.ToDateTime(lbDate.Text),
                    ApplicationStatus = 1,
                    ApplicationTypeId = 1,
                    LastStatusDate = Convert.ToDateTime(lbDate.Text),
                    PaidFees = int.Parse(lbFees.Text),
                    CreatedByUserId = CurrentUser.user.UserID                
                });
                clsLocalLicenseApplication LocalApp = new clsLocalLicenseApplication();
                LocalApp.AppId = App.ApplicationId;
                LocalApp.LicenseClassID = LicenseClassID;
                LocalApp.AddApplication();
                lbAppID.Text = LocalApp.LocalAppID.ToString();
                MessageBox.Show("Application Added Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            
        }

        private async void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if(LAppID != -1) {
                clsLocalLicenseApplication LApp = clsLocalLicenseApplication.FindApplication(LAppID);
                var App = await _applicationClientService.FindApplication(LApp.AppId);
                lbDate.Text = App.ApplicationDate.ToString();
                lbFees.Text = App.PaidFees.ToString();
                clsUsers user = clsUsers.FindUser(App.CreatedByUserId);
                lbUsername.Text = user.UserName;
                lbAppID.Text = LAppID.ToString();
                cbLicenseClass.SelectedIndex = LApp.LicenseClassID - 1;
                personDetailsWithFilter1.LoadPersonInfo(App.ApplicantPersonId);
            }
            var LicenseClasses = await _licenseClassClientService.GetAllLicenseClasses();
            foreach (var LicenseClass in LicenseClasses)
            {
                cbLicenseClass.Items.Add(LicenseClass.ClassName);
            }
        }
    }
}
