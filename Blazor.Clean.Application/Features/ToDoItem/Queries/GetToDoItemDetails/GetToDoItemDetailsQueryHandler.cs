using AutoMapper;
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Exceptions;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems;
using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
/*
 - IRequestHandler: Defines a handler for a request

 */
{
    public class GetToDoItemDetailsQueryHandler : IRequestHandler<GetToDoItemDetailsQuery,
        ToDoItemDto>
    {
        private readonly IMapper _mapper;
        private readonly IToDoItemRepository _toDoItemRepository;

        public GetToDoItemDetailsQueryHandler(IMapper mapper, IToDoItemRepository toDoItemRepository)
        {
            this._mapper = mapper;
            this._toDoItemRepository = toDoItemRepository;
        }

        public async Task<ToDoItemDto> Handle(GetToDoItemDetailsQuery request, CancellationToken cancellationToken)
        {
            var toDoItem = await _toDoItemRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<ToDoItemDto>(toDoItem);

            if (toDoItem == null)
            
                throw new NotFoundException(nameof(toDoItem), request.Id);
            

            return data;

        }
    }
}
