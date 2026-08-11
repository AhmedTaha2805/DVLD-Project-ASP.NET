using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class TestAppointmentDTOForRetrieving
    {
        public int TestAppointmentId { get; set; }     
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsLocked { get; set; }
    }
}
