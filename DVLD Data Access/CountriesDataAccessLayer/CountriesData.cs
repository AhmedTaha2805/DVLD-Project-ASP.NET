using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Net;
using System.Security.Policy;

namespace CountriesDataAccessLayer
{
    public class clsCountryDataAccess
    {
        public static string GetCountryName(int countryid)
        {
            string name = string.Empty;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";
            SqlConnection connection = new SqlConnection(connectionstring);

            string query = "select CountryName from countries where countryid = @id";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", countryid);

            try
            {
                connection.Open();
                object reader = command.ExecuteScalar();

                if (reader != null)
                {
                    name = reader.ToString();
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                connection.Close();
            }
            return name;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from countries";

            SqlCommand command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
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
