using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDrivingLicenseApplicationsDataAccessLayer
{
    public class LocalDrivingLicenseApplicationsDataAccess
    {

        public static bool FindLocalApplication(int LDLAppID , ref int AppID , ref int LicenseClassID)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LDLAppID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    AppID = (int)reader["applicationid"];
                    LicenseClassID = (int)reader["LicenseClassID"];


                }
                reader.Close();


            }
            catch (Exception e)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;
        }

        public static int AddApplication(int AppId,int LicenseClassID)
        {
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID) " + "values(@appid,@classid);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@appid", AppId);
            command.Parameters.AddWithValue("@classid", LicenseClassID);
            



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

        public static DataTable GetAllLocalApps()
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select LocalDrivingLicenseApplicationID as [L.D.L AppID] , ClassName as [Driving Class] , NationalNo as [National No],FullName as [Full Name] , ApplicationDate as [Application Date],PassedTestCount as [Passed Tests],Status  from LocalDrivingLicenseApplications_View;";

            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception e)
            {
                //////
            }
            Connection.Close();
            return dt;
        }

        public static int FindNumberOfPassedTests(int LocalAppID)
        {

            int passedTests = 0;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select PassedTestCount from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @id ";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@id", LocalAppID);
            
            try
            {
                Connection.Open();

                object reader = command.ExecuteScalar();

                if (reader != null && int.TryParse(reader.ToString(), out int PassedTests))
                {
                    passedTests = PassedTests;
                }
            }
            catch (Exception e)
            {
                ///////////////
            }
            Connection.Close();

            return passedTests;
        }

        public static bool ThereIsDuplicateApp(int Personid , int LicenseClassid)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT *\r\nFROM     Applications INNER JOIN\r\n                  LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID\r\n\t\t\t\t  where LocalDrivingLicenseApplications.LicenseClassID = @Lid and Applications.ApplicantPersonID = @id and ((Applications.ApplicationStatus = 3) or (Applications.ApplicationStatus = 1))  ;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", Personid);
            command.Parameters.AddWithValue("@Lid", LicenseClassid);

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

        public static void UpdateApplication(int id , int LCID)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update LocalDrivingLicenseApplications set LicenseClassID = @LCid where LocalDrivingLicenseApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@LCid", LCID);

            try
            {
                Connection.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                ////////////
            }
            Connection.Close();

        }

        public static void DeleteApplication(int id)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @id";

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
