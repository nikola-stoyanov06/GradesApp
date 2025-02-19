using GradesApp.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GradesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId);

            builder.Entity<Grade>()
                .HasOne(g => g.Teacher)
                .WithMany(t => t.Grades)    
                .HasForeignKey(g => g.TeacherId);

        }
        public DbSet<GradesApp.Data.Entities.Student> Students { get; set; } = default!;
        public DbSet<GradesApp.Data.Entities.Teacher> Teachers { get; set; } = default!;
        public DbSet<GradesApp.Data.Entities.Subject> Subjects { get; set; } = default!;
        public DbSet<GradesApp.Data.Entities.Grade> Grades { get; set; } = default!;
    }
}
