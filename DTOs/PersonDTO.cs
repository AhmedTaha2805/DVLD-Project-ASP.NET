using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }

        public string NationalNo { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte Gendor { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int NationalityCountryId { get; set; }

        public string ImagePath { get; set; }
    }
}
