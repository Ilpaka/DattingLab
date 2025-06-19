using System.Threading.Tasks;
using DattingLab.Domain.Entities;
using DattingLab.Domain.Repositories;
using DattingLab.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DattingLab.Infrastructure.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDbContext _context;

        public UserProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile?> GetAsync()
        {
            return await _context.UserProfiles.FirstOrDefaultAsync();
        }

        public async Task SaveAsync(UserProfile profile)
        {
            var existing = await _context.UserProfiles.FirstOrDefaultAsync();
            if (existing == null)
                _context.UserProfiles.Add(profile);
            else
            {
                existing.Name = profile.Name;
                existing.DateOfBirth = profile.DateOfBirth;
                existing.Interests = profile.Interests;
                existing.Description = profile.Description;
                existing.PhotoPath = profile.PhotoPath;
            }
            await _context.SaveChangesAsync();
        }
    }
}
