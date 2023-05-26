using AutoMapper;
using Blazor.Clean.BlazorUI.Models;
using Blazor.Clean.BlazorUI.Models.LeaveTypes;
using Blazor.Clean.BlazorUI.Services.Base;

/*
 Mapping, in the context of software development, refers to the process of transforming data from one format 
or structure to another. It involves defining rules or instructions that specify how the properties or fields 
of objects in one data model should be mapped or associated with the properties or fields of objects in another data model.

In the context of AutoMapper, a profile is a class that inherits from AutoMapper.Profile and is used to define mapping configurations. 
It provides a way to organize and encapsulate mapping logic for different sets of types or scenarios.
Within a profile, you can define mappings between source and destination types using the CreateMap method. 
The CreateMap method allows you to specify how the properties of the source type should be mapped to the properties 
of the destination type.


 */

namespace Blazor.Clean.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<LeaveTypeDto, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveTypeDetailsDto, LeaveTypeVM>().ReverseMap();
            CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
            CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();

            CreateMap<ToDoItemDto, ToDoItemVM>().ReverseMap();
            //CreateMap<LeaveTypeDetailsDto, LeaveTypeVM>().ReverseMap();
           // CreateMap<CreateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
           // CreateMap<UpdateLeaveTypeCommand, LeaveTypeVM>().ReverseMap();
           // CreateMap<EmployeeVM, Employee>().ReverseMap();
        }
    }
}