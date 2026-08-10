using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriversDataAccessLayer
{
    public class DriversDataAccess
    {

        public static int AddDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into Drivers(personid,createdbyuserid,createddate) " + "values(@personid,@createdbyuserid,@createddate);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@personid", PersonID);
            command.Parameters.AddWithValue("@createdbyuserid", CreatedByUserID);
            command.Parameters.AddWithValue("@createddate", CreatedDate);

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

        public static DataTable ListAllDrivers()
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Drivers_View";

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

        public static bool ThisDriverExists(int PersonID)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from drivers where personid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", PersonID);

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

        public static bool FindDriverByID(int DriverID, ref int PersonID, ref int UserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from drivers where driverid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", DriverID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

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

        public static bool FindDriverByPersonID(ref int DriverID,int PersonID, ref int UserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from drivers where personid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    DriverID = (int)reader["DriverID"];
                    UserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

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

    

        }
}
