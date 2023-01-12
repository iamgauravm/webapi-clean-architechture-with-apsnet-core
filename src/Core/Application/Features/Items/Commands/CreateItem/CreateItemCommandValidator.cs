using AccountOne.Application.Interfaces.Repositories;
using FluentValidation;

namespace AccountOne.Application.Features.Items.Commands.CreateItem;

public class CreateItemCommandValidator :AbstractValidator<CreateItemCommand>{
     private readonly IItemRepositoryAsync itemRepository;
     public CreateItemCommandValidator(IItemRepositoryAsync _itemRepository)
     {
        itemRepository = _itemRepository;

        RuleFor(p=>p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 200 characters.");

        RuleFor(p=>p.ItemType)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();        
     }
}