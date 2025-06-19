using DattingLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DattingLab.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
        public DbSet<GirlProfile> GirlProfiles => Set<GirlProfile>();
        public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
