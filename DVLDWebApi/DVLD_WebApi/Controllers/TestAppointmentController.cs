using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAppointmentController : ControllerBase
    {
        private readonly TestAppointmentService _testAppointmentService;
        public TestAppointmentController(TestAppointmentService testAppointmentService)
        {
            _testAppointmentService = testAppointmentService;
        }
        [HttpPost("AddTestAppointment")]
        public async Task<IActionResult> AddTestAppointment(TestAppointmentDTO testAppointmentDTO)
        {
            var TestApp = await _testAppointmentService.AddTest(testAppointmentDTO);
            return Ok(TestApp);
        }
        [HttpGet("GetNumberOfTrials/{LDLAppId}/{testTypeId}")]
        public async Task<IActionResult> GetNumberOfTrials(int LDLAppId, int testTypeId)
        {
            var result = await _testAppointmentService.GetNumberOfTrials(LDLAppId, testTypeId);
            return Ok(result);
        }
        [HttpGet("GetTestAppointmentsByLDLAppId/{LDLAppId}/{TestTypeId}")]
        public async Task<IActionResult> GetTestAppointmentsByLDLAppId(int LDLAppId, int TestTypeId)
        {
            var result = await _testAppointmentService.GetTestAppointmentsByLDLAppId(LDLAppId, TestTypeId);
            return Ok(result);
        }
        [HttpPut("LockAppointment/{testAppointmentId}")]
        public async Task<IActionResult> LockAppointment(int testAppointmentId)
        {
            await _testAppointmentService.LockAppointment(testAppointmentId);
            return NoContent();
        }
        [HttpGet("HasUnLockedAppointment/{LDLAppId}/{TestTypeId}")]
        public async Task<IActionResult> HasUnLockedAppointment(int LDLAppId, int TestTypeId)
        {
            var result = await _testAppointmentService.HasUnlockedAppointment(LDLAppId, TestTypeId);
            return Ok(result);
        }
        [HttpPut("UpdateAppointmentDate/{testAppointmentId}/{newDate}")]
        public async Task<IActionResult> UpdateAppointmentDate(int testAppointmentId, DateTime newDate)
        {
            await _testAppointmentService.UpdateAppointmentDate(testAppointmentId, newDate);
            return NoContent();
        }
        [HttpDelete("DeleteAppointmentsWithLDLAppId/{LDLAppId}")]
        public async Task<IActionResult> DeleteAppointmentsWithLDLAppId(int LDLAppId)
        {
            await _testAppointmentService.DeleteAppointmentsWithLDLAppId(LDLAppId);
            return NoContent();
        }
        [HttpGet("GetTestAppointmentsIdsByLDLAppId/{LDLAppId}")]
        public async Task<IActionResult> GetTestAppointmentsIdsByLDLAppId(int LDLAppId)
        {
            var result = await _testAppointmentService.GetTestAppointmentsIdsByLDLAppId(LDLAppId);
            return Ok(result);
        }
    }
}
