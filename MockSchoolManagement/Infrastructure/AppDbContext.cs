using Microsoft.EntityFrameworkCore;
using MockSchoolManagement.Models;
using MockSchoolManagement.Models.EnumTypes;

namespace MockSchoolManagement.Infrastructure
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
