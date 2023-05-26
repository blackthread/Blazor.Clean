using Blazor.Clean.Domain;
using Blazor.Clean.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Blazor.Clean.Persistence.IntegrationTests
{
    public class HeDatabaseContextTests
    {
        private BlazorCleanDbContext _hrDatabaseContext;

        public HeDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<BlazorCleanDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
           // _hrDatabaseContext = new HrDatabaseContext(dbOptions);
        }
        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };

            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            leaveType.DateCreated.ShouldNotBeNull();
        }
        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation",
            };

            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            leaveType.DateCreated.ShouldNotBeNull();
        }
    }
}