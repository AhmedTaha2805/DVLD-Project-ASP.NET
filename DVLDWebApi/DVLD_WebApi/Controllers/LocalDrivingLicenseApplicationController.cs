using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalDrivingLicenseApplicationController : ControllerBase
    {
        private readonly LocalDrivingLicenseApplicationService _localDrivingLicenseApplicationService;
        public LocalDrivingLicenseApplicationController(LocalDrivingLicenseApplicationService service)
        {
            _localDrivingLicenseApplicationService = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindApplication(int id)
        {
            var application =
                await _localDrivingLicenseApplicationService.FindApplicationAsync(id);

            return Ok(application);
        }
        [HttpPost]
        public async Task<IActionResult> AddApplication(LocalDrivingLicenseApplicationDTO dto)
        {
            var App = await _localDrivingLicenseApplicationService
                .AddApplicationAsync(dto.ApplicationId, dto.LicenseClassId);

            return CreatedAtAction(
                nameof(GetAllLocalApps),
                new { id = App.LocalDrivingLicenseApplicationId },
                App
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocalApps()
        {
            var applications = await _localDrivingLicenseApplicationService
                .GetAllLocalAppsAsync();

            return Ok(applications);
        }

        [HttpGet("NumberOfPassedTests/{LocalAppID}")]
        public async Task<IActionResult> FindNumberOfPassedTests(int LocalAppID)
        {
            var result = await _localDrivingLicenseApplicationService
                .FindNumberOfPassedTestsAsync(LocalAppID);

            return Ok(result);
        }

        [HttpGet("ThereIsDuplicateApp/{PersonID}/{LicenseClassID}")]
        public async Task<IActionResult> ThereIsDuplicateApp(
            int PersonID,
            int LicenseClassID)
        {
            var result = await _localDrivingLicenseApplicationService
                .ThereIsDuplicateAppAsync(PersonID, LicenseClassID);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(
            LocalDrivingLicenseApplicationDTO dto)
        {
            await _localDrivingLicenseApplicationService
                .UpdateApplicationAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            await _localDrivingLicenseApplicationService
                .DeleteApplicationAsync(id);

            return NoContent();
        }
    }
}
