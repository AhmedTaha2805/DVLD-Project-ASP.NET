using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class DetainedLicenseViewDTO
    {
        public int DetainId { get; set; }

        public int LicenseId { get; set; }

        public DateTime DetainDate { get; set; }

        public bool IsReleased { get; set; }

        public decimal FineFees { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string NationalNo { get; set; }

        public string FullName { get; set; }

        public int? ReleaseApplicationId { get; set; }
    }
}
