using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;
        public TestController(TestService service)
        {
            _testService = service;
        }

        [HttpDelete("DeleteTestWithAppointmentID/{id}")]
        public async Task<IActionResult> DeleteTestWithAppointmentID(int id)
        {
            await _testService.DeleteTestWithAppointmentID(id);
            return NoContent();
        }

        [HttpGet("PersonPassedThisTestBefore/{LocalDrivingLicenseAppId}/{testId}")]
        public async Task<IActionResult> PersonPassedThisTestBefore(int LocalDrivingLicenseAppId, int testId)
        {
            var result = await _testService.PersonPassedThisTestBefore(LocalDrivingLicenseAppId, testId);
            return Ok(result);
        }

        [HttpGet("PersonFailedThisTestBefore/{LocalDrivingLicenseAppId}/{testId}")]

        public async Task<IActionResult> PersonFailedThisTestBefore(int LocalDrivingLicenseAppId, int testId)
        {
            var result = await _testService.PersonFailedThisTestBefore(LocalDrivingLicenseAppId, testId);
            return Ok(result);
        }

        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTest(TestDTO testDTO)
        {
            var result = await _testService.AddTest(testDTO);
            return Ok(result);
        }
    }
}
