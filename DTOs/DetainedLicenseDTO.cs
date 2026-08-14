using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class DetainedLicenseDTO
    {
        public int DetainId { get; set; }

        public int LicenseId { get; set; }

        public DateTime DetainDate { get; set; }

        public decimal FineFees { get; set; }

        public int CreatedByUserId { get; set; }

        public bool IsReleased { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? ReleasedByUserId { get; set; }

        public int? ReleaseApplicationId { get; set; }
    }
}
