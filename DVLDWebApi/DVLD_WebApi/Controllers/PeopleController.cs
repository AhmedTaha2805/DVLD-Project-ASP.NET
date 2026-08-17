using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleService _peopleService;

        public PeopleController(PeopleService personService)
        {
            _peopleService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonDTO dto)
        {
            var person = await _peopleService.AddPersonAsync(dto);

            return CreatedAtAction(
                nameof(FindPerson),
                new { id = person.PersonId },
                person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            var people = await _peopleService.GetAllPeopleAsync();

            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindPerson(int id)
        {
            var person = await _peopleService.FindPersonAsync(id);

            return Ok(person);
        }

        [HttpGet("NationalNo/{nationalNo}")]
        public async Task<IActionResult> FindPersonByNationalNo(string nationalNo)
        {
            var person =
                await _peopleService.FindPersonByNationalNoAsync(nationalNo);

            return Ok(person);
        }

        [HttpGet("Exists/{nationalNo}")]
        public async Task<IActionResult> NationalNoExists(string nationalNo)
        {
            var result =
                await _peopleService.NationalNoExistsAsync(nationalNo);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(
            PersonDTO dto)
        {
           
            await _peopleService.UpdatePersonAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            
            await _peopleService.DeletePersonAsync(id);

            return NoContent();
        }
    }
}
