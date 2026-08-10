using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseClassesDataAccessLayer;


namespace LicenseClassesBuisnessLayer
{
    public class clsLicenseClasses
    {
        public static DataTable GetAllLicenseClasses()
        {
            return (LicenseClassesDataAccess.GetAllLicenseClasses());
        }

        public static int GetLicenseClassID(string licenseClassName)
        {
            return(LicenseClassesDataAccess.GetLicenseClassID(licenseClassName));
        }

        public static string GetLicenseClassName(int LicenseClassID)
        {
            return (LicenseClassesDataAccess.GetLicenseClassName(LicenseClassID));
        }

        public static int GetLicenseClassFees(int ClassID)
        {
            return(LicenseClassesDataAccess.GetLicenseClassFees(ClassID));
        }

        public static int GetValidityLength(int ClassID)
        {
            return(LicenseClassesDataAccess.GetValidityLength(ClassID));
        }
    }
}
