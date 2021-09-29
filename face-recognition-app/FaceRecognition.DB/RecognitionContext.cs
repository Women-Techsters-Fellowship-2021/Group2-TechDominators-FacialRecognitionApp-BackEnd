using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FaceRecognition.Models;

namespace FaceRecognition.DB
{
    public class RecognitionContext : IdentityDbContext<AppUser>
    {
        public RecognitionContext(DbContextOptions<RecognitionContext> options) : base(options)
        {

        }
        public class RecognitionContextFactory : IDesignTimeDbContextFactory<RecognitionContext>
        {
            public RecognitionContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<RecognitionContext>();
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=School_Management;User id=SA;Password=Anthr0p0m0rphyzz44");

                return new RecognitionContext(optionsBuilder.Options);
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }

    }
}