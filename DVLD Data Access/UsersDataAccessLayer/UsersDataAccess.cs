using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Data;

namespace UsersDataAccessLayer
{
    public class clsUsersDataAccess
    {
        public static int AddNewUser(int Id, string username,string password,int personid,bool IsActive)
        {
            int isactive = 0;
            if (IsActive)
            {
                isactive = 1;
            }
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into users(personid,username,password,isactive) " + "values(@personid,@username,@password,@isactive);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@isactive",isactive);

            try
            {
                Connection.Open();

                object reader = command.ExecuteScalar();

                if (reader != null && int.TryParse(reader.ToString(), out int insertedid))
                {
                    Id = insertedid;
                }
            }
            catch (Exception e)
            {
                ///////////////
            }
            Connection.Close();

            return Id;
        }

        public static bool FindUser(int id, ref string username,ref string password,ref int personid , ref bool isactive)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Users where Userid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    username = (string)reader["UserName"];
                    personid = (int)reader["personid"];
                    password = (string)reader["Password"];
                    isactive = Convert.ToBoolean(reader["isactive"]);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                IsFound = false;
            }
            
            Connection.Close();           
            return IsFound;
        }

        public static bool FindUserByUserNameAndPassword(ref int id,string username,string password, ref int personid, ref bool isactive)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Users where Username = @username and password = @password";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    id = (int)reader["userid"];
                    personid = (int)reader["personid"];                 
                    isactive = Convert.ToBoolean(reader["isactive"]);
                }
                reader.Close();
            }
            catch (Exception e)
            {
               //
            }

            Connection.Close();

            return IsFound;
        }
        public static bool UpdateUser(int id , string username,string password,int personid,bool isactive)
        {
            int rowsaffected = 0;
            int IsActive = 0;
            if (isactive)
            {
                IsActive = 1;
            }

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update users set username = @username,personid = @personid,password=@password,IsActive = @isactive where userid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@personid", personid);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@isactive", IsActive);
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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from users";

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

        public static bool FindUserByPersonID(int PersonId)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from users where personid = @personid";

            SqlCommand command = new SqlCommand(query,Connection);

            command.Parameters.AddWithValue("@personid", PersonId);
            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                IsFound = false;
            }
            Connection.Close();
            return IsFound;

        }

        public static bool DeleteUser(int id)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "delete from users where userid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();
                rowsaffected = command.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                /////
            }
            Connection.Close();
            return (rowsaffected > 0);
        }
    }
}
