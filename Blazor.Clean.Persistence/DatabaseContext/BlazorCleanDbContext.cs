using Blazor.Clean.Application.Identity;
using Blazor.Clean.Domain;
using Blazor.Clean.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Blazor.Clean.Persistence.DatabaseContext
{
    public class BlazorCleanDbContext : DbContext
    {
        private readonly IUserService _userService;

           public BlazorCleanDbContext(DbContextOptions<BlazorCleanDbContext> options, IUserService userService) : base(options)
           {
               this._userService = userService;
           }

        //  public BlazorCleanDbContext(DbContextOptions<BlazorCleanDbContext> options) : base(options)
        //  {
        //  }


       //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //  {
       //      optionsBuilder.UseSqlServer("Server=LAPTOP-9MEGBOCG;Database=BlazorClean;Trusted_Connection=True;TrustServerCertificate=true;User ID=sa;Password=lotusnotes;");
       //      base.OnConfiguring(optionsBuilder);
       //  }


       // public BlazorCleanDbContext()
       // {
       // }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlazorCleanDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _userService.UserId;
               
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.UserId;
                    
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
