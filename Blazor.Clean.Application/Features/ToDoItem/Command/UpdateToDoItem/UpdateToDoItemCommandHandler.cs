using AutoMapper;
using Blazor.Clean.Application.Contracts.Logging;
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Exceptions;
using Blazor.Clean.Domain;
using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Commands.UpdateToDoItem
{
    public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IAppLogger<UpdateToDoItemCommandHandler> _logger;

        public UpdateToDoItemCommandHandler(IMapper mapper, IToDoItemRepository toDoItemRepository, IAppLogger<UpdateToDoItemCommandHandler> logger)
        {
            _mapper = mapper;
            _toDoItemRepository = toDoItemRepository;
            this._logger = logger;
        }

        public async Task<Unit> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdateToDoItemCommandValidator(_toDoItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(ToDoItem), request.Id);
                throw new BadRequestException("Invalid ToDo Item", validationResult);
            }

            // convert to domain entity object
            var toDoItemToUpdate = _mapper.Map<Domain.ToDoItem>(request);

            // add to database
            await _toDoItemRepository.UpdateAsync(toDoItemToUpdate);

            // return Unit value
            return Unit.Value;
        }
    }
}
