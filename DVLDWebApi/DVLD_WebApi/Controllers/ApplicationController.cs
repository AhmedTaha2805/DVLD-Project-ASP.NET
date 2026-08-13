using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _service;
        public ApplicationController(ApplicationService service)
        {
            _service = service;
        }
        [HttpGet("FindApplication/{AppId}")]
        public async Task<IActionResult> FindApplication(int AppId)
        {
            var result = await _service.FindApplication(AppId);
            return Ok(result);
        }

        [HttpPost("AddApplication")]
        public async Task<IActionResult> AddApplication(ApplicationDTO dto)
        {
            var result = await _service.AddApplication(dto);
            return Ok(result);
        }
        [HttpPut("CancelApplication/{AppId}")]
        public async Task<IActionResult> CancelApplication(int AppId)
        {
            await _service.CancelApplication(AppId);
            return NoContent();
        }
        [HttpGet("GetNextId")]
        public async Task<IActionResult> GetNextID()
        {
            var result = await _service.GetNextID();
            return Ok(result);
        }
        [HttpPut("UpdateApplicationByPersonId/{AppId}/{PersonID}")]
        public async Task<IActionResult> UpdateApplication(int AppId, int PersonID)
        {
            await _service.UpdateApplication(AppId, PersonID);
            return NoContent();
        }
        [HttpPut("UpdateApplication")]
        public async Task<IActionResult> Update(ApplicationDTO dto)
        {
            await _service.Update(dto);
            return NoContent();
        }
        [HttpDelete("DeleteApplication/{AppId}")]
        public async Task<IActionResult> DeleteApplication(int AppId)
        {
            await _service.DeleteApplication(AppId);
            return NoContent();
        }

    }
}
