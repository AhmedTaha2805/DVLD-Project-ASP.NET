using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public int PersonId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
