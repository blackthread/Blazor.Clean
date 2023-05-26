using AutoMapper;
using Blazor.Clean.Application.Features.LeaveType.Command.CreateToDoItem;
using Blazor.Clean.Application.Features.LeaveType.Commands.UpdateToDoItem;
using Blazor.Clean.Application.Features.LeaveType.Queries.GetAllToDoItems;
using Blazor.Clean.Domain;


namespace Blazor.Clean.Application.MappingProfiles
{
    public class ToDoItemProfile : Profile
    {
        public ToDoItemProfile()
        {
            CreateMap<ToDoItemDto, ToDoItem>().ReverseMap();
            CreateMap<ToDoItem, ToDoItemDto>();
            CreateMap<CreateToDoItemCommand, ToDoItem>();
            CreateMap<UpdateToDoItemCommand, ToDoItem>();

        }
    }
}