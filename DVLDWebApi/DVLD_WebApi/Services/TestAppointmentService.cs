using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class TestAppointmentService
    {
        private readonly DVLDContext _context;
        public TestAppointmentService(DVLDContext context)
        {
            _context = context;
        }
        public async Task<TestAppointmentDTO> AddTest(TestAppointmentDTO testAppointmentDTO)
        {
            var testapp = new TestAppointment
            {
                TestTypeId = testAppointmentDTO.TestTypeId,
                LocalDrivingLicenseApplicationId = testAppointmentDTO.LocalDrivingLicenseApplicationId,
                AppointmentDate = testAppointmentDTO.AppointmentDate,
                PaidFees = testAppointmentDTO.PaidFees,
                CreatedByUserId = testAppointmentDTO.CreatedByUserId,
                IsLocked = testAppointmentDTO.IsLocked,
                RetakeTestApplicationId = testAppointmentDTO.RetakeTestApplicationId
            };
            await _context.TestAppointments.AddAsync(testapp);
            await _context.SaveChangesAsync();
            testAppointmentDTO.TestAppointmentId = testapp.TestAppointmentId;
            return testAppointmentDTO;
        }

        public async Task<int> GetNumberOfTrials(int LDLAppId, int testTypeId)
        {
            var count = await _context.TestAppointments.AsNoTracking()
                .Where(t => t.LocalDrivingLicenseApplicationId == LDLAppId && t.TestTypeId == testTypeId)
                .CountAsync();
            return count;
        }

        public async Task<List<TestAppointmentDTOForRetrieving>> GetTestAppointmentsByLDLAppId(int LDLAppId , int TestTypeId)
        {
            var testAppointments = await _context.TestAppointments.AsNoTracking()
                .Where(t => t.LocalDrivingLicenseApplicationId == LDLAppId && t.TestTypeId == TestTypeId)
                .Select(t => new TestAppointmentDTOForRetrieving
                {
                    TestAppointmentId = t.TestAppointmentId,                   
                    AppointmentDate = t.AppointmentDate,
                    PaidFees = t.PaidFees,            
                    IsLocked = t.IsLocked
                })
                .ToListAsync();
            return testAppointments;
        }

        public async Task LockAppointment(int testAppointmentId)
        {
            var appointment = await _context.TestAppointments.SingleOrDefaultAsync(t => t.TestAppointmentId == testAppointmentId);
            if (appointment != null)
            {
                appointment.IsLocked = true;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Test appointment with ID {testAppointmentId} not found.");
            }
        }

        public async Task<bool> HasUnlockedAppointment(int LDLAppId, int testTypeId)
        {
            var hasUnlocked = await _context.TestAppointments.AsNoTracking()
                .Where(t => t.LocalDrivingLicenseApplicationId == LDLAppId && t.TestTypeId == testTypeId && !t.IsLocked)
                .AnyAsync();
            return hasUnlocked;
        }

        public async Task UpdateAppointmentDate(int testAppointmentId, DateTime newDate)
        {
            var appointment = await _context.TestAppointments.SingleOrDefaultAsync(t => t.TestAppointmentId == testAppointmentId);
            if (appointment != null)
            {
                appointment.AppointmentDate = newDate;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Test appointment with ID {testAppointmentId} not found.");
            }
        }

        public async Task DeleteAppointmentsWithLDLAppId(int LDLAppId)
        {
            var appointments = await _context.TestAppointments
                .Where(t => t.LocalDrivingLicenseApplicationId == LDLAppId)
                .ToListAsync();
            if (appointments.Any())
            {
                _context.TestAppointments.RemoveRange(appointments);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"No test appointments found for Local Driving License Application ID {LDLAppId}.");
            }
        }

        public async Task<List<int>> GetTestAppointmentsIdsByLDLAppId(int LDLAppId)
        {
            var appointmentIds = await _context.TestAppointments.AsNoTracking()
                .Where(t => t.LocalDrivingLicenseApplicationId == LDLAppId)
                .Select(t => t.TestAppointmentId)
                .ToListAsync();
            return appointmentIds;
        }

    }
}
