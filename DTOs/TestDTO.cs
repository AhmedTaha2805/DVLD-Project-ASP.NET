using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class TestDTO
    {
        public int TestId { get; set; }

        public int TestAppointmentId { get; set; }

        public bool TestResult { get; set; }

        public string Notes { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
