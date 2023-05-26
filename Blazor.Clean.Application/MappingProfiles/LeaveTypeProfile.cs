using AutoMapper;
using Blazor.Clean.Application.Features.LeaveType.Command.CreateLeaveType;
using Blazor.Clean.Application.Features.LeaveType.Commands.UpdateLeaveType;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Blazor.Clean.Domain;

namespace Blazor.Clean.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();

        }
    }
}
