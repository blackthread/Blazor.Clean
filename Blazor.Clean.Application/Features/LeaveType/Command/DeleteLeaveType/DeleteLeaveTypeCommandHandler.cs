
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Exceptions;
using MediatR;


namespace Blazor.Clean.Application.Features.LeaveType.Command.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //retrieve domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
            if (leaveTypeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            //Remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            //Return record Id
            return Unit.Value;
        }
    }
}
