using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class DriverViewDTO
    {
        public int DriverId { get; set; }

        public int PersonId { get; set; }

        public string NationalNo { get; set; }

        public string FullName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? NumberOfActiveLicenses { get; set; }
    }
}
