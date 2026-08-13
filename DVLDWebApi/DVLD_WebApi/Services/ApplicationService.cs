using DTOs;
using DVLD_WebApi.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Models;

namespace DVLD_WebApi.Services
{
    public class ApplicationService
    {
        private readonly DVLDContext _context;
        public ApplicationService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<ApplicationDTO> FindApplication(int AppId)
        {
           var Application = await _context.Applications.AsNoTracking().SingleOrDefaultAsync(app => app.ApplicationId  == AppId);
            if (Application == null)
            {
                throw new NotFoundException($"Application with id {AppId} Not found");
            }
            else
            {
                return new ApplicationDTO
                {
                    ApplicationId = AppId,
                    ApplicantPersonId = Application.ApplicantPersonId,
                    ApplicationDate = Application.ApplicationDate,
                    ApplicationTypeId = Application.ApplicationTypeId,
                    ApplicationStatus = Application.ApplicationStatus,
                    LastStatusDate = Application.LastStatusDate,
                    CreatedByUserId = Application.CreatedByUserId,
                    PaidFees = Application.PaidFees
                };
            }
        }
        public async Task<ApplicationDTO> AddApplication(ApplicationDTO dto)
        {
            var App = new Application
            {
                ApplicantPersonId = dto.ApplicantPersonId,
                ApplicationDate = dto.ApplicationDate,
                ApplicationTypeId = dto.ApplicationTypeId,
                ApplicationStatus = dto.ApplicationStatus,
                LastStatusDate = dto.LastStatusDate,
                PaidFees = dto.PaidFees,
                CreatedByUserId = dto.CreatedByUserId
            };
            _context.Applications.Add(App);
            await _context.SaveChangesAsync();
            dto.ApplicationId = App.ApplicationId;
            return dto;
        }

        public async Task CancelApplication(int AppId)
        {
            var App = await _context.Applications.SingleOrDefaultAsync(app => app.ApplicationId == AppId);
            if (App == null)
            {
                throw new NotFoundException($"Application with id {AppId} Not found");
            }
            else
            {
                App.ApplicationStatus = 2;
                App.LastStatusDate = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetNextID()
        {          
            if(await _context.Applications.AnyAsync())
            {
                var MaxId = await _context.Applications.MaxAsync(app => app.ApplicationId);
                return MaxId + 1;
            }
            return 1;
                 
        }

        public async Task UpdateApplication(int AppId, int PersonID)
        {
            var App = await _context.Applications.SingleOrDefaultAsync(app => app.ApplicationId == AppId);
            if (App == null)
            {
                throw new NotFoundException($"Application with id {AppId} Not found");
            }
            else
            {
                App.ApplicantPersonId = PersonID;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(ApplicationDTO dto)
        {
            var App = await _context.Applications.SingleOrDefaultAsync(app => app.ApplicationId == dto.ApplicationId);
            if (App == null)
            {
                throw new NotFoundException($"Application with id {dto.ApplicationId} Not found");
            }
            else
            {
                App.ApplicantPersonId = dto.ApplicantPersonId;
                App.ApplicationStatus = dto.ApplicationStatus;
                App.ApplicationDate = dto.ApplicationDate;
                App.ApplicationTypeId = dto.ApplicationTypeId;
                App.LastStatusDate = dto.LastStatusDate;
                App.CreatedByUserId = dto.CreatedByUserId;
                App.PaidFees = dto.PaidFees;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteApplication(int AppId)
        {
            var App = await _context.Applications.SingleOrDefaultAsync(app => app.ApplicationId == AppId);
            if (App == null)
            {
                throw new NotFoundException($"Application with id {AppId} Not found");
            }
            _context.Applications.Remove(App);
            await _context.SaveChangesAsync();
        }
    }
}
