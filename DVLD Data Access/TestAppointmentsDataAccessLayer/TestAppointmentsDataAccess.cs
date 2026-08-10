using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppointmentsDataAccessLayer
{
    public class TestAppointmentsDataAccess
    {
        public static int AddTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,DateTime AppointmentDate, int PaidFees, int CreatedByUserID, bool IsLocked,int RetakeTestApplicationID)
        {
            int id = 0;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "insert into TestAppointments(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID) " + "values(@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked,@RetakeTestApplicationID);" + "select scope_identity();";

            SqlCommand command = new SqlCommand(query, Connection);
           
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            if(RetakeTestApplicationID == 0)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            }
           

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

        public static int GetNumberOfTrials(int LDLAppID , int TestTypeID)
        {
            int trials = 0;
            
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from TestAppointments where LocalDrivingLicenseApplicationID = @id and TestTypeID = @Tid;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", LDLAppID);
            command.Parameters.AddWithValue("@Tid", TestTypeID);


            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        trials++;
                    }
                }
            }
            catch (Exception e)
            {
                ////////////
            }
            Connection.Close();
            return trials;
        }
      
        public static DataTable GetAllAppointments(int AppID , int Tid)
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select TestAppointmentID as [Appointment ID],AppointmentDate as [Appointment Date],PaidFees as [Paid Fees],IsLocked as [Is Locked] from TestAppointments where LocalDrivingLicenseApplicationID = @id and TestTypeID = @Tid;";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", AppID);
            command.Parameters.AddWithValue("@Tid", Tid);


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

        public static void LockAppointment(int id)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "Update TestAppointments set IsLocked = 1 where TestAppointmentID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);

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

        public static bool HasUnlockedAppointment(int LDLAppID,int TestTypeID)
        {
            bool IsFound = false;

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select * from TestAppointments where LocalDrivingLicenseApplicationID = @Lid and TestTypeID = @Tid and IsLocked = 0";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@Lid", LDLAppID);
            command.Parameters.AddWithValue("@Tid", TestTypeID);

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

        public static void UpdateApplicationDate(int id,DateTime date)
        {          

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "update TestAppointments set  AppointmentDate = @date where TestAppointmentID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@date", date);
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

        public static void DeleteAppointmentsWithAppID(int id)
        {
            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "delete from TestAppointments where LocalDrivingLicenseApplicationID = @id";

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

        public static DataTable GetAllAppointmentsWithID(int AppID)
        {
            DataTable dt = new DataTable();

            string connectionstring = "Server=.;Database=DVLD;User Id=sa;Password=123456;";

            SqlConnection Connection = new SqlConnection(connectionstring);

            string query = "select TestAppointmentID as [Appointment ID] from TestAppointments where LocalDrivingLicenseApplicationID = @id";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@id", AppID);
            
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
