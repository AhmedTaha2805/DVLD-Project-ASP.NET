using DTOs;
using DVLD_WebApi.CustomExceptions;
using DVLD_WebApi.Data;
using DVLD_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DVLD_WebApi.Services
{
    public class UserService
    {
        private readonly DVLDContext _context;

        public UserService(DVLDContext context)
        {
            _context = context;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    PersonId = u.PersonId,
                    UserName = u.UserName,
                    Password = u.Password,
                    IsActive = u.IsActive
                })
                .ToListAsync();
        }

        public async Task<UserDTO> AddUserAsync(UserDTO dto)
        {
            var user = new User
            {
                PersonId = dto.PersonId,
                UserName = dto.UserName,
                Password = dto.Password,
                IsActive = dto.IsActive
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            dto.UserId = user.UserId;

            return dto;
        }

        public async Task<UserDTO> FindUserAsync(int userID)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UserId == userID);

            if (user == null)
                throw new NotFoundException("User not found.");

            return new UserDTO
            {
                UserId = user.UserId,
                PersonId = user.PersonId,
                UserName = user.UserName,
                Password = user.Password,
                IsActive = user.IsActive
            };
        }

        public async Task<UserDTO> FindUserAsync(
            string username,
            string password)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>
                    u.UserName == username &&
                    u.Password == password);

            if (user == null)
                throw new NotFoundException("User not found.");

            return new UserDTO
            {
                UserId = user.UserId,
                PersonId = user.PersonId,
                UserName = user.UserName,
                Password = user.Password,
                IsActive = user.IsActive
            };
        }

        public async Task<bool> FindUserByPersonIDAsync(int personID)
        {
            return await _context.Users
                .AnyAsync(u => u.PersonId == personID);
        }

        public async Task UpdateUserAsync(
            UserDTO dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == dto.UserId);

            if (user == null)
                throw new NotFoundException("User not found.");

            user.UserName = dto.UserName;
            user.Password = dto.Password;
            user.PersonId = dto.PersonId;
            user.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();

        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
                throw new NotFoundException("User not found.");

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
