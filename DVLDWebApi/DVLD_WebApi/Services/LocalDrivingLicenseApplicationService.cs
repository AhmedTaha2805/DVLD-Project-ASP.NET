using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class LocalDrivingLicenseApplicationService
    {
        private readonly DVLDContext _context;

        public LocalDrivingLicenseApplicationService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<LocalDrivingLicenseApplicationDTO> FindApplicationAsync(int id)
        {
            var application = await _context.LocalDrivingLicenseApplications
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.LocalDrivingLicenseApplicationId == id);

            if (application == null)
                throw new NotFoundException("Local Driving License Application not found.");

            return new LocalDrivingLicenseApplicationDTO
            {
                LocalDrivingLicenseApplicationId =
                    application.LocalDrivingLicenseApplicationId,

                ApplicationId =
                    application.ApplicationId,

                LicenseClassId =
                    application.LicenseClassId
            };
        }

        public async Task<LocalDrivingLicenseApplicationDTO> AddApplicationAsync(int AppId, int LicenseClassId)
        {
            var application = new LocalDrivingLicenseApplication
            {
                ApplicationId = AppId,
                LicenseClassId = LicenseClassId
            };

            _context.LocalDrivingLicenseApplications.Add(application);

            await _context.SaveChangesAsync();

            return new LocalDrivingLicenseApplicationDTO
            {
                LocalDrivingLicenseApplicationId = application.LocalDrivingLicenseApplicationId,
                LicenseClassId = LicenseClassId,
                ApplicationId = AppId
            };
        }

        public async Task<List<LocalDrivingLicenseApplicationsViewDTO>> GetAllLocalAppsAsync()
        {
            return await _context.LocalDrivingLicenseApplicationsViews.AsNoTracking()
                .Select(x => new LocalDrivingLicenseApplicationsViewDTO
                {
                    LocalDrivingLicenseApplicationId = x.LocalDrivingLicenseApplicationId,
                    ClassName = x.ClassName,
                    NationalNo = x.NationalNo,
                    FullName = x.FullName,
                    ApplicationDate = x.ApplicationDate,
                    PassedTestCount = x.PassedTestCount,
                    Status = x.Status
                })
                .ToListAsync();
        }

        public async Task<int> FindNumberOfPassedTestsAsync(int LocalAppID)
        {
            var result = await _context.LocalDrivingLicenseApplicationsViews.AsNoTracking()
                .Where(x => x.LocalDrivingLicenseApplicationId == LocalAppID)
                .Select(x => x.PassedTestCount)
                .FirstOrDefaultAsync();

            return result ?? 0;
        }

        public async Task<bool> ThereIsDuplicateAppAsync(int PersonID, int LicenseClassID)
        {
            return await (
                from app in _context.Applications
                join localApp in _context.LocalDrivingLicenseApplications
                    on app.ApplicationId equals localApp.ApplicationId
                where localApp.LicenseClassId == LicenseClassID
                      && app.ApplicantPersonId == PersonID
                      && (app.ApplicationStatus == 3 || app.ApplicationStatus == 1)
                select app
            ).AnyAsync();
        }

        public async Task UpdateApplicationAsync(LocalDrivingLicenseApplicationDTO dto)
        {
            var application = await _context.LocalDrivingLicenseApplications
                .FirstOrDefaultAsync(x =>
                    x.LocalDrivingLicenseApplicationId == dto.LocalDrivingLicenseApplicationId);

            if (application == null)
                throw new KeyNotFoundException("Local Driving License Application not found.");

            application.LicenseClassId = dto.LicenseClassId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var application = await _context.LocalDrivingLicenseApplications
                .FirstOrDefaultAsync(x =>
                    x.LocalDrivingLicenseApplicationId == id);

            if (application == null)
                throw new KeyNotFoundException("Local Driving License Application not found.");

            _context.LocalDrivingLicenseApplications.Remove(application);

            await _context.SaveChangesAsync();
        }
    }
}
