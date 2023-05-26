using Blazor.Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Clean.Domain;

public class LeaveType : BaseEntity
{
    
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
