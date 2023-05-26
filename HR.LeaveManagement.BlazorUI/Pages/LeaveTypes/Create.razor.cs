using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Blazor.Clean.BlazorUI;
using Blazor.Clean.BlazorUI.Shared;
using System.Net;
using System.Numerics;
using Blazor.Clean.BlazorUI.Contracts;
using Blazor.Clean.BlazorUI.Models.LeaveTypes;
using Blazored.Toast.Services;

namespace Blazor.Clean.BlazorUI.Pages.LeaveTypes
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }
        [Inject]
        ILeaveTypeService _client { get; set; }
        [Inject]
        IToastService toastService { get; set; }
        public string Message { get; private set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();
        async Task CreateLeaveType()
        {
            var response = await _client.CreateLeaveType(leaveType);
            if (response.Success)
            {
                toastService.ShowSuccess("Leave Type Created Successfully");
                _navManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }
    }
}
