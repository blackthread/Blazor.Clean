using FluentValidation;
using Blazor.Clean.Application.Contracts.Persistence;
using Blazor.Clean.Application.Features.LeaveType.Command.CreateLeaveType;
using Blazor.Clean.Application.Features.LeaveType.Command.CreateToDoItem;

namespace Blazor.Clean.Application.Features.LeaveType.Commands.CreateToDoItem;

public class CreateToDoItemCommandValidator : AbstractValidator<CreateToDoItemCommand>
{
    private readonly IToDoItemRepository _toDoItemRepository;

    public CreateToDoItemCommandValidator(IToDoItemRepository toDoItemRepository)
    {
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");


        this._toDoItemRepository = toDoItemRepository;
    }
}