using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class TestAppointmentDTO
    {
        public int TestAppointmentId { get; set; }

        public int TestTypeId { get; set; }

        public int LocalDrivingLicenseApplicationId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public decimal PaidFees { get; set; }

        public int CreatedByUserId { get; set; }

        public bool IsLocked { get; set; }

        public int? RetakeTestApplicationId { get; set; }
    }
}
