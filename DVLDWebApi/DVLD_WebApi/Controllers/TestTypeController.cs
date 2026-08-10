using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTypeController : ControllerBase
    {
        private readonly TestTypeService _testTypeService;
        public TestTypeController(TestTypeService service)
        {
            _testTypeService = service;
        }
        [HttpGet("GetAllTestTypes")]
        public async Task<IActionResult> GetAllTestTypes()
        {          
                var testTypes = await _testTypeService.GetAllTestTypes();
                return Ok(testTypes);      
        }
        [HttpGet("GetTestTypeById/{testTypeId}")]
        public async Task<IActionResult> GetTestTypeById(int testTypeId)
        {          
                var testType = await _testTypeService.GetTestTypeById(testTypeId);
                return Ok(testType);
        }
        [HttpPut("UpdateTestType")]
        public async Task<IActionResult> UpdateTestType(TestTypeDTO testTypeDTO)
        {          
                await _testTypeService.UpdateTestType(testTypeDTO);
                return Ok();
        }
    }
}
