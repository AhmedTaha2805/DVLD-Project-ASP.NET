using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsDataAccessLayer
{
    public class ApplicationsDataAccess
    {
        public static int AddApplication(int PersonID,DateTime appdate , int apptypeID,int appstatus,DateTime laststatusdate,int paidfees,int userid)
        {
            int id = 0; 
            
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into Applications(ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID) " + "values(@personid,@appdate,@apptypeid,@appstatus,@laststatusdate,@fees,@userid);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);

            
            command.Parameters.AddWithValue("@personid", PersonID);
            command.Parameters.AddWithValue("@appdate", appdate);
            command.Parameters.AddWithValue("@apptypeid", apptypeID);
            command.Parameters.AddWithValue("@appstatus", appstatus);
            command.Parameters.AddWithValue("@laststatusdate", laststatusdate);
            command.Parameters.AddWithValue("@fees", paidfees);
            command.Parameters.AddWithValue("@userid", userid);



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

        public static void CancelApplication(int id)
        {           

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update Applications set ApplicationStatus = 2,LastStatusDate = @date where ApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id",id);
            command.Parameters.AddWithValue("@date", DateTime.Now);

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

        public static bool FindApplication(int AppID,ref int personID, ref DateTime appDate,ref int appTypeID,ref int appStatus,ref DateTime lastStatusDate,ref int paidFees,ref int userID)
        {
            bool IsFound = false;
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from Applications where ApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", AppID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    personID = (int)reader["applicantpersonid"];
                    appDate = (DateTime)reader["ApplicationDate"];
                    appTypeID = Convert.ToInt32(reader["applicationtypeid"]);
                    appStatus = Convert.ToInt32(reader["applicationstatus"]);
                    lastStatusDate = (DateTime)reader["laststatusdate"];
                    paidFees = Convert.ToInt32(reader["paidfees"]);
                    userID = (int)reader["createdbyuserid"];


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

        public static int GetNextID()
        {
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select Max(ApplicationID) + 1 from Applications;";

            SqlCommand command = new SqlCommand(query, Connection);
        
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

        public static void UpdateApplication(int id , int PersonID)
        {           
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update applications set ApplicantPersonID = @Pid where ApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@Pid", PersonID);
            
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

        public static void DeleteApplication(int id)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "delete from Applications where ApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                /////
            }
            Connection.Close();
        }

        public static void UpdateApplication(int Appid, int personID, DateTime appDate, int appTypeID, int appStatus, DateTime lastStatusDate, int paidFees, int userID)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update applications set ApplicantPersonID = @Pid ,ApplicationDate = @Adate,ApplicationTypeID = @type,ApplicationStatus = @status,LastStatusDate = @Sdate,PaidFees = @fees,CreatedByUserID = @Uid  where ApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", Appid);
            command.Parameters.AddWithValue("@Pid", personID);
            command.Parameters.AddWithValue("@Uid", userID);
            command.Parameters.AddWithValue("@Adate", appDate);
            command.Parameters.AddWithValue("@type", appTypeID);
            command.Parameters.AddWithValue("@status",appStatus);
            command.Parameters.AddWithValue("@fees",paidFees);
            command.Parameters.AddWithValue("@Sdate",lastStatusDate);



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
