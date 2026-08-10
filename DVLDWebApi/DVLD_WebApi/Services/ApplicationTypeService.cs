using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class ApplicationTypeService
    {
        private readonly DVLDContext _context;
        public ApplicationTypeService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationTypeDTO>> GetAllApplicationTypes()
        {
            var query = _context.ApplicationTypes.Select(c => new ApplicationTypeDTO
            {
                ApplicationTypeId = c.ApplicationTypeId,
                ApplicationTypeTitle = c.ApplicationTypeTitle,
                ApplicationFees = c.ApplicationFees
            });
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<string?> GetApplicationTypeTitleById(int id)
        {
            var title = await _context.ApplicationTypes
                .AsNoTracking().Where(at => at.ApplicationTypeId == id)
                .Select(at => at.ApplicationTypeTitle)
                .SingleOrDefaultAsync();
            return title;
        }

        public async Task<ApplicationTypeDTO?> GetApplicationTypeById(int id)
        {
            var AppType = await _context.ApplicationTypes.AsNoTracking().SingleOrDefaultAsync(app => app.ApplicationTypeId == id);
            if (AppType == null)
            {
                throw new NotFoundException($"Application Type with id {id} don't exist");
            }
            return new ApplicationTypeDTO
            {
                ApplicationTypeId = AppType.ApplicationTypeId,
                ApplicationTypeTitle = AppType.ApplicationTypeTitle,
                ApplicationFees = AppType.ApplicationFees
            };
        }

        public async Task UpdateApplicationType(ApplicationTypeDTO applicationType)
        {
            var existingApplicationType = await _context.ApplicationTypes.FindAsync(applicationType.ApplicationTypeId);
            if (existingApplicationType == null)
            {
                throw new Exception($"Application Type with id {applicationType.ApplicationTypeId} doesn't exist");
            }
            existingApplicationType.ApplicationTypeTitle = applicationType.ApplicationTypeTitle;
            existingApplicationType.ApplicationFees = applicationType.ApplicationFees;
            await _context.SaveChangesAsync();
        }
    }
}
