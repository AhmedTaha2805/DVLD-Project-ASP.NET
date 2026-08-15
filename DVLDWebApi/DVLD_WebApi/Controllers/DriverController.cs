using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriverController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver(DriverDTO dto)
        {
            var driver = await _driverService.AddDriverAsync(dto);

            return CreatedAtAction(
                nameof(FindDriverByID),
                new { id = driver.DriverId },
                driver);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllDrivers()
        {
            var drivers = await _driverService.ListAllDriversAsync();

            return Ok(drivers);
        }

        [HttpGet("Exists/{personID}")]
        public async Task<IActionResult> ThisDriverExists(int personID)
        {
            var result = await _driverService.ThisDriverExistsAsync(personID);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindDriverByID(int id)
        {
            var driver = await _driverService.FindDriverByIDAsync(id);

            return Ok(driver);
        }

        [HttpGet("Person/{personID}")]
        public async Task<IActionResult> FindDriverByPersonID(int personID)
        {
            var driver =
                await _driverService.FindDriverByPersonIDAsync(personID);

            return Ok(driver);
        }
    }
}
