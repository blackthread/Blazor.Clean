using AutoMapper;
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Exceptions;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace Blazor.Clean.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
/*
 - IRequestHandler: Defines a handler for a request

 */
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery,
        LeaveTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            var data = _mapper.Map<LeaveTypeDto>(leaveType);

            if (leaveType == null)
            
                throw new NotFoundException(nameof(LeaveType), request.Id);
            

            return data;

        }
    }
}
