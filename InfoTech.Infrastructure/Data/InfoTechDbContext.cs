using InfoTech.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoTech.Infrastructure.Data
{
    public class InfoTechDbContext(DbContextOptions<InfoTechDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .ToTable("Users", "Tech");
        }
    }
}
