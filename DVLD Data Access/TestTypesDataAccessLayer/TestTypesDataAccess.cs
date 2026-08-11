using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTypesDataAccessLayer
{
    public class TestTypesDataAccess
    {
        public static DataTable GetAllTestTypes()
        {

            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from TestTypes";

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

        public static bool UpdateTestType(int id, string title,string description, int fees)
        {

            int rowsaffected = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update testtypes set testTypeTitle = @title,TestTypeDescription = @description,TestTypeFees = @fees where testTypeID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@description", description);
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

        public static bool FindTestType(int id, ref string title,ref string description, ref int fees)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from testtypes where testtypeid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    title = (string)reader["testtypetitle"];
                    description = (string)reader["testtypedescription"];
                    fees = Convert.ToInt32(reader["testtypefees"]);


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
