using FluentValidation;
using Blazor.Clean.Application.Contracts.Persistence;

namespace Blazor.Clean.Application.Features.LeaveType.Commands.UpdateToDoItem;

public class UpdateToDoItemCommandValidator : AbstractValidator<UpdateToDoItemCommand>
{
    private readonly IToDoItemRepository _toDoItemRepository;

    public UpdateToDoItemCommandValidator(IToDoItemRepository toDoItemRepository)
    {
        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(ToDoItemMustExist);

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");


        this._toDoItemRepository = toDoItemRepository;
    }

    private async Task<bool> ToDoItemMustExist(int id, CancellationToken arg2)
    {
        var toDoItem = await _toDoItemRepository.GetByIdAsync(id);
        return toDoItem != null;
    }


}