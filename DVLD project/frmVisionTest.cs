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
using TestAppointmentsBuisnessLayer;
using LicenseClassesBuisnessLayer;
using PeopleBuisnessLayer;
using ApplicationBuisnessLayer;
using CurrentUserInformation;


namespace DVLD_project
{
    public partial class frmVisionTest : Form
    {
        bool IsDone = false;
        bool _Retake = false;
        int Person_ID;
        int AppointID;
        public frmVisionTest(int id,int Appointid = -1,bool Retake = false,int RTAppID = -1)
        {
            InitializeComponent();
            AppointID = Appointid;
            clsLocalLicenseApplication LDLApp = clsLocalLicenseApplication.FindApplication(id);
            clsApplications App = clsApplications.FindApplication(LDLApp.AppId);
            lbAppID.Text = id.ToString();
            lbClass.Text = clsLicenseClasses.GetLicenseClassName(LDLApp.LicenseClassID);
            clsPeople person = clsPeople.FindPerson(App.PersonID);
            Person_ID = person.Id;
            lbName.Text = person.FullName();
            lbTrial.Text = clsTestAppointments.GetNumberOfTrials(LDLApp.LocalAppID, 1).ToString();
            lbFees.Text = "10";
            if (Retake)
            {
                groupBox2.Enabled = true;
                lbTitle.Text = "Schedule Retake Test";
                _Retake = Retake;
                lbRetakeAppID.Text = clsApplications.GetNextID().ToString();
                int total = Convert.ToInt32(lbFees.Text) + 5;
                lbTotalFees.Text = total.ToString();
            }
             
            IsDone = true;

        }

        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(AppointID != -1)
            {
                clsTestAppointments.UpdateApplicationDate(AppointID, dateTimePicker1.Value);
                MessageBox.Show("Appointment Updated Successfully", "Congratulations", MessageBoxButtons.OK);
            }
            else if (IsDone)
            {
                clsTestAppointments TestApp = new clsTestAppointments();
                TestApp.TestTypeID = 1;
                TestApp.PaidFees = 10;
                TestApp.LocalDrivingLicenseApplicationID = int.Parse(lbAppID.Text);
                TestApp.AppointmentDate = dateTimePicker1.Value;
                TestApp.CreatedByUserID = CurrentUser.user.UserID;
                if (_Retake)
                {                                      
                    clsApplications App = new clsApplications();
                    App.PersonID = Person_ID;App.PaidFees = 5;App.AppStatus = 3;
                    App.AppDate = DateTime.Now;App.AppTypeID = 7;
                    App.LastStatusDate = DateTime.Now;
                    App.UserID = CurrentUser.user.UserID;
                    App.AddApplication();
                    TestApp.RetakeTestApplicationID = int.Parse(lbRetakeAppID.Text);
                }
                TestApp.AddTestAppointment();
                MessageBox.Show("Appointment Added Successfully", "Congratulations", MessageBoxButtons.OK);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
