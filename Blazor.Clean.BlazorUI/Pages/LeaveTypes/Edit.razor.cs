﻿using Blazor.Clean.BlazorUI.Contracts;
using Blazor.Clean.BlazorUI.Models.LeaveTypes;
using Blazor.Clean.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components;

namespace Blazor.Clean.BlazorUI.Pages.LeaveTypes
{
    public partial class Edit
    {
        [Inject]
        ILeaveTypeService _client { get; set; }

        [Inject]
        NavigationManager _navManager { get; set; }

        [Parameter]
        public int id { get; set; }
        public string Message { get; private set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            leaveType = await _client.GetLeaveTypeDetails(id);
        }

        async Task EditLeaveType()
        {
            var response = await _client.UpdateLeaveType(id, leaveType);
            if (response.Success)
            {
                _navManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }
    }
}