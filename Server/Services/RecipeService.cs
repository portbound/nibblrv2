using Nibblr;
using NuGet.Protocol.Core.Types;
using Server.Repositories;
using Server.Services.Logging;

namespace Server.Services;

public class RecipeService(IRepository<Recipe> recipeRepository) : IRecipeService {
    private readonly Logger logger = Logger.Default;
    
    public async Task<IResult> GetAllRecipes() {
        IEnumerable<Recipe> recipes = await recipeRepository.GetAllAsync();
        return Results.Ok(recipes);
    }

    public async Task<IResult> GetRecipeById(int id) {
        Recipe? recipe = await recipeRepository.GetByIdAsync(id);

        return recipe != null
            ? Results.Ok(recipe)
            : Results.NotFound();
    }

    public void ValidateRecipe(Recipe recipe) { }
}