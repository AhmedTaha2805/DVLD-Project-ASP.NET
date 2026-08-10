using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class LicenseClassService
    {
        private readonly DVLDContext _context;
        public LicenseClassService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<LicenseClassDTO>> GetAllLicenseClasses()
        {
            var LicenseClasses = await _context.LicenseClasses.AsNoTracking().Select(lc =>
                new LicenseClassDTO
                {
                    LicenseClassId = lc.LicenseClassId,
                    ClassName = lc.ClassName,
                    ClassDescription = lc.ClassDescription,
                    MinimumAllowedAge = lc.MinimumAllowedAge,
                    DefaultValidityLength = lc.DefaultValidityLength,
                    ClassFees = lc.ClassFees
                }).ToListAsync();
            return LicenseClasses;

        }

        public async Task<int> GetLicenseClassIdByClassName(string ClassName)
        {
            var LicenseClass = await _context.LicenseClasses.AsNoTracking().SingleOrDefaultAsync(lc => lc.ClassName == ClassName);
            if (LicenseClass != null)
            {
                return LicenseClass.LicenseClassId;
            }
            else
            {
                throw new NotFoundException($"License Class with Name {ClassName} doesn't exist");
            }
        }

        public async Task<string> GetLicenseClassNameById(int LicenseClassId)
        {
            var LicenseClass = await _context.LicenseClasses.AsNoTracking().SingleOrDefaultAsync(lc => lc.LicenseClassId == LicenseClassId);
            if (LicenseClass != null)
            {
                return LicenseClass.ClassName;
            }
            else
            {
                throw new NotFoundException($"License Class with ID {LicenseClassId} doesn't exist");
            }

        }

        public async Task<decimal> GetLicenseClassFeesById(int LicenseClassId)
        {
            var LicenseClass = await _context.LicenseClasses.AsNoTracking().SingleOrDefaultAsync(lc => lc.LicenseClassId == LicenseClassId);
            if (LicenseClass != null)
            {
                return LicenseClass.ClassFees;
            }
            else
            {
                throw new NotFoundException($"License Class with ID {LicenseClassId} doesn't exist");
            }

        }

        public async Task<Byte> GetLicenseClassValidityLengthById(int LicenseClassId)
        {
            var LicenseClass = await _context.LicenseClasses.AsNoTracking().SingleOrDefaultAsync(lc => lc.LicenseClassId == LicenseClassId);
            if (LicenseClass != null)
            {
                return LicenseClass.DefaultValidityLength;
            }
            else
            {
                throw new NotFoundException($"License Class with ID {LicenseClassId} doesn't exist");
            }

        }
    }
}
