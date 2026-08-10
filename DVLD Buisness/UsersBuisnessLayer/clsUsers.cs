using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UsersDataAccessLayer;
using HashingClass;

namespace UsersBuisnessLayer
{
    enum enMode {AddNew , Update };
    public class clsUsers
    {
        enMode Mode = enMode.Update;
        public int UserID {  get; set; }
        public string UserName { get; set; }

        public bool IsActive { get; set; }

        public string Password { get; set; }

        public int PersonID { get; set; }
        public clsUsers()
        {
            this.UserID = -1;
            this.UserName = string.Empty;
            this.IsActive = false;
            this.Password = string.Empty;
            this.PersonID = -1;
            this.Mode = enMode.AddNew;
        }

        public clsUsers(int id,string username,string password,int personid,bool isactive)
        {
            this.UserID=id;
            this.UserName = username;
            this.Password = password;
            this.PersonID = personid;
            this.IsActive = isactive;
        }

        public static DataTable GetAllUsers()
        {
            return(clsUsersDataAccess.GetAllUsers());

        }

        public bool AddNewUser()
        {

            this.UserID = clsUsersDataAccess.AddNewUser(this.UserID,this.UserName,this.Password,this.PersonID,this.IsActive);

            return (this.UserID != -1);
        }

        public static clsUsers FindUser(int UserID)
        {
            int personid = -1;
            string username = string.Empty;
            string password = string.Empty;
            bool isactive = false;
            if(clsUsersDataAccess.FindUser(UserID,ref username ,ref password,ref personid,ref isactive))
            {
                return new clsUsers(UserID,username,password,personid,isactive);
            }
            else
            {
                return null;
            }
        }

        public static clsUsers FindUser(string username , string password)
        {
            int userid = -1;
            int personid = -1;
            bool isactive = false;
            if (clsUsersDataAccess.FindUserByUserNameAndPassword(ref userid,username,password, ref personid, ref isactive))
            {
                return new clsUsers(userid, username, password, personid, isactive);
            }
            else
            {
                return null;
            }
        }

        public static bool FindUserByPersonID(int PersonID)
        {
            return clsUsersDataAccess.FindUserByPersonID(PersonID);
        }

        public bool UpdateUser()
        {
            return(clsUsersDataAccess.UpdateUser(this.UserID,this.UserName,this.Password,this.PersonID,this.IsActive));

        }

        public static bool DeleteUser(int id)
        {
            return clsUsersDataAccess.DeleteUser(id);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    return (AddNewUser());
                case enMode.Update:
                    return (UpdateUser());
            }
            return true;
        }
    }
}
