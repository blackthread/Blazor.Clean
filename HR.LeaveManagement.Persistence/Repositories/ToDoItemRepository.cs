using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Domain;
using Blazor.Clean.Persistence.DatabaseContext;

namespace Blazor.Clean.Persistence.Repositories
{
    public class ToDoItemRepository : GenericRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(BlazorCleanDbContext context) : base(context)
        {
        }

    }
}