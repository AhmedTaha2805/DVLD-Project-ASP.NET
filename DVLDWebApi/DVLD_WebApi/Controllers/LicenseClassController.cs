using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LicenseClassController : ControllerBase
    {
        private readonly LicenseClassService _licenseClassService;
        public LicenseClassController(LicenseClassService licenseClassService)
        {
            _licenseClassService = licenseClassService;
        }

        [HttpGet("GetAllLicenseClasses")]
        public async Task<IActionResult> GetAllLicenseClasses()
        {
            var licenseClasses = await _licenseClassService.GetAllLicenseClasses();
            return Ok(licenseClasses);
        }

        [HttpGet("GetLicenseClassIdByClassName/{ClassName}")]
        public async Task<IActionResult> GetLicenseClassIdByClassName(string ClassName)
        {
            var licenseClassId = await _licenseClassService.GetLicenseClassIdByClassName(ClassName);
            return Ok(licenseClassId);
        }

        [HttpGet("GetLicenseClassNameById/{LicenseClassId}")]
        public async Task<IActionResult> GetLicenseClassNameById(int LicenseClassId)
        {
            var licenseClassName = await _licenseClassService.GetLicenseClassNameById(LicenseClassId);
            return Ok(licenseClassName);
        }

        [HttpGet("GetLicenseClassFeesById/{LicenseClassId}")]

        public async Task<IActionResult> GetLicenseClassFeesById(int LicenseClassId)
        {
            var licenseClassFees = await _licenseClassService.GetLicenseClassFeesById(LicenseClassId);
            return Ok(licenseClassFees);
        }

        [HttpGet("GetLicenseClassValidityLengthById/{LicenseClassId}")]

        public async Task<IActionResult> GetLicenseClassValidityLengthById(int LicenseClassId)
        {
            var licenseClassFees = await _licenseClassService.GetLicenseClassValidityLengthById(LicenseClassId);
            return Ok(licenseClassFees);
        }

    }
}
