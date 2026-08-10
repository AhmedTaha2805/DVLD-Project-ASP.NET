using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDrivingLicenseApplicationsDataAccessLayer;

namespace LocalDrivingLicenseApplicationsBuisnessLayer
{
    public class clsLocalLicenseApplication
    {
        public int LocalAppID {  get; set; }

        public int AppId { get; set; }

        public int LicenseClassID { get; set; }

        public clsLocalLicenseApplication()
        {
            this.LocalAppID = -1;
            this.AppId = -1;
            this.LicenseClassID = -1;
        }

        public clsLocalLicenseApplication(int LaID,int AppID,int LicenseClassID)
        {
            this.LocalAppID = LaID;
            this.AppId = AppID;
            this.LicenseClassID = LicenseClassID;
        }

        public static clsLocalLicenseApplication FindApplication(int id)
        {
            int appid = 0;
            int licenseClassID = 0;
            if(LocalDrivingLicenseApplicationsDataAccess.FindLocalApplication(id,ref appid,ref licenseClassID))
            {
                return new clsLocalLicenseApplication(id,appid,licenseClassID); 
            }
            else
            {
                return null;
            }
        }

        public void AddApplication()
        {
            this.LocalAppID = LocalDrivingLicenseApplicationsDataAccess.AddApplication(this.AppId,this.LicenseClassID);
        }

        public static DataTable GetAllLocalApps()
        {
            return (LocalDrivingLicenseApplicationsDataAccess.GetAllLocalApps());
        }

        public static int FindNumberOfPassedTests(int LocalAppID)
        {
            return (LocalDrivingLicenseApplicationsDataAccess.FindNumberOfPassedTests(LocalAppID));
        }

        public static bool ThereIsDuplicateApp(int PersonID,int LicenseClassID)
        {
            return (LocalDrivingLicenseApplicationsDataAccess.ThereIsDuplicateApp(PersonID,LicenseClassID));
        }

        public static void UpdateApplication(int id, int LCID)
        {
            LocalDrivingLicenseApplicationsDataAccess.UpdateApplication(id,LCID);
        }

        public static void DeleteApplication(int id)
        {
            LocalDrivingLicenseApplicationsDataAccess.DeleteApplication(id);
        }
    }
}
