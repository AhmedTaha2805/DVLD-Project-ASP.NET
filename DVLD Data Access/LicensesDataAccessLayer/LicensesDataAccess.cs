using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LicensesDataAccessLayer
{
    public class LicensesDataAccess
    {
        public static int AddLicense(int AppID, int DriverID, int LicenseClassID, DateTime IssueDate
            , DateTime ExpDate, string notes, int PaidFees, bool IsActive, int IssueReason
            , int CreatedByUserID)
        {
            int isactive = 0;
            if (IsActive)
            {
                isactive = 1;
            }
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into Licenses(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,notes,PaidFees,IsActive,IssueReason,CreatedByUserID) " + "values(@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);
           
            command.Parameters.AddWithValue("@ApplicationID", AppID);
            command.Parameters.AddWithValue("@LicenseClass",LicenseClassID);
            command.Parameters.AddWithValue("@DriverID",DriverID);
            command.Parameters.AddWithValue("@IssueDate",IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate",ExpDate);
            if(notes != "")
            {
                command.Parameters.AddWithValue("@notes", notes);
            }
            else
            {
                command.Parameters.AddWithValue("@notes",DBNull.Value);
            }       
            command.Parameters.AddWithValue("@PaidFees",PaidFees);
            command.Parameters.AddWithValue("@IsActive",isactive);
            command.Parameters.AddWithValue("@IssueReason",IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID",CreatedByUserID);


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

        public static bool FindLicenseByApplicationID(ref int LicenseID, ref int AppID, int LAppID,ref int DriverID,ref int LicenseClassID,ref DateTime IssueDate
            ,ref DateTime ExpDate,ref string notes,ref int PaidFees,ref bool IsActive,ref int IssueReason
            ,ref int CreatedByUserID)
        {
            

            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT Licenses.LicenseID, Licenses.ApplicationID, Licenses.DriverID, Licenses.LicenseClass, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.Notes, Licenses.PaidFees, Licenses.IsActive, Licenses.IssueReason, \r\n                  Licenses.CreatedByUserID\r\nFROM     Licenses INNER JOIN\r\n                  Applications ON Licenses.ApplicationID = Applications.ApplicationID INNER JOIN\r\n                  LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID\r\nWHERE  (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @id)";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LAppID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    LicenseID = (int)reader["licenseid"];
                    AppID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IsActive = Convert.ToBoolean(reader["isactive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpDate = (DateTime)reader["ExpirationDate"];
                    if(reader["notes"] != DBNull.Value)
                    {
                        notes = (string)reader["notes"];
                    }
                    PaidFees = Convert.ToInt32(reader["PaidFees"]);                  
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

        public static bool FindLicenseByLicenseID(int LicenseID,ref int AppID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate
            , ref DateTime ExpDate, ref string notes, ref int PaidFees, ref bool IsActive, ref int IssueReason
            , ref int CreatedByUserID)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from licenses where licenseid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LicenseID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;                   
                    AppID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClassID = (int)reader["LicenseClass"];
                    IsActive = Convert.ToBoolean(reader["isactive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpDate = (DateTime)reader["ExpirationDate"];
                    if (reader["notes"] != DBNull.Value)
                    {
                        notes = (string)reader["notes"];
                    }
                    PaidFees = Convert.ToInt32(reader["PaidFees"]);
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

        public static bool IsDetained(int LicenseID)
        {
            
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from DetainedLicenses where LicenseID = @id and IsReleased = 0;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LicenseID);

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

        public static bool WasDetainedAndReleased(int LicenseID)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from DetainedLicenses where LicenseID = @id and IsReleased = 1;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LicenseID);

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

        public static DataTable ListLocalLicenses(int DriverID)
        {
         
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT Licenses.LicenseID AS[Lic ID], Licenses.ApplicationID AS[App ID], LicenseClasses.ClassName AS[Class Name], Licenses.IssueDate AS[Issue Date], Licenses.ExpirationDate AS[Expiration Date], Licenses.IsActive AS[Is Active]\r\nFROM Licenses INNER JOIN\r\n                  LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID\r\n\r\n                  where DriverID = @id;";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@id", DriverID);

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

        public static bool IsExpired(int LicenseID,DateTime date)
        {

            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Licenses where LicenseID = @id and ExpirationDate < @date;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LicenseID);
            command.Parameters.AddWithValue("@date",date);

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

        public static bool IsActive(int LicenseID)
        {

            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Licenses where LicenseID = @id and IsActive = 1;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LicenseID);
            

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

        public static void DeActivateLicense(int LicenseID)
        {         
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update licenses set IsActive = 0 where licenseid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LicenseID);
            

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

        public static void ActivateLicense(int LicenseID)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update licenses set IsActive = 1 where licenseid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LicenseID);


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

        

        

    }
}
