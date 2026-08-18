using System;
using DTOs;

namespace CurrentUserInformation
{
    public class CurrentUser
    {
        public static string LoginRegisteryPath = @"HKEY_CURRENT_USER\SOFTWARE\LoginDetails";

        public static UserDTO user = new UserDTO();

        public static string HashPassword;
        
    }
}
