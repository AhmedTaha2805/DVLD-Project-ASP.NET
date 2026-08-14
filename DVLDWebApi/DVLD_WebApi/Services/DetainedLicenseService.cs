using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class DetainedLicenseService
    {
            private readonly DVLDContext _context;

            public DetainedLicenseService(DVLDContext context)
            {
                _context = context;
            }

            public async Task<DetainedLicenseDTO> DetainAsync(DetainedLicenseDTO dto)
            {
                var detainedLicense = new DetainedLicense
                {
                    LicenseId = dto.LicenseId,
                    DetainDate = dto.DetainDate,
                    FineFees = dto.FineFees,
                    CreatedByUserId = dto.CreatedByUserId,
                    IsReleased = false
                };

                _context.DetainedLicenses.Add(detainedLicense);

                await _context.SaveChangesAsync();
                dto.DetainId = detainedLicense.DetainId;

                return dto;
            }

            public async Task ReleaseAsync(DetainedLicenseDTO dto)
            {
                var detainedLicense = await _context.DetainedLicenses
                    .SingleOrDefaultAsync(x => x.DetainId == dto.DetainId);

                if (detainedLicense == null)
                    throw new NotFoundException("Detained license not found.");

                detainedLicense.IsReleased = true;
                detainedLicense.ReleaseDate = dto.ReleaseDate;
                detainedLicense.ReleasedByUserId = dto.ReleasedByUserId;
                detainedLicense.ReleaseApplicationId = dto.ReleaseApplicationId;

                await _context.SaveChangesAsync();
            }

            public async Task<DetainedLicenseDTO> FindByDetainIdAsync(int id)
            {
                var detainedLicense = await _context.DetainedLicenses
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.DetainId == id);

                if (detainedLicense == null)
                    throw new NotFoundException("Detained license not found.");

                return new DetainedLicenseDTO
                {
                    DetainId = detainedLicense.DetainId,
                    LicenseId = detainedLicense.LicenseId,
                    DetainDate = detainedLicense.DetainDate,
                    FineFees = detainedLicense.FineFees,
                    CreatedByUserId = detainedLicense.CreatedByUserId,
                    IsReleased = detainedLicense.IsReleased,
                    ReleaseDate = detainedLicense.ReleaseDate,
                    ReleasedByUserId = detainedLicense.ReleasedByUserId,
                    ReleaseApplicationId = detainedLicense.ReleaseApplicationId
                };
            }

            public async Task<DetainedLicenseDTO> FindByLicenseIdAsync(int licenseId)
            {
                var detainedLicense = await _context.DetainedLicenses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x =>
                        x.LicenseId == licenseId &&
                        !x.IsReleased);

                if (detainedLicense == null)
                    throw new NotFoundException("Active detained license not found.");

                return new DetainedLicenseDTO
                {
                    DetainId = detainedLicense.DetainId,
                    LicenseId = detainedLicense.LicenseId,
                    DetainDate = detainedLicense.DetainDate,
                    FineFees = detainedLicense.FineFees,
                    CreatedByUserId = detainedLicense.CreatedByUserId,
                    IsReleased = detainedLicense.IsReleased,
                    ReleaseDate = detainedLicense.ReleaseDate,
                    ReleasedByUserId = detainedLicense.ReleasedByUserId,
                    ReleaseApplicationId = detainedLicense.ReleaseApplicationId
                };
            }

            public async Task<List<DetainedLicenseViewDTO>> GetAllAsync()
            {
                return await _context.DetainedLicensesViews
                    .AsNoTracking()
                    .Select(x => new DetainedLicenseViewDTO
                    {
                        DetainId = x.DetainId,
                        LicenseId = x.LicenseId,
                        DetainDate = x.DetainDate,
                        IsReleased = x.IsReleased,
                        FineFees = x.FineFees,
                        ReleaseDate = x.ReleaseDate,
                        NationalNo = x.NationalNo,
                        FullName = x.FullName,
                        ReleaseApplicationId = x.ReleaseApplicationId
                    })
                    .ToListAsync();
            }
        }
    }

