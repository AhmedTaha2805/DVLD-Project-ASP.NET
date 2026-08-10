using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PeopleDataAccessLayer;

namespace PeopleBuisnessLayer
{
    public enum enMode {AddNew , Update };
    public class clsPeople
    {
        enMode Mode = enMode.Update;
        public int Id { get; set; }
        public string NationalNum { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int CountryId { get; set; }
        public int Gender { get; set; }

        public clsPeople(int id, string NationalNum, string FirstName,
            string SecondName, string ThirdName, string LastName, string Email,string address, string Phone, DateTime DateOfBirth,
            string ImagePath, int CountryId, int Gender)
        {
            this.Id = id;
            this.NationalNum = NationalNum;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;         
            this.Email = Email;
            this.Phone = Phone;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            this.CountryId = CountryId;
            this.Gender = Gender;
            this.Address = address;
            this.Mode = enMode.Update;
        }

        public clsPeople()
        {
            this.Id = -1;
            this.NationalNum = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Address = "";
            this.Email = ""; 
            this.Phone = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
            this.CountryId = -1;
            this.Gender = 0;
            Mode = enMode.AddNew;
        }

        public static DataTable GetAllPeople()
        {
            return (clsPeopleDataAccess.GetAllPeople());
        }

        public string FullName()
        {
            return ($"{this.FirstName} {this.SecondName} {this.ThirdName} {this.LastName}");
        }

        public static clsPeople FindPerson(int Id)
        {
            string NationalNum = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string Address = "";
            string Email = "";
            string Phone = "";
            DateTime DateOfBirth = DateTime.Now;
            string ImagePath = "";
            int CountryId = -1;
            int Gender = 0;
            if (clsPeopleDataAccess.FindPerson(Id,ref NationalNum,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref Address,ref Email,ref Phone,ref DateOfBirth,ref ImagePath,ref CountryId,ref Gender))
            {
                return new clsPeople(Id,NationalNum,FirstName,SecondName,ThirdName,LastName,Email,Address,Phone,DateOfBirth,ImagePath,CountryId,Gender);
            }
            else
            {
                return null;
            }
        }

        public static clsPeople FindPerson(string NationalNo)
        {
            int Id = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string Address = "";
            string Email = "";
            string Phone = "";
            DateTime DateOfBirth = DateTime.Now;
            string ImagePath = "";
            int CountryId = -1;
            int Gender = 0;
            if (clsPeopleDataAccess.FindPerson(ref Id, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Address, ref Email, ref Phone, ref DateOfBirth, ref ImagePath, ref CountryId, ref Gender))
            {
                return new clsPeople(Id, NationalNo, FirstName, SecondName, ThirdName, LastName, Email, Address, Phone, DateOfBirth, ImagePath, CountryId, Gender);
            }
            else
            {
                return null;
            }
        }

        public void AddPerson()
        {
            this.Id = clsPeopleDataAccess.AddPerson(this.Id,this.NationalNum,this.FirstName,this.SecondName,this.ThirdName,this.LastName,this.Address,this.Email,this.Phone,this.DateOfBirth,this.ImagePath,this.CountryId,this.Gender);
        }

        public static bool DeletePerson(int Id)
        {
            if(clsPeopleDataAccess.DeletePerson(Id)) return true;
            else return false;
        }

        public void UpdatePerson()
        {
            clsPeopleDataAccess.UpdatePerson(this.Id, this.NationalNum, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Address, this.Email, this.Phone, this.DateOfBirth, this.ImagePath, this.CountryId, this.Gender);

        }

        public static bool NationalNumExists(string num)
        {
            return clsPeopleDataAccess.NationalNumExists(num);
        }

        
        
        public void Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    AddPerson();
                    break;
                case enMode.Update:
                    UpdatePerson();
                    break;


            }
        }
    }
}
