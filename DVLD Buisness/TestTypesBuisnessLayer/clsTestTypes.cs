using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTypesDataAccessLayer;

namespace TestTypesBuisnessLayer
{
    public class clsTestTypes
    {
        public int id { get; set; }
        public string title { get; set; }

        public string description { get; set; } 
        public int fees { get; set; }

        public clsTestTypes(int id, string title,string description, int fees)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.fees = fees;
        }

        public static clsTestTypes FindTestType(int id)
        {

            string title = "";
            string description = "";
            int fees = 0;

            if (TestTypesDataAccess.FindTestType(id, ref title,ref description, ref fees))
            {
                return new clsTestTypes(id, title,description, fees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllTestTypes()
        {
            return (TestTypesDataAccess.GetAllTestTypes());
        }

        public void UpdateTestType()
        {
            TestTypesDataAccess.UpdateTestType(this.id, this.title,this.description, this.fees);

        }

        public void Save()
        {
            UpdateTestType();
        }
    }
}
