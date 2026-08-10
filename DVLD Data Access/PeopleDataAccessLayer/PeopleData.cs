using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using System.Net;

namespace PeopleDataAccessLayer
{
    public class clsPeopleDataAccess
    {
        public static bool FindPerson(int id, ref string NationalNum, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref string address, ref string Email, ref string Phone, ref DateTime DateOfBirth,
            ref string ImagePath, ref int CountryId, ref int Gender)
        {        
                bool IsFound = false;
                string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

                SqlConnection Connection = new SqlConnection(connectionstring);

                string query = "select * from people where personid = @id";

                SqlCommand command = new SqlCommand(query, Connection);

                command.Parameters.AddWithValue("@id", id);
                
                try
                {
                    Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        IsFound = true;
                        NationalNum = (string)reader["Nationalno"];
                        FirstName = (string)reader["firstname"];
                        SecondName = (string)reader["secondname"];
                        ThirdName = (string)reader["thirdname"];
                        LastName = (string)reader["lastname"];
                        address = (string)reader["address"];
                    if (reader["email"] != DBNull.Value)
                    {
                        Email = (string)reader["email"];
                    }
                        
                        Phone = (string)reader["phone"];
                        DateOfBirth = (DateTime)reader["dateofbirth"];
                        if (reader["imagepath"] != DBNull.Value)
                        {
                            ImagePath = (string)reader["imagepath"];
                        }
                        CountryId = Convert.ToInt32( reader["nationalitycountryid"]);
                        Gender = Convert.ToInt32(reader["gendor"]);


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

        public static bool FindPerson(ref int id, string NationalNum, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref string address, ref string Email, ref string Phone, ref DateTime DateOfBirth,
            ref string ImagePath, ref int CountryId, ref int Gender)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from people where nationalno = @nationalno";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@nationalno", NationalNum);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    id = (int)reader["PersonID"];
                    FirstName = (string)reader["firstname"];
                    SecondName = (string)reader["secondname"];
                    ThirdName = (string)reader["thirdname"];
                    LastName = (string)reader["lastname"];
                    address = (string)reader["address"];
                    if (reader["email"] != DBNull.Value)
                    {
                        Email = (string)reader["email"];
                    }

                    Phone = (string)reader["phone"];
                    DateOfBirth = (DateTime)reader["dateofbirth"];
                    if (reader["imagepath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["imagepath"];
                    }
                    CountryId = Convert.ToInt32(reader["nationalitycountryid"]);
                    Gender = Convert.ToInt32(reader["gendor"]);


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
        public static int AddPerson(int id, string NationalNum, string FirstName,
            string SecondName, string ThirdName, string LastName,string address, string Email, string Phone, DateTime DateOfBirth,
            string ImagePath, int CountryId, int Gender)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into people(NationalNo,firstname,secondname,thirdname,lastname,dateofbirth,gendor,address,phone,email,NationalityCountryid,imagepath) " + "values(@NationalNo,@firstname,@secondname,@thirdname,@lastname,@dateofbirth,@gendor,@address,@phone,@email,@NationalityCountryid,@imagepath);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNum);
            command.Parameters.AddWithValue("@firstname", FirstName);
            command.Parameters.AddWithValue("@secondname", SecondName);
            command.Parameters.AddWithValue("@thirdname", ThirdName);
            command.Parameters.AddWithValue("@lastname", LastName);
            command.Parameters.AddWithValue("@dateofbirth", DateOfBirth);
            command.Parameters.AddWithValue("@gendor", Gender);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", Phone);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@NationalityCountryid", CountryId);
            command.Parameters.AddWithValue("@imagepath", ImagePath);


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

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from people";

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

        public static bool DeletePerson(int Id)
        {
            int rowsaffected = 0;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "delete from people where personid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", Id);

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
            return rowsaffected > 0;
            
        }

        public static bool UpdatePerson(int id, string NationalNum, string FirstName,
            string SecondName, string ThirdName, string LastName, string address, string Email, string Phone, DateTime DateOfBirth,
            string ImagePath, int CountryId, int Gender)
        {
            int rowsaffected = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update people set nationalno = @NationalNo,firstname = @firstname,secondname=@secondname,thirdname=@thirdname,lastname=@lastname,dateofbirth=@dateofbirth,gendor =@gendor,address =@address,phone=@phone,email=@email,NationalityCountryid=@NationalityCountryid,imagepath=@imagepath where personid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@NationalNo", NationalNum);
            command.Parameters.AddWithValue("@firstname", FirstName);
            command.Parameters.AddWithValue("@secondname", SecondName);
            command.Parameters.AddWithValue("@thirdname", ThirdName);
            command.Parameters.AddWithValue("@lastname", LastName);
            command.Parameters.AddWithValue("@dateofbirth", DateOfBirth);
            command.Parameters.AddWithValue("@gendor", Gender);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@phone", Phone);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@NationalityCountryid", CountryId);
            command.Parameters.AddWithValue("@imagepath", ImagePath);

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

        public static bool NationalNumExists(string num)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from people where nationalno = @num";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@num",num);

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



    }
}
