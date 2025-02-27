using NuGet.Protocol;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Mapping;

public static class ContractMapping {

    public static Recipe MapToRecipe(this CreateRecipeRequest request) {
        return new Recipe {
            Name = request.Name,
            Category = request.Category,
            URL = !string.IsNullOrEmpty(request.URL) ? request.URL : string.Empty,
            Description = request.Description,
            IngredientsJson = !string.IsNullOrEmpty(request.IngredientsJson) ? request.IngredientsJson : string.Empty,
            InstructionsJson = !string.IsNullOrEmpty(request.InstructionsJson) ? request.InstructionsJson : string.Empty,
            Servings = request.Servings,
            Calories = request.Calories,
            Carbs = request.Carbs,
            Fat = request.Fat,
            Protein = request.Protein,
            Bookmarked = request.Bookmarked,
        };
    }

    public static RecipeResponse? MapToResponse(this Recipe recipe) {
        return new RecipeResponse {
            ID = recipe.ID, 
            Name = recipe.Name,
            Category = recipe.Category,
            URL = !string.IsNullOrEmpty(recipe.URL) ? recipe.URL : string.Empty,
            Description = recipe.Description,
            IngredientsJson = !string.IsNullOrEmpty(recipe.IngredientsJson) ? recipe.IngredientsJson : string.Empty,
            InstructionsJson = !string.IsNullOrEmpty(recipe.InstructionsJson) ? recipe.InstructionsJson : string.Empty,
            Servings = recipe.Servings,
            Calories = recipe.Calories,
            Carbs = recipe.Carbs,
            Fat = recipe.Fat,
            Protein = recipe.Protein,
            Bookmarked = false,
        };
    }

    public static RecipesResponse MapToResponse(this IEnumerable<Recipe> recipes) {
        return new RecipesResponse {
            Items = recipes.Select(MapToResponse)
        };
    }

    public static Recipe MapToRecipe(this UpdateRecipeRequest request, int id) {
        return new Recipe {
            ID = id,
            Name = request.Name,
            Category = request.Category,
            URL = !string.IsNullOrEmpty(request.URL) ? request.URL : string.Empty,
            Description = request.Description,
            IngredientsJson = !string.IsNullOrEmpty(request.IngredientsJson) ? request.IngredientsJson : string.Empty,
            InstructionsJson = !string.IsNullOrEmpty(request.InstructionsJson) ? request.InstructionsJson : string.Empty,
            Servings = request.Servings,
            Calories = request.Calories,
            Carbs = request.Carbs,
            Fat = request.Fat, 
            Protein = request.Protein,
            Bookmarked = request.Bookmarked,
        };
    }
}