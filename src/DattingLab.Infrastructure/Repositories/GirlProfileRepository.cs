using System.Collections.Generic;
using System.Threading.Tasks;
using DattingLab.Domain.Entities;
using DattingLab.Domain.Repositories;
using DattingLab.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DattingLab.Infrastructure.Repositories
{
    public class GirlProfileRepository : IGirlProfileRepository
    {
        private readonly AppDbContext _context;

        public GirlProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GirlProfile>> GetRandomAsync(int count)
        {
            return await _context.GirlProfiles.Take(count).ToListAsync();
        }

        public async Task LikeAsync(GirlProfile profile)
        {
            // Implement like logic
            await Task.CompletedTask;
        }

        public async Task DislikeAsync(GirlProfile profile)
        {
            // Implement dislike logic
            await Task.CompletedTask;
        }
    }
}
