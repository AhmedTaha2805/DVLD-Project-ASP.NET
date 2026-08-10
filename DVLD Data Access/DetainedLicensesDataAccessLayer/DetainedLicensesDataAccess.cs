using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetainedLicensesDataAccessLayer
{
    public class DetainedLicensesDataAccess
    {      
        public static int DetainLicense(int LicenseID, DateTime DetainDate, int FineFees, int CreatedByUserID)
        {
            int id = 0;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased) " + "values(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,0);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
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

        public static void ReleaseDetainedLicense(int DetainID, DateTime date, int Uid, int Aid)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update Detainedlicenses set IsReleased = 1,ReleaseDate = @date,ReleasedByUserID = @Uid,ReleaseApplicationID=@Aid where detainid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", DetainID);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@Uid", Uid);
            command.Parameters.AddWithValue("@Aid", Aid);


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

        public static bool FindDetainByDetainID(int detainID,ref int licenseID,ref DateTime detainDate,ref int fineFees,ref int createdByUserID,ref int isReleased)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Detainedlicenses where Detainid = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", detainID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    licenseID = (int)reader["LicenseID"];
                    fineFees = Convert.ToInt32(reader["FineFees"]);
                    createdByUserID = (int)reader["createdByUserID"];                
                    detainDate = Convert.ToDateTime(reader["DetainDate"]);
                    isReleased = Convert.ToInt32(reader["IsReleased"]);
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

        public static bool FindDetainByLicenseID(ref int detainID,int licenseID, ref DateTime detainDate, ref int fineFees, ref int createdByUserID, ref int isReleased)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Detainedlicenses where Licenseid = @id and IsReleased = 0";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", licenseID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    detainID = (int)reader["DetainID"];
                    fineFees = Convert.ToInt32(reader["FineFees"]);
                    createdByUserID = (int)reader["createdByUserID"];
                    detainDate =(DateTime)(reader["DetainDate"]);
                    isReleased = Convert.ToInt32(reader["IsReleased"]);
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

        public static DataTable ListDetainedLicenses()
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select DetainID as [D.ID] , LicenseID as [L.ID] , DetainDate as [D.Date],IsReleased as [Is Released] , FineFees as [Fine Fees],ReleaseDate as [Release Date] , NationalNo as [N.No] , FullName as [Full Name] , ReleaseApplicationID as [Release App ID] from DetainedLicenses_View";

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
