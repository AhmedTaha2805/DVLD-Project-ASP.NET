using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class InternationalLicenseService
    {
        private readonly DVLDContext _context;
        public InternationalLicenseService(DVLDContext context)
        {
            _context = context;
        }
        public async Task<InternationalLicenseDTO> AddLicenseAsync(InternationalLicenseDTO dto)
        {
            var license = new InternationalLicense
            {
                IssuedUsingLocalLicenseId = dto.IssuedUsingLocalLicenseId,
                ApplicationId = dto.ApplicationId,
                DriverId = dto.DriverId,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                IsActive = dto.IsActive,
                CreatedByUserId = dto.CreatedByUserId
            };

            _context.InternationalLicenses.Add(license);

            await _context.SaveChangesAsync();
            dto.InternationalLicenseId = license.InternationalLicenseId;

            return dto;
        }

        public async Task<bool> HasInternationalLicenseAsync(int licenseId)
        {
            return await _context.InternationalLicenses
                .AnyAsync(x => x.IssuedUsingLocalLicenseId == licenseId);
        }

        public async Task<InternationalLicenseDTO> FindLicenseByLicenseIdAsync(int licenseId)
        {
            var license = await _context.InternationalLicenses
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.InternationalLicenseId == licenseId);

            if (license == null)
                throw new NotFoundException("International license not found.");

            return new InternationalLicenseDTO
            {
                InternationalLicenseId = license.InternationalLicenseId,
                ApplicationId = license.ApplicationId,
                DriverId = license.DriverId,
                IssuedUsingLocalLicenseId = license.IssuedUsingLocalLicenseId,
                IssueDate = license.IssueDate,
                ExpirationDate = license.ExpirationDate,
                IsActive = license.IsActive,
                CreatedByUserId = license.CreatedByUserId
            };
        }

        public async Task<List<InternationalLicenseDTO>> ListIntLicensesAsync(int driverId)
        {
            return await _context.InternationalLicenses
                .AsNoTracking()
                .Where(x => x.DriverId == driverId)
                .Select(x => new InternationalLicenseDTO
                {
                    InternationalLicenseId = x.InternationalLicenseId,
                    ApplicationId = x.ApplicationId,
                    DriverId = x.DriverId,
                    IssuedUsingLocalLicenseId = x.IssuedUsingLocalLicenseId,
                    IssueDate = x.IssueDate,
                    ExpirationDate = x.ExpirationDate,
                    IsActive = x.IsActive,
                    CreatedByUserId = x.CreatedByUserId
                })
                .ToListAsync();
        }

        public async Task<List<InternationalLicenseDTO>> ListAllIntLicensesAsync()
        {
            return await _context.InternationalLicenses
                .AsNoTracking()
                .Select(x => new InternationalLicenseDTO
                {
                    InternationalLicenseId = x.InternationalLicenseId,
                    ApplicationId = x.ApplicationId,
                    DriverId = x.DriverId,
                    IssuedUsingLocalLicenseId = x.IssuedUsingLocalLicenseId,
                    IssueDate = x.IssueDate,
                    ExpirationDate = x.ExpirationDate,
                    IsActive = x.IsActive,
                    CreatedByUserId = x.CreatedByUserId
                })
                .ToListAsync();
        }
    }
}
