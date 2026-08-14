using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternationalLicenseController : ControllerBase
    {
        private readonly InternationalLicenseService _internationalLicenseService;
        public InternationalLicenseController(InternationalLicenseService internationalLicenseService)
        {
            _internationalLicenseService = internationalLicenseService;
        }
        [HttpPost]
        public async Task<IActionResult> AddLicense(InternationalLicenseDTO dto)
        {
            var IntLicenseDTO = await _internationalLicenseService.AddLicenseAsync(dto);

            return CreatedAtAction(
                nameof(FindLicenseByLicenseId),
                new { IntLicenseDTO.InternationalLicenseId },
                IntLicenseDTO);
        }

        [HttpGet("HasInternationalLicense/{licenseId}")]
        public async Task<IActionResult> HasInternationalLicense(int licenseId)
        {
            var result =
                await _internationalLicenseService.HasInternationalLicenseAsync(licenseId);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindLicenseByLicenseId(int id)
        {
            var license =
                await _internationalLicenseService.FindLicenseByLicenseIdAsync(id);

            return Ok(license);
        }

        [HttpGet("ByDriver/{driverId}")]
        public async Task<IActionResult> ListIntLicenses(int driverId)
        {
            var licenses =
                await _internationalLicenseService.ListIntLicensesAsync(driverId);

            return Ok(licenses);
        }

        [HttpGet]
        public async Task<IActionResult> ListAllIntLicenses()
        {
            var licenses =
                await _internationalLicenseService.ListAllIntLicensesAsync();

            return Ok(licenses);
        }
    }
}
