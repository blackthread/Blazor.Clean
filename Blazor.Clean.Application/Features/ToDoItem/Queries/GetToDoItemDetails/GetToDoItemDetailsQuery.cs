using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems;
using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{

    /*
     - record: In C#, a record is a reference type that represents an immutable set of values or data.
     */
    public record GetToDoItemDetailsQuery(int Id) : IRequest<ToDoItemDto>
    {
    }
}