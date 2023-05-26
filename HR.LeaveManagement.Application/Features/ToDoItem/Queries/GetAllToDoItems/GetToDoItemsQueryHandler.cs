using AutoMapper;
using Blazor.Clean.Application.Contracts.Logging;
using Blazor.Clean.Application.Contracts.Persistence;
using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems
{
    public class GetToDoItemsQueryHandler : IRequestHandler<GetToDoItemsQuery, List<ToDoItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IToDoItemRepository _toDoItemRepository;   
        private readonly IAppLogger<GetToDoItemsQueryHandler> _logger;

        public GetToDoItemsQueryHandler(IMapper mapper, IToDoItemRepository toDoItemRepository,
            IAppLogger<GetToDoItemsQueryHandler> logger)
        {
            this._mapper = mapper;
            this._toDoItemRepository = toDoItemRepository;
            this._logger = logger;
        }

        public async Task<List<ToDoItemDto>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _toDoItemRepository.GetAsync();
            var data = _mapper.Map<List<ToDoItemDto>>(leaveTypes);
            _logger.LogInformation("Leave types were retrieved successfully");
            return data;
        }
    }
}
