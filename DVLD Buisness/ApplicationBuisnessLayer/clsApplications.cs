using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ApplicationsDataAccessLayer;

namespace ApplicationBuisnessLayer
{
    public class clsApplications
    {
        public int AppID {  get; set; }

        public int PersonID { get; set; }

        public DateTime AppDate { get; set; }

        public int AppTypeID { get; set; }

        public int AppStatus { get; set; }

        public DateTime LastStatusDate { get; set; }

        public int PaidFees { get; set; }

        public int UserID { get; set; }

        public clsApplications(int Appid, int personID, DateTime appDate, int appTypeID, int appStatus, DateTime lastStatusDate, int paidFees, int userID)
        {
            this.AppID = Appid;
            this.PersonID = personID;
            this.AppDate = appDate;
            this.AppTypeID = appTypeID;
            this.AppStatus = appStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.UserID = userID;
        }

        public clsApplications()
        {
            this.AppID=0;
            this.PersonID=0;
            this.AppStatus=0;
            this.AppDate = DateTime.MinValue;
            this.AppTypeID = 0;
            this.LastStatusDate= DateTime.MinValue;
            this.PaidFees=0;
            this.UserID = 0;
        }

        public static clsApplications FindApplication(int id)
        {

            int personID = 0;
            DateTime appDate = DateTime.MinValue;
            int appTypeID = 0;  
            int appStatus = 0;
            DateTime lastStatusDate = DateTime.MinValue;
            int paidFees = 0;
            int userID = 0;

            if (ApplicationsDataAccess.FindApplication( id, ref  personID, ref  appDate, ref  appTypeID, ref appStatus, ref  lastStatusDate, ref  paidFees, ref  userID))
            {
                return new clsApplications(id,  personID,  appDate,  appTypeID,  appStatus,  lastStatusDate,  paidFees,  userID);
            }
            else
            {
                return null;
            }
        }

        public void AddApplication()
        {
            this.AppID = ApplicationsDataAccess.AddApplication(this.PersonID, this.AppDate, this.AppTypeID,this.AppStatus,this.LastStatusDate,this.PaidFees,this.UserID);
        }

        public static void CancelApplication(int id)
        {
            ApplicationsDataAccess.CancelApplication(id);
        }

        public static string GetStatus(int Appstatus)
        {
            switch (Appstatus)
            {
                case 1:
                    return "New";
                    break;
                case 2:
                    return "Cancelled";
                    break;
                case 3:
                    return "Completed";
                    break;
                default:
                    return "";
                    break;
            }
        }

        public static int GetNextID()
        {
            return ApplicationsDataAccess.GetNextID();
        }

        public static void UpdateApplication(int id, int PersonID)
        {
            ApplicationsDataAccess.UpdateApplication(id, PersonID);
        }

        public void Update()
        {
            ApplicationsDataAccess.UpdateApplication(this.AppID, this.PersonID,this.AppDate,this.AppTypeID,this.AppStatus,this.LastStatusDate,this.PaidFees,this.UserID);

        }

        public static void DeleteApplication(int id)
        {
            ApplicationsDataAccess.DeleteApplication(id);
        }
    }
}
