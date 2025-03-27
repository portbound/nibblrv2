using FluentValidation;
using Shared.Models;

namespace Server.Validators;

public class GroceryValidator : AbstractValidator<Grocery> {
    public GroceryValidator() {
        RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Category).NotEmpty();
        RuleFor(x => x.IsInCart).NotEmpty();
    }
}