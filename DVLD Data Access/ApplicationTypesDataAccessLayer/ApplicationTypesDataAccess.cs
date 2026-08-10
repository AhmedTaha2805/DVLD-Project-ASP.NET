using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTypesDataAccessLayer
{
    public class ApplicationTypesDataAccess
    {
        public static DataTable GetAllApplicationTypes()
        {

            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from ApplicationTypes";

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

        public static bool UpdateApplicationType(int id,string title,int fees)
        {
            
            int rowsaffected = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update applicationtypes set ApplicationTypeTitle = @title,ApplicationFees = @fees where ApplicationTypeID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@fees", fees);
            

            try
            {
                Connection.Open();
                rowsaffected = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                ////////////
            }
            Connection.Close();

            return (rowsaffected > 0);
        }

        public static bool FindApplicationType(int id, ref string title, ref int fees)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from applicationtypes where applicationtypeid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    title = (string)reader["applicationtypetitle"];
                    fees = Convert.ToInt32(reader["applicationfees"]);


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

        public static string GetApplicationType(int AppTypeID)
        {
            string type = "";

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select applicationtypetitle from applicationtypes where applicationtypeid = @id";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@id", AppTypeID);

            try
            {
                Connection.Open();

                object reader = command.ExecuteScalar();

                if (reader != null)
                {
                    type = reader.ToString();
                }
            }
            catch (Exception e)
            {
                ///////////////
            }
            Connection.Close();

            return type;
        }
    }
}
