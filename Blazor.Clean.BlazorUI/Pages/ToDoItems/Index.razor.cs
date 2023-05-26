using Blazored.Toast.Services;
using Blazor.Clean.BlazorUI.Contracts;
using Blazor.Clean.BlazorUI.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace Blazor.Clean.BlazorUI.Pages.ToDoItems
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IToDoItemService ToDoItemService { get; set; }


        [Inject]
        IToastService toastService { get; set; }

        public List<ToDoItemVM> ToDoItems { get; private set; }
        public string Message { get; set; } = string.Empty;

    
        
        protected override async Task OnInitializedAsync()
        {
            ToDoItems = await ToDoItemService.GetToDoItems();
        }
    }
}