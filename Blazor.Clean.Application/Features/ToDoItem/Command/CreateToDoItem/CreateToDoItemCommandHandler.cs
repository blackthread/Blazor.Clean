using AutoMapper;
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Exceptions;
using Blazor.Clean.Application.Features.LeaveType.Command.CreateToDoItem;
using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Commands.CreateToDoItem
{
    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IToDoItemRepository _toDoItemRepository;

        public CreateToDoItemCommandHandler(IMapper mapper, IToDoItemRepository toDoItemRepository)
        {
            _mapper = mapper;
            _toDoItemRepository = toDoItemRepository;
        }

        public async Task<int> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateToDoItemCommandValidator(_toDoItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave type", validationResult);

            // convert to domain entity object
            var toDoItemToCreate = _mapper.Map<Domain.ToDoItem>(request);

            // add to database
            await _toDoItemRepository.CreateAsync(toDoItemToCreate);

            // retun record id
            return toDoItemToCreate.Id;
        }
    }
}