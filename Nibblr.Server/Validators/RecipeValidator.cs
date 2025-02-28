using FluentValidation;
using Shared.Models;

namespace Server.Validators;

public class RecipeValidator : AbstractValidator<Recipe> {
    public RecipeValidator() {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(50);
        
        RuleFor(x => x.Category).NotEmpty();
        RuleFor(x => x.Description).Length(1, 250);
        RuleFor(x => x.Bookmarked).NotNull();

        RuleFor(x => x.Servings).GreaterThan(0);
        RuleFor(x => x.Calories).InclusiveBetween(0, 10000);
        RuleFor(x => x.Carbs).InclusiveBetween(0, 1000);
        RuleFor(x => x.Fat).InclusiveBetween(0, 1000);
        RuleFor(x => x.Protein).InclusiveBetween(0, 1000);

        RuleForEach(x => x.Ingredients).ChildRules(ingredient => 
        {
            ingredient.RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        }).NotEmpty();
            
        
        RuleForEach(x => x.Instructions).ChildRules(instruction =>
        {
            instruction.RuleFor(x => x.Step).NotEmpty();
            instruction.RuleFor(x => x.Body).MaximumLength(1000).NotEmpty();
        }).NotEmpty();

    }
}