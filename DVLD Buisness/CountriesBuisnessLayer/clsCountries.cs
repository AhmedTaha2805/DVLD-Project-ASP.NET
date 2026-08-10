using System;
using System.Data;
using System.Runtime.CompilerServices;
using CountriesDataAccessLayer;

namespace CountriesBuisnessLayer
{
    public class clsCountries
    {

        public static string GetCountryName(int countryid) => clsCountryDataAccess.GetCountryName(countryid);

        public static DataTable GetAllCountries() => clsCountryDataAccess.GetAllCountries();
    }
}
