using Blazor.Clean.BlazorUI.Models.LeaveTypes;
using Blazor.Clean.BlazorUI.Services.Base;

namespace Blazor.Clean.BlazorUI.Contracts
{
    public interface IToDoItemService
    {
        Task<List<ToDoItemVM>> GetToDoItems();
        Task<ToDoItemVM> GetToDoItemDetails(int id);
        Task<Response<Guid>> CreateToDoItem(ToDoItemVM leaveType);
        Task<Response<Guid>> UpdateToDoItem(int id, ToDoItemVM leaveType);
        Task<Response<Guid>> DeleteToDoItem(int id);
    }
}
