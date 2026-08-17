using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetainedLicenseController : ControllerBase
    {
            private readonly DetainedLicenseService _service;

            public DetainedLicenseController(DetainedLicenseService service)
            {
                _service = service;
            }

            [HttpPost]
            public async Task<IActionResult> Detain(DetainedLicenseDTO dto)
            {
                var DetainedLicenseDTO = await _service.DetainAsync(dto);

                return CreatedAtAction(
                    nameof(FindByDetainId),
                    new { id = dto.DetainId },
                    DetainedLicenseDTO);
            }

            [HttpPost("{id}/release")]
            public async Task<IActionResult> Release(
                int id,
                DetainedLicenseDTO dto)
            {
                //dto.DetainId = id;

                await _service.ReleaseAsync(dto);

                return NoContent();
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> FindByDetainId(int id)
            {
                var detainedLicense =
                    await _service.FindByDetainIdAsync(id);

                return Ok(detainedLicense);
            }

            [HttpGet("ByLicense/{licenseId}")]
            public async Task<IActionResult> FindByLicenseId(int licenseId)
            {
                var detainedLicense =
                    await _service.FindByLicenseIdAsync(licenseId);

                return Ok(detainedLicense);
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var detainedLicenses =
                    await _service.GetAllAsync();

                return Ok(detainedLicenses);
            }
        }
    }

