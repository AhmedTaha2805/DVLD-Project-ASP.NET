using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationTypesDataAccessLayer;

namespace ApplicationTypesBuisnessLayer
{

    

    public class clsApplicationTypes
    {
        public int id { get; set; }
        public string title { get; set; }
        public int fees { get; set; }

        public clsApplicationTypes(int id , string title , int fees)
        { 
            this.id = id;
            this.title = title;
            this.fees = fees;          
        }

        public static clsApplicationTypes FindApplicationType(int id)
        {
            
            string title = "";
            int fees = 0;

            if (ApplicationTypesDataAccess.FindApplicationType(id, ref title, ref fees))
            {
                return new clsApplicationTypes(id, title, fees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllApplicationsTypes()
        {
            return (ApplicationTypesDataAccess.GetAllApplicationTypes());
        }

        public void UpdateApplicationType()
        {
            ApplicationTypesDataAccess.UpdateApplicationType(this.id, this.title, this.fees);

        }

        public static string GetApplicationType(int AppTypeID)
        {
            return ApplicationTypesDataAccess.GetApplicationType(AppTypeID);
        }

        public void Save()
        {
            UpdateApplicationType();
        }
    }
}
