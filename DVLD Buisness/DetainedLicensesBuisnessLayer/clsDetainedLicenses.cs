using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetainedLicensesDataAccessLayer;

namespace DetainedLicensesBuisnessLayer
{
    public class clsDetainedLicenses
    {

        public int DetainID {  get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public int FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public int IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseAppID {  get; set; }



        public clsDetainedLicenses(int detainID, int licenseID, DateTime detainDate, int fineFees, int createdByUserID, int isReleased, DateTime releaseDate, int releasedByUserID, int releaseAppID)
        {
            this.DetainID = detainID;
            this.LicenseID = licenseID;
            this.DetainDate = detainDate;
            this.FineFees = fineFees;
            this.CreatedByUserID = createdByUserID;
            this.IsReleased = isReleased;
            this.ReleaseDate = releaseDate;
            this.ReleasedByUserID = releasedByUserID;
            this.ReleaseAppID = releaseAppID;
        }
       
        public clsDetainedLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = -1;
            this.CreatedByUserID = -1;
            this.IsReleased = 0;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseAppID = -1;
        }

        public void Detain()
        {
            this.DetainID = DetainedLicensesDataAccess.DetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
        }

        public void Release()
        {
            DetainedLicensesDataAccess.ReleaseDetainedLicense(this.DetainID,this.ReleaseDate,this.ReleasedByUserID,this.ReleaseAppID);
        }

        public static clsDetainedLicenses FindDetainByDetainID(int DetainID)
        {
            int createdByuserID = -1;
            int LicenseID = -1;
            int IsReleased = 0;
            DateTime DetainDate = DateTime.MinValue;
            int fineFees = -1;
            if (DetainedLicensesDataAccess.FindDetainByDetainID(DetainID,ref LicenseID,ref DetainDate,ref fineFees,ref createdByuserID,ref IsReleased))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, fineFees, createdByuserID,IsReleased,DateTime.MinValue,-1,-1);
            }
            else
            {
                return null;
            }
        }

        public static clsDetainedLicenses FindDetainByLicenseID(int LicenseID)
        {
            int createdByuserID = -1;
            int DetainID = -1;
            int IsReleased = 0;
            DateTime DetainDate = DateTime.MinValue;
            int fineFees = -1;
            if (DetainedLicensesDataAccess.FindDetainByLicenseID(ref DetainID,LicenseID, ref DetainDate, ref fineFees, ref createdByuserID, ref IsReleased))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, fineFees, createdByuserID, IsReleased, DateTime.MinValue, -1, -1);
            }
            else
            {
                return null;
            }
        }

        public static DataTable ListDetainedLicenses()
        {
            return (DetainedLicensesDataAccess.ListDetainedLicenses());
        }




    }
}
