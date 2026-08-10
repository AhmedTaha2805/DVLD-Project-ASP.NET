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

namespace DVLD_project
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        int LAppID = -1;
        public frmNewLocalDrivingLicenseApplication(int id = -1)
        {
            InitializeComponent();
            this.AcceptButton = personDetailsWithFilter1.BtnSearch();
            lbDate.Text = DateTime.Now.ToString();
            lbFees.Text = "15";
            lbUsername.Text = CurrentUser.user.UserName;
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();
            foreach (DataRow dr in dt.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"].ToString());
            }
            if (id != -1)
            {
                LAppID = id;    
                clsLocalLicenseApplication LApp = clsLocalLicenseApplication.FindApplication(id);
                clsApplications App = clsApplications.FindApplication(LApp.AppId);
                lbDate.Text = App.AppDate.ToString();
                lbFees.Text = App.PaidFees.ToString();
                clsUsers user = clsUsers.FindUser(App.UserID);
                lbUsername.Text = user.UserName;
                lbAppID.Text = id.ToString();
                cbLicenseClass.SelectedIndex = LApp.LicenseClassID - 1;
                personDetailsWithFilter1.LoadPersonInfo(App.PersonID);
            }           
            
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = ApplicationInfoTab;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int personid = personDetailsWithFilter1.GetPersonID();
            int LicenseClassID = clsLicenseClasses.GetLicenseClassID(cbLicenseClass.Text);

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
                clsApplications.UpdateApplication(LApp.AppId, personid);
                clsLocalLicenseApplication.UpdateApplication(LAppID, LicenseClassID);
                MessageBox.Show("Application Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            else
            {
                clsApplications App = new clsApplications();
                App.PersonID = personid;
                App.AppDate = Convert.ToDateTime(lbDate.Text);
                App.AppStatus = 1;
                App.AppTypeID = 1;
                App.LastStatusDate = Convert.ToDateTime(lbDate.Text);
                App.PaidFees = int.Parse(lbFees.Text);
                App.UserID = CurrentUser.user.UserID; ;
                App.AddApplication();
                clsLocalLicenseApplication LocalApp = new clsLocalLicenseApplication();
                LocalApp.AppId = App.AppID;
                LocalApp.LicenseClassID = LicenseClassID;
                LocalApp.AddApplication();
                lbAppID.Text = LocalApp.LocalAppID.ToString();
                MessageBox.Show("Application Added Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            
        }
    }
}
