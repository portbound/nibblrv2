using FluentValidation;
using Shared.DTOs;

namespace Server.Validations;

public class RecipeValidator : AbstractValidator<RecipeDTO> {
    public RecipeValidator() {
        RuleFor(recipe => recipe.Name).NotEmpty();        
        RuleFor(recipe => recipe.Category).NotEmpty();
        RuleFor(recipe => recipe.Instructions).NotEmpty();
        RuleForEach(recipe => recipe.Instructions).ChildRules(instructions =>
        {
            instructions.RuleFor(x => x.Step).NotEmpty();
            instructions.RuleFor(x => x.Body).NotEmpty();
        });
        RuleFor(recipe => recipe.Ingredients).NotEmpty();
        RuleForEach(recipe => recipe.Ingredients).ChildRules(ingredients =>
        {
            ingredients.RuleFor(x => x.Name).NotEmpty();
        });
        RuleFor(recipe => recipe.Macros).NotEmpty();
    }
}