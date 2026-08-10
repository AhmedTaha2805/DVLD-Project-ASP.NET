using System;
using UsersBuisnessLayer;

namespace CurrentUserInformation
{
    public class CurrentUser
    {
        public static string LoginRegisteryPath = @"HKEY_CURRENT_USER\SOFTWARE\LoginDetails";

        public static clsUsers user = new clsUsers();
        
    }
}
