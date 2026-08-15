using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using Microsoft.EntityFrameworkCore;
using DVLD_WebApi.Models;

namespace DVLD_WebApi.Services
{
    public class LicenseService
    {
        private readonly DVLDContext _context;
        public LicenseService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<LicenseDTO> AddLicenseAsync(LicenseDTO dto)
        {
            var license = new License
            {
                ApplicationId = dto.ApplicationId,
                DriverId = dto.DriverId,
                LicenseClass = dto.LicenseClass,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                Notes = string.IsNullOrEmpty(dto.Notes) ? null : dto.Notes,
                PaidFees = dto.PaidFees,
                IsActive = dto.IsActive,
                IssueReason = dto.IssueReason,
                CreatedByUserId = dto.CreatedByUserId
            };

            _context.Licenses.Add(license);

            await _context.SaveChangesAsync();

            dto.LicenseId = license.LicenseId;

            return dto;
        }

        public async Task<LicenseDTO> FindLicenseByApplicationIDAsync(int lAppID)
        {
            var license = await _context.Licenses
                .AsNoTracking()
                .Where(l => _context.LocalDrivingLicenseApplications
                    .Any(ldl =>
                        ldl.ApplicationId == l.ApplicationId &&
                        ldl.LocalDrivingLicenseApplicationId == lAppID))
                .FirstOrDefaultAsync();

            if (license == null)
                throw new NotFoundException("License not found.");

            return new LicenseDTO
            {
                LicenseId = license.LicenseId,
                ApplicationId = license.ApplicationId,
                DriverId = license.DriverId,
                LicenseClass = license.LicenseClass,
                IssueDate = license.IssueDate,
                ExpirationDate = license.ExpirationDate,
                Notes = license.Notes ?? "",
                PaidFees = license.PaidFees,
                IsActive = license.IsActive,
                IssueReason = (byte)license.IssueReason,
                CreatedByUserId = license.CreatedByUserId
            };
        }

        public async Task<LicenseDTO> FindLicenseByLicenseIDAsync(int licenseID)
        {
            var license = await _context.Licenses
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.LicenseId == licenseID);

            if (license == null)
                throw new NotFoundException("License not found.");

            return new LicenseDTO
            {
                LicenseId = license.LicenseId,
                ApplicationId = license.ApplicationId,
                DriverId = license.DriverId,
                LicenseClass = license.LicenseClass,
                IssueDate = license.IssueDate,
                ExpirationDate = license.ExpirationDate,
                Notes = license.Notes ?? "",
                PaidFees = license.PaidFees,
                IsActive = license.IsActive,
                IssueReason = (byte)license.IssueReason,
                CreatedByUserId = license.CreatedByUserId
            };
        }

        public string GetIssueReason(int n)
        {
            if (n == 1)
                return "First Time";

            if (n == 2)
                return "Renew";

            if (n == 3)
                return "Replacement for Damaged";

            if (n == 4)
                return "Replacement for Lost";

            throw new ValidationException("Invalid issue reason.");
        }

        public async Task<bool> IsDetainedAsync(int licenseID)
        {
            return await _context.DetainedLicenses
                .AnyAsync(d =>
                    d.LicenseId == licenseID &&
                    !d.IsReleased);
        }

        public async Task<bool> WasDetainedAndReleasedAsync(int licenseID)
        {
            return await _context.DetainedLicenses
                .AnyAsync(d =>
                    d.LicenseId == licenseID &&
                    d.IsReleased);
        }

        public async Task<List<LicenseDTO>> ListLocalLicensesAsync(int driverID)
        {
            return await _context.Licenses
                .AsNoTracking()
                .Where(l => l.DriverId == driverID)
                .Select(l => new LicenseDTO
                {
                    LicenseId = l.LicenseId,
                    ApplicationId = l.ApplicationId,
                    DriverId = l.DriverId,
                    LicenseClass = l.LicenseClass,
                    IssueDate = l.IssueDate,
                    ExpirationDate = l.ExpirationDate,
                    Notes = l.Notes ?? "",
                    PaidFees = l.PaidFees,
                    IsActive = l.IsActive,
                    IssueReason = (byte)l.IssueReason,
                    CreatedByUserId = l.CreatedByUserId
                })
                .ToListAsync();
        }

        public async Task<bool> IsExpiredAsync(int licenseID, DateTime date)
        {
            return await _context.Licenses
                .AnyAsync(l =>
                    l.LicenseId == licenseID &&
                    l.ExpirationDate < date);
        }

        public async Task<bool> IsLicenseActiveAsync(int licenseID)
        {
            return await _context.Licenses
                .AnyAsync(l =>
                    l.LicenseId == licenseID &&
                    l.IsActive);
        }

        public async Task DeActivateLicenseAsync(int licenseID)
        {
            var license = await _context.Licenses
                .FirstOrDefaultAsync(l => l.LicenseId == licenseID);

            if (license == null)
                throw new NotFoundException("License not found.");

            license.IsActive = false;

            await _context.SaveChangesAsync();
        }

        public async Task ActivateLicenseAsync(int licenseID)
        {
            var license = await _context.Licenses
                .FirstOrDefaultAsync(l => l.LicenseId == licenseID);

            if (license == null)
                throw new NotFoundException("License not found.");

            license.IsActive = true;

            await _context.SaveChangesAsync();
        }

    }
}
