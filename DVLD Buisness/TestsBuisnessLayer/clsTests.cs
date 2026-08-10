using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsDataAccessLayer;

namespace TestsBuisnessLayer
{
    public class clsTests
    {
        public int TestID { get; set; }

        public int TestAppointmentID { get; set; }

        public int TestResult { get; set; }

        public string notes { get; set; }

        public int CreatedByUserID { get; set; }

        public clsTests()
        {
            this.TestID = 0;
            this.TestAppointmentID = 0;
            this.TestResult = 0;
            this.notes = "";
            this.CreatedByUserID = 0;
        }

        public void AddTest()
        {
            this.TestID = TestsDataAccess.AddTest(this.TestAppointmentID, this.TestResult, this.CreatedByUserID, this.notes);
        }

        public static bool PersonPassedThisTestBefore(int LDLAppID, int TestTypeID)
        {
            return (TestsDataAccess.PersonPassedThisTestBefore(LDLAppID, TestTypeID));
        }

        public static bool PersonFailedThisTest(int LDLAppID, int TestTypeID)
        {
            return (TestsDataAccess.PersonFailedThisTest(LDLAppID, TestTypeID));
        }

        public static void DeleteTestWithAppointmentID(int id)
        {
            TestsDataAccess.DeleteTestWithAppointmentID(id);
        }
    }
}


            

