using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicensesDataAccessLayer;
using Microsoft.SqlServer.Server;

namespace LicensesBuisnessLayer
{
    public class clsLicenses
    {
        public int LicenseID { get; set; }
        public int AppID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string notes { get; set; }
        public int PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        public clsLicenses()
        {
            this.LicenseID = -1;
            this.AppID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.notes = "";
            this.PaidFees = -1;
            this.IsActive = false;
            this.IssueReason = -1;
            this.CreatedByUserID = -1;
        }

        public clsLicenses(int licenseid ,int AppID , int DriverID,int LicenseClassID,DateTime IssueDate
            ,DateTime ExpDate,string notes,int PaidFees,bool IsActive,int IssueReason
            ,int CreatedByUserID)
        {
            this.LicenseID = licenseid;
            this.AppID = AppID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpDate;
            this.notes= notes;
            this.PaidFees= PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }

        public void AddLicense()
        {
            this.LicenseID = LicensesDataAccess.AddLicense(this.AppID, this.DriverID, this.LicenseClassID,this.IssueDate,this.ExpirationDate,this.notes,this.PaidFees,this.IsActive,this.IssueReason,this.CreatedByUserID);
        }

        public static clsLicenses FindLicenseByApplicationID(int LAppID)
        {
            int LicenseID = -1;
            int AppID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string notes = "";
            int PaidFees = -1;
            bool IsActive = false;
            int IssueReason = -1;
            int CreatedByUserID = -1;
            if (LicensesDataAccess.FindLicenseByApplicationID(ref LicenseID,ref AppID, LAppID,ref DriverID,ref LicenseClassID,ref IssueDate,ref ExpirationDate,ref notes, ref PaidFees,ref IsActive,ref IssueReason,ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, AppID,  DriverID,  LicenseClassID,  IssueDate,  ExpirationDate,  notes,  PaidFees,  IsActive,  IssueReason,  CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static clsLicenses FindLicenseByLicenseID(int LicenseID)
        {
            
            int AppID = -1;
            int DriverID = -1;
            int LicenseClassID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string notes = "";
            int PaidFees = -1;
            bool IsActive = false;
            int IssueReason = -1;
            int CreatedByUserID = -1;
            if (LicensesDataAccess.FindLicenseByLicenseID(LicenseID, ref AppID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicenses(LicenseID, AppID, DriverID, LicenseClassID, IssueDate, ExpirationDate, notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static string GetIssueReason(int n)
        {
            if (n == 1)
            {
                return "First Time";
            }
            if (n == 2)
            {
                return "Renew";
            }
            if (n == 3)
            {
                return "Replacement for Damaged";
            }
            if (n == 4)
            {
                return "Replacement for Lost";
            }
            else
            {
                return
                     null;
            }
        }

        public bool IsDetained()
        {
            return(LicensesDataAccess.IsDetained(this.LicenseID));
        }

        public bool WasDetainedAndReleased()
        {
            return(LicensesDataAccess.WasDetainedAndReleased(this.LicenseID));
        }

        public static DataTable ListLocalLicenses(int DriverID)
        {
            return(LicensesDataAccess.ListLocalLicenses(DriverID));
        }

        public static bool IsExpired(int LicenseID, DateTime date)
        {
            return(LicensesDataAccess.IsExpired(LicenseID, date));
        }

        public static bool IsLicenseActive(int LicenseID)
        {
            return(LicensesDataAccess.IsActive(LicenseID));
        }

        public static void DeActivateLicense(int LicenseID)
        {
            LicensesDataAccess.DeActivateLicense(LicenseID);
        }

        public static void ActivateLicense(int LicenseID)
        {
            LicensesDataAccess.ActivateLicense(LicenseID);
        }          

    }
}
