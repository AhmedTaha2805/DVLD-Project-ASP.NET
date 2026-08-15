using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly LicenseService _licenseService;
        public LicenseController(LicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLicense(LicenseDTO dto)
        {
            var license = await _licenseService.AddLicenseAsync(dto);

            return CreatedAtAction(
                nameof(FindLicenseByLicenseID),
                new { id = license.LicenseId },
                license);
        }

        [HttpGet("Application/{id}")]
        public async Task<IActionResult> FindLicenseByApplicationID(int id)
        {
            var license =
                await _licenseService.FindLicenseByApplicationIDAsync(id);

            return Ok(license);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindLicenseByLicenseID(int id)
        {
            var license =
                await _licenseService.FindLicenseByLicenseIDAsync(id);

            return Ok(license);
        }

        [HttpGet("IssueReason/{id}")]
        public IActionResult GetIssueReason(int id)
        {
            var reason = _licenseService.GetIssueReason(id);

            return Ok(reason);
        }

        [HttpGet("{id}/Detained")]
        public async Task<IActionResult> IsDetained(int id)
        {
            var result = await _licenseService.IsDetainedAsync(id);

            return Ok(result);
        }

        [HttpGet("{id}/WasDetainedAndReleased")]
        public async Task<IActionResult> WasDetainedAndReleased(int id)
        {
            var result =
                await _licenseService.WasDetainedAndReleasedAsync(id);

            return Ok(result);
        }

        [HttpGet("Driver/{id}")]
        public async Task<IActionResult> ListLocalLicenses(int id)
        {
            var licenses =
                await _licenseService.ListLocalLicensesAsync(id);

            return Ok(licenses);
        }

        [HttpGet("{id}/Expired")]
        public async Task<IActionResult> IsExpired(
            int id,
            [FromQuery] DateTime date)
        {
            var result =
                await _licenseService.IsExpiredAsync(id, date);

            return Ok(result);
        }

        [HttpGet("{id}/Active")]
        public async Task<IActionResult> IsLicenseActive(int id)
        {
            var result =
                await _licenseService.IsLicenseActiveAsync(id);

            return Ok(result);
        }

        [HttpPut("{id}/Deactivate")]
        public async Task<IActionResult> DeActivateLicense(int id)
        {
            await _licenseService.DeActivateLicenseAsync(id);

            return NoContent();
        }

        [HttpPut("{id}/Activate")]
        public async Task<IActionResult> ActivateLicense(int id)
        {
            await _licenseService.ActivateLicenseAsync(id);

            return NoContent();
        }
    }
}
