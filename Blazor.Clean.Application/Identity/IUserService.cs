using Blazor.Clean.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Clean.Application.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> GetEmployee(string UserId);

        public string UserId { get; }
    }
}
