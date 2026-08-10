using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntLicensesDataAccessLayer;

namespace InternationalLicensesBuisnessLayer
{
    public class clsIntLicenses
    {
        public int LicenseID { get; set; }
        public int LocalLicenseID { get; set; }
        public int AppID { get; set; }
        public int DriverID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsIntLicenses()
        {
            this.LicenseID = -1;
            this.LocalLicenseID = -1;
            this.AppID = -1;
            this.DriverID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUserID = -1;
        }

        public clsIntLicenses(int licenseid, int LocalLicenseID, int AppID, int DriverID, DateTime IssueDate
            , DateTime ExpDate, bool IsActive
            , int CreatedByUserID)
        {
            this.LicenseID = licenseid;
            this.LocalLicenseID = LocalLicenseID;
            this.AppID = AppID;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
        }

        public void AddLicense()
        {
            this.LicenseID = IntLicensesDataAccess.AddLicense(this.LocalLicenseID, this.AppID, this.DriverID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }

        public static bool HasInternationalLicense(int LicenseID)
        {
            return (IntLicensesDataAccess.HasInternationalLicense(LicenseID));
        }

        public static clsIntLicenses FindLicenseByLicenseID(int LicenseID)
        {

            int AppID = -1;
            int DriverID = -1;
            int LocalLicenseID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = -1;
            if (IntLicensesDataAccess.FindLicenseByLicenseID(LicenseID, ref LocalLicenseID, ref AppID, ref DriverID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsIntLicenses(LicenseID, LocalLicenseID, AppID, DriverID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static DataTable ListIntLicenses(int DriverID)
        {
            return(IntLicensesDataAccess.ListIntLicenses(DriverID));
        }

        public static DataTable ListAllIntLicenses()
        {
            return (IntLicensesDataAccess.ListAllIntLicenses());
        }
    }
    }
