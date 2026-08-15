using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class DriverDTO
    {
        public int DriverId { get; set; }

        public int PersonId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
