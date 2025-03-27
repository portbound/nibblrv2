using FluentValidation;
using Shared.Models;

namespace Server.Validators;

public class PantryValidator :AbstractValidator<Pantry>  {
    public PantryValidator() {
        RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Category).IsInEnum().NotEmpty();
        RuleFor(x => x.Usage).GreaterThanOrEqualTo(0);
    }
}