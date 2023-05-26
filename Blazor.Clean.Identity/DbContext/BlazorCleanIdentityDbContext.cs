using Blazor.Clean.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Clean.Identity.DbContext
{
    public class BlazorCleanIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlazorCleanIdentityDbContext()
        {
        }
    
        public BlazorCleanIdentityDbContext(DbContextOptions<BlazorCleanIdentityDbContext> options) : base(options)
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
              optionsBuilder.UseSqlServer("Server=LAPTOP-9MEGBOCG;Database=BlazorClean;Trusted_Connection=True;TrustServerCertificate=true;User ID=sa;Password=lotusnotes;");
              base.OnConfiguring(optionsBuilder);
          }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BlazorCleanIdentityDbContext).Assembly);
        }
    }
}
