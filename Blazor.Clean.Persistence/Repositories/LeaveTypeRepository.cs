using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Domain;
using Blazor.Clean.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Clean.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(BlazorCleanDbContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(q => q.Name == name) == false;
        }
    }
}