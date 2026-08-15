using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class DriverService
    {
        private readonly DVLDContext _context;
        public DriverService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<DriverDTO> AddDriverAsync(DriverDTO dto)
        {
            var driver = new Driver
            {
                PersonId = dto.PersonId,
                CreatedByUserId = dto.CreatedByUserId,
                CreatedDate = dto.CreatedDate
            };

            _context.Drivers.Add(driver);

            await _context.SaveChangesAsync();

            dto.DriverId = driver.DriverId;

            return dto;
        }

        public async Task<List<DriverViewDTO>> ListAllDriversAsync()
        {
            return await _context.Drivers
                .AsNoTracking()
                .Select(d => new DriverViewDTO
                {
                    DriverId = d.DriverId,
                    PersonId = d.PersonId,
                    NationalNo = d.Person.NationalNo,
                    FullName = d.Person.FirstName + " " +
                               d.Person.SecondName + " " +
                               d.Person.ThirdName + " " +
                               d.Person.LastName,
                    CreatedDate = d.CreatedDate,

                    NumberOfActiveLicenses = _context.Licenses
                        .Count(l => l.DriverId == d.DriverId && l.IsActive)
                })
                .ToListAsync();
        }

        public async Task<bool> ThisDriverExistsAsync(int personID)
        {
            return await _context.Drivers
                .AnyAsync(d => d.PersonId == personID);
        }

        public async Task<DriverDTO> FindDriverByIDAsync(int driverID)
        {
            var driver = await _context.Drivers
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.DriverId == driverID);

            if (driver == null)
                throw new NotFoundException("Driver not found.");

            return new DriverDTO
            {
                DriverId = driver.DriverId,
                PersonId = driver.PersonId,
                CreatedByUserId = driver.CreatedByUserId,
                CreatedDate = driver.CreatedDate
            };
        }

        public async Task<DriverDTO> FindDriverByPersonIDAsync(int personID)
        {
            var driver = await _context.Drivers
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.PersonId == personID);

            if (driver == null)
                throw new NotFoundException("Driver not found.");

            return new DriverDTO
            {
                DriverId = driver.DriverId,
                PersonId = driver.PersonId,
                CreatedByUserId = driver.CreatedByUserId,
                CreatedDate = driver.CreatedDate
            };
        }

    }
}
