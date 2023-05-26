using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems
{
    public record GetToDoItemsQuery : IRequest<List<ToDoItemDto>>
    {

    }
}
