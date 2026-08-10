using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsDataAccessLayer
{
    public class TestsDataAccess
    {
        public static int AddTest(int TestAppID , int TestResult , int UserID , string notes)
        {
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into Tests(TestAppointmentID,TestResult,Notes,CreatedByUserID) " + "values(@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if(notes == "")
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", notes);
            }
            
            command.Parameters.AddWithValue("@CreatedByUserID", UserID);
            
            try
            {
                Connection.Open();

                object reader = command.ExecuteScalar();

                if (reader != null && int.TryParse(reader.ToString(), out int insertedid))
                {
                    id = insertedid;
                }
            }
            catch (Exception e)
            {
                ///////////////
            }
            Connection.Close();

            return id;
        }

        public static bool PersonPassedThisTestBefore(int LDLAppID, int TestTypeID)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT TestResult\r\nFROM     TestAppointments INNER JOIN\r\n                  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID \r\n\t\t\t\t  where TestTypeID = @Tid and TestResult = 1 and LocalDrivingLicenseApplicationID = @Lid;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@Lid", LDLAppID);
            command.Parameters.AddWithValue("@Tid", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    IsFound = true;
                }
            }
            catch (Exception e)
            {
                ////////////
            }
            Connection.Close();
            return IsFound;

        }

        public static bool PersonFailedThisTest(int LDLAppID, int TestTypeID)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT TestResult\r\nFROM     TestAppointments INNER JOIN\r\n                  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID \r\n\t\t\t\t  where TestTypeID = @Tid and TestResult = 0 and LocalDrivingLicenseApplicationID = @Lid;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@Lid", LDLAppID);
            command.Parameters.AddWithValue("@Tid", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    IsFound = true;
                }
            }
            catch (Exception e)
            {
                ////////////
            }
            Connection.Close();
            return IsFound;
        }

        public static void DeleteTestWithAppointmentID(int id)
        {
          
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "delete from Tests where TestAppointmentID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                /////
            }
            Connection.Close();
            
        }
    }
}
