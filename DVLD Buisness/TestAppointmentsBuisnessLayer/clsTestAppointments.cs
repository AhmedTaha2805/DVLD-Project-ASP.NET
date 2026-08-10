using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppointmentsDataAccessLayer;

namespace TestAppointmentsBuisnessLayer
{
    public class clsTestAppointments
    {
        public int AppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }

        public clsTestAppointments() 
        {
            this.AppointmentID = 0;
            this.TestTypeID = 0;
            this.LocalDrivingLicenseApplicationID = 0;
            this.CreatedByUserID = 0;
            this.IsLocked = false;
            this.AppointmentDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.RetakeTestApplicationID = 0;                    
        }
        
        public void AddTestAppointment()
        {
            this.AppointmentID =  TestAppointmentsDataAccess.AddTestAppointment(this.TestTypeID,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,this.PaidFees,this.CreatedByUserID,this.IsLocked,this.RetakeTestApplicationID);
        }

        public static int GetNumberOfTrials(int LDLAppID , int TestTypeID)
        {
            return (TestAppointmentsDataAccess.GetNumberOfTrials(LDLAppID, TestTypeID));
        }

        public static DataTable GetAppointments(int AppID,int Tid)
        {
            return (TestAppointmentsDataAccess.GetAllAppointments(AppID,Tid));

        }

        public static void LockAppointment(int AppID)
        {
            TestAppointmentsDataAccess.LockAppointment(AppID);
        }

        public static bool HasUnlockedAppointment(int AppID,int TestTypeID)
        {
            return (TestAppointmentsDataAccess.HasUnlockedAppointment(AppID, TestTypeID));
        }

        public static void UpdateApplicationDate(int id , DateTime date)
        {
            TestAppointmentsDataAccess.UpdateApplicationDate(id, date);
        }

        public static void DeleteAppointmentsWithAppID(int id)
        {
            TestAppointmentsDataAccess.DeleteAppointmentsWithAppID(id);
        }

        public static DataTable GetAllAppointmentsWithID(int AppID)
        {
            return (TestAppointmentsDataAccess.GetAllAppointmentsWithID(AppID));
        }

    }
}
