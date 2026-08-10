using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntLicensesDataAccessLayer
{
    public class IntLicensesDataAccess
    {
        public static int AddLicense(int LocalLicenseID,int AppID, int DriverID, DateTime IssueDate
            , DateTime ExpDate, bool IsActive
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

            string query = "insert into InternationalLicenses(IssuedUsingLocalLicenseID,ApplicationID,DriverID,IssueDate,ExpirationDate,IsActive,CreatedByUserID) " + "values(@IssuedUsingLocalLicenseID,@ApplicationID,@DriverID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@ApplicationID", AppID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicenseID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpDate);                       
            command.Parameters.AddWithValue("@IsActive", isactive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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

        public static bool HasInternationalLicense(int LicenseID)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from InternationalLicenses where IssuedUsingLocalLicenseID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id",LicenseID);

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

        public static bool FindLicenseByLicenseID(int licenseid, ref int LocalLicenseID,ref int AppID,ref int DriverID,ref DateTime IssueDate
            ,ref DateTime ExpDate,ref bool IsActive
            ,ref int CreatedByUserID)
        {


            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Internationallicenses where InternationalLicenseID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", licenseid);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    AppID = (int)reader["ApplicationID"];
                    LocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    DriverID = (int)reader["DriverID"];                  
                    IsActive = Convert.ToBoolean(reader["isactive"]);                    
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpDate = (DateTime)reader["ExpirationDate"];
                    
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

        public static DataTable ListIntLicenses(int DriverID)
        {

            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT InternationalLicenseID AS[Int License ID], ApplicationID AS[Application ID], IssuedUsingLocalLicenseID AS[L.License ID],IssueDate AS[Issue Date],ExpirationDate AS[Expiration Date],IsActive AS[Is Active] from InternationalLicenses where DriverID = @id;";

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

        public static DataTable ListAllIntLicenses()
        {

            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT InternationalLicenseID AS[Int License ID], ApplicationID AS[Application ID], DriverID as [Driver ID], IssuedUsingLocalLicenseID AS[L.License ID],IssueDate AS[Issue Date],ExpirationDate AS[Expiration Date],IsActive AS[Is Active] from InternationalLicenses;";

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
    }
}
