
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Exceptions;
using MediatR;


namespace Blazor.Clean.Application.Features.LeaveType.Command.DeleteToDoItem
{
    public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand, Unit>
    {
        
        private readonly IToDoItemRepository _toDoItemRepository;

        public DeleteToDoItemCommandHandler(IToDoItemRepository toDoItemRepository)
        {
            
            this._toDoItemRepository = toDoItemRepository;
        }

        public async Task<Unit> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //retrieve domain entity object
            var leaveTypeToDelete = await _toDoItemRepository.GetByIdAsync(request.Id);
            if (leaveTypeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            //Remove from database
            await _toDoItemRepository.DeleteAsync(leaveTypeToDelete);

            //Return record Id
            return Unit.Value;
        }
    }
}
