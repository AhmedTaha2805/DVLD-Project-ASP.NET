using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DriversDataAccessLayer;

namespace DriversBuisnessLayer
{
    public class clsDrivers
    {
        public int DriverID { get; set; }

        public int PersonID { get; set; }

        public int CreatedByUserID { get; set; }

        public DateTime CreatedDate { get; set; } 
        
        public clsDrivers()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = -1;
        }

        public clsDrivers(int DriverID,int PersonID,int CreatedByUserID,DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedDate = CreatedDate;
            this.CreatedByUserID = CreatedByUserID;
        }

        public void AddDriver()
        {
            this.DriverID = DriversDataAccess.AddDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }

        public static DataTable ListAllDrivers()
        {
            return(DriversDataAccess.ListAllDrivers());
        }

        public static bool ThisDriverExists(int PersonID)
        {
            return(DriversDataAccess.ThisDriverExists(PersonID));
        }

        public static clsDrivers FindDriverByID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if(DriversDataAccess.FindDriverByID(DriverID,ref PersonID,ref CreatedByUserID,ref CreatedDate))
            {
                return new clsDrivers(DriverID,PersonID,CreatedByUserID,CreatedDate);
            }
            else
            {
                return null;
            }

        }
        public static clsDrivers FindDriverBypersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if (DriversDataAccess.FindDriverByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }

        }


    }
}
