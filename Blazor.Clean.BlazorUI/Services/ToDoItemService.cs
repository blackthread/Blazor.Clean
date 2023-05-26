using AutoMapper;
using Blazored.LocalStorage;
using Blazor.Clean.BlazorUI.Contracts;
using Blazor.Clean.BlazorUI.Models.LeaveTypes;
using Blazor.Clean.BlazorUI.Services.Base;

namespace Blazor.Clean.BlazorUI.Services
{
    public class ToDoItemService : BaseHttpService, IToDoItemService
    {
        private readonly IMapper _mapper;

        public ToDoItemService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            this._mapper = mapper;
        }

        public async Task<Response<Guid>> CreateToDoItem(ToDoItemVM leaveType)
        {
            try
            {
                await AddBearerToken();
                var createToDoItemCommand = _mapper.Map<CreateToDoItemCommand>(leaveType);
                await _client.ToDoItemsPOSTAsync(createToDoItemCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteLeaveType(int id)
        {
            try
            {
                await AddBearerToken();
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteToDoItem(int id)
        {
            try
            {
                await AddBearerToken();
                await _client.ToDoItemsDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            await AddBearerToken();
            var toDoDetail = await _client.LeaveTypesGETAsync(id);
            return _mapper.Map<LeaveTypeVM>(toDoDetail);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            await AddBearerToken();
            var toDoItems = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(toDoItems);
        }

        public async Task<ToDoItemVM> GetToDoItemDetails(int id)
        {
            await AddBearerToken();
            var toDoItem = await _client.ToDoItemsGETAsync(id);
            return _mapper.Map<ToDoItemVM>(toDoItem);
        }

        public async  Task<List<ToDoItemVM>> GetToDoItems()
        {
            await AddBearerToken();
            var toDoItems = await _client.ToDoItemsAllAsync();
            return _mapper.Map<List<ToDoItemVM>>(toDoItems);
        }



        public async Task<Response<Guid>> UpdateToDoItem(int id, ToDoItemVM toDoItem)
        {
            try
            {
                await AddBearerToken();
                var updateToDoItemCommand = _mapper.Map<UpdateToDoItemCommand>(toDoItem);
                await _client.ToDoItemsPUTAsync(id.ToString(), updateToDoItemCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
