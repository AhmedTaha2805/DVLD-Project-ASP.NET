using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        public CountryController(CountryService service)
        {
            _countryService = service;
        }

        [HttpGet("GetCountryName/{countryid}")]
        public async Task<IActionResult> GetCountryName(int countryid)
        {
                var countryName = await _countryService.GetCountryName(countryid);
                return Ok(countryName);     
        }
        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
                var countries = await _countryService.GetAllCountries();
                return Ok(countries);
        }
    }
}
