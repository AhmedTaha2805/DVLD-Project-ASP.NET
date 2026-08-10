using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace LicenseClassesDataAccessLayer
{
    public class LicenseClassesDataAccess
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "SELECT * from LicenseClasses";

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

        public static int GetLicenseClassID(string LicenceClass)
        {
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select LicenseClassID from LicenseClasses where ClassName = @name";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@name", LicenceClass);
            



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

        public static string GetLicenseClassName(int LicenseClassID)
        {
            string Class = "";

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select ClassName from LicenseClasses where LicenseClassID = @id";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@id", LicenseClassID);

            try
            {
                Connection.Open();

                object reader = command.ExecuteScalar();

                if (reader != null )
                {
                    Class = reader.ToString();
                }
            }
            catch (Exception e)
            {
                ///////////////
            }
            Connection.Close();

            return Class;
        }

        public static int GetLicenseClassFees(int ClassID)
        {
            int fees = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select ClassFees from LicenseClasses where LicenseClassID = @id";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@id",ClassID);

            try
            {
                Connection.Open();

                object reader = command.ExecuteScalar();

                if (reader != null && decimal.TryParse(reader.ToString(), out decimal Fees))
                {
                    fees =(int)Fees;
                }
            }
            catch (Exception e)
            {
                ///////////////
            }
            Connection.Close();

            return fees;
        }

        public static int GetValidityLength(int ClassID)
        {
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select DefaultValidityLength from LicenseClasses where LicenseClassID = @id";

            SqlCommand command = new SqlCommand(query, Connection);


            command.Parameters.AddWithValue("@id", ClassID);

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
    }
}
