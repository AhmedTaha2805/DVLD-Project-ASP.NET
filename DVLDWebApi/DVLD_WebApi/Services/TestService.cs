using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class TestService
    {
        private readonly DVLDContext _context;
        public TestService(DVLDContext context)
        {
            _context = context;
        }
        public async Task<TestDTO> AddTest(TestDTO testDTO)
        {
            var test = new Test
            {
                TestAppointmentId = testDTO.TestAppointmentId,
                TestResult = testDTO.TestResult,
                Notes = testDTO.Notes,
                CreatedByUserId = testDTO.CreatedByUserId
            };
            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            testDTO.TestId = test.TestId;
            return testDTO;
        }

        public async Task DeleteTestWithAppointmentID(int id)
        {
            var test = await _context.Tests.SingleOrDefaultAsync(t => t.TestAppointmentId == id);
            if (test != null)
            {
                _context.Tests.Remove(test);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Test with TestAppointmentId {id} not found.");
            }
        }

        public async Task<bool> PersonPassedThisTestBefore(int LocalDrivingLicenseAppId , int testId)
        {
            var IsFound = await _context.Tests
                //.Include(t => t.TestAppointment)
                .Where(t => t.TestAppointment.LocalDrivingLicenseApplicationId == LocalDrivingLicenseAppId && t.TestAppointment.TestTypeId == testId  && t.TestResult == true)
                .AnyAsync();
            return IsFound;
        }

        public async Task<bool> PersonFailedThisTestBefore(int LocalDrivingLicenseAppId, int testId)
        {
            var IsFound = await _context.Tests
                 //.Include(t => t.TestAppointment)
                 .Where(t => t.TestAppointment.LocalDrivingLicenseApplicationId == LocalDrivingLicenseAppId && t.TestAppointment.TestTypeId == testId && t.TestResult == false)
                 .AnyAsync();
            return IsFound;
        }
    }
}
