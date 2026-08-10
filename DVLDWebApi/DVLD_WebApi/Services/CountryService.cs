using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;
namespace DVLD_WebApi.Services
{
    public class CountryService
    {
        private readonly DVLDContext _context;
        public CountryService(DVLDContext context)
        {
            _context = context;
        }
        public async Task<string> GetCountryName(int countryid)
        {
            var country = await _context.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.CountryId == countryid);
            if (country != null)
            {
                return country.CountryName;
            }
            else
            {
                throw new NotFoundException($"Country with ID {countryid} not found.");
            }
        }

        public async Task<List<CountryDTO>> GetAllCountries()
        {
            var query = _context.Countries.Select(c => new CountryDTO { 
               CountryId = c.CountryId,
               CountryName = c.CountryName
            });
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
