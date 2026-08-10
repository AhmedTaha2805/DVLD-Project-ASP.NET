using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class LicenseClassDTO
    {
        public int LicenseClassId { get; set; }

        public string ClassName { get; set; }

        public string ClassDescription { get; set; }

        /// <summary>
        /// Minmum age allowed to apply for this license
        /// </summary>
        public byte MinimumAllowedAge { get; set; }

        /// <summary>
        /// How many years the licesnse will be valid.
        /// </summary>
        public byte DefaultValidityLength { get; set; }

        public decimal ClassFees { get; set; }
    }
}
