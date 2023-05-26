using System.ComponentModel.DataAnnotations;

namespace Blazor.Clean.BlazorUI.Models.LeaveTypes
{
    public class ToDoItemVM
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}
