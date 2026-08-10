using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationTypeController : ControllerBase
    {
        private readonly ApplicationTypeService _applicationTypeService;
        public ApplicationTypeController(ApplicationTypeService applicationTypeService)
        {
            _applicationTypeService = applicationTypeService;
        }
        [HttpGet("GetAllApplicationTypes")]
        public async Task<ActionResult<List<ApplicationTypeDTO>>> GetAllApplicationTypes()
        {
            var applicationTypes = await _applicationTypeService.GetAllApplicationTypes();
            return Ok(applicationTypes);
        }
        [HttpGet("GetApplicationTypeTitleById/{id}")]
        public async Task<ActionResult<string>> GetAllApplicationTypeTitle(int id)
        {
            var applicationTypeTitle = await _applicationTypeService.GetApplicationTypeTitleById(id);
            return Ok(applicationTypeTitle);

        }
        [HttpGet("GetApplicationTypeById/{id}")]
        public async Task<ActionResult<ApplicationTypeDTO>> GetApplicationTypeById(int id)
        {
            var applicationType = await _applicationTypeService.GetApplicationTypeById(id);
            return Ok(applicationType);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicationType(ApplicationTypeDTO applicationType)
        {
                await _applicationTypeService.UpdateApplicationType(applicationType);
                return NoContent();
        }
    }
}
