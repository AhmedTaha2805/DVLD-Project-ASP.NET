using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class PeopleService
    {
        private readonly DVLDContext _context;

        public PeopleService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<PersonDTO> AddPersonAsync(PersonDTO dto)
        {
            var person = new Person
            {
                NationalNo = dto.NationalNo,
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                ThirdName = dto.ThirdName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Gendor = dto.Gendor,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                NationalityCountryId = dto.NationalityCountryId,
                ImagePath = dto.ImagePath
            };

            _context.People.Add(person);

            await _context.SaveChangesAsync();

            dto.PersonId = person.PersonId;

            return dto;
        }

        public async Task<List<PersonDTO>> GetAllPeopleAsync()
        {
            return await _context.People
                .AsNoTracking()
                .Select(p => new PersonDTO
                {
                    PersonId = p.PersonId,
                    NationalNo = p.NationalNo,
                    FirstName = p.FirstName,
                    SecondName = p.SecondName,
                    ThirdName = p.ThirdName,
                    LastName = p.LastName,
                    DateOfBirth = p.DateOfBirth,
                    Gendor = p.Gendor,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                    NationalityCountryId = p.NationalityCountryId,
                    ImagePath = p.ImagePath
                })
                .ToListAsync();
        }

        public async Task<PersonDTO> FindPersonAsync(int id)
        {
            var person = await _context.People
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PersonId == id);

            if (person == null)
                throw new NotFoundException("Person not found.");

            return new PersonDTO
            {
                PersonId = person.PersonId,
                NationalNo = person.NationalNo,
                FirstName = person.FirstName,
                SecondName = person.SecondName,
                ThirdName = person.ThirdName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gendor = person.Gendor,
                Address = person.Address,
                Phone = person.Phone,
                Email = person.Email,
                NationalityCountryId = person.NationalityCountryId,
                ImagePath = person.ImagePath
            };
        }

        public async Task<PersonDTO> FindPersonByNationalNoAsync(string nationalNo)
        {
            var person = await _context.People
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.NationalNo == nationalNo);

            if (person == null)
                throw new NotFoundException("Person not found.");

            return new PersonDTO
            {
                PersonId = person.PersonId,
                NationalNo = person.NationalNo,
                FirstName = person.FirstName,
                SecondName = person.SecondName,
                ThirdName = person.ThirdName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gendor = person.Gendor,
                Address = person.Address,
                Phone = person.Phone,
                Email = person.Email,
                NationalityCountryId = person.NationalityCountryId,
                ImagePath = person.ImagePath
            };
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _context.People
                .FirstOrDefaultAsync(p => p.PersonId == id);

            if (person == null)
                throw new NotFoundException("Person not found.");

            _context.People.Remove(person);

            await _context.SaveChangesAsync();

           
        }

        public async Task UpdatePersonAsync(PersonDTO dto)
        {
            var person = await _context.People
                .FirstOrDefaultAsync(p => p.PersonId == dto.PersonId);

            if (person == null)
                throw new NotFoundException("Person not found.");

            person.NationalNo = dto.NationalNo;
            person.FirstName = dto.FirstName;
            person.SecondName = dto.SecondName;
            person.ThirdName = dto.ThirdName;
            person.LastName = dto.LastName;
            person.DateOfBirth = dto.DateOfBirth;
            person.Gendor = dto.Gendor;
            person.Address = dto.Address;
            person.Phone = dto.Phone;
            person.Email = dto.Email;
            person.NationalityCountryId = dto.NationalityCountryId;
            person.ImagePath = dto.ImagePath;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> NationalNoExistsAsync(string nationalNo)
        {
            return await _context.People
                .AnyAsync(p => p.NationalNo == nationalNo);
        }
    }
}
