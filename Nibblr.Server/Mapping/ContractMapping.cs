using Newtonsoft.Json;
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
            Ingredients = request.Ingredients.Select(x => new Ingredients {
                Quantity = x.Quantity,
                Weight = x.Weight,
                WeightUnit = x.WeightUnit,
                Name = x.Name,
                Notes = x.Notes
            }).ToList(),
            Instructions = request.Instructions.Select(x => new Instructions {
                Step = x.Step,
                Body = x.Body,
            }).ToList(),
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
            Ingredients = recipe.Ingredients.Select(x => new Ingredients {
                ID = x.ID,
                RecipeID = recipe.ID,
                Quantity = x.Quantity,
                Weight = x.Weight,
                WeightUnit = x.WeightUnit,
                Name = x.Name,
                Notes = x.Notes
            }).ToList(),
            Instructions = recipe.Instructions.Select(x => new Instructions {
                ID = x.ID,
                RecipeID = recipe.ID,
                Step = x.Step,
                Body = x.Body,
            }).ToList(),
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
            Ingredients = request.Ingredients.Select(x => new Ingredients {
                RecipeID = id,
                Quantity = x.Quantity,
                Weight = x.Weight,
                WeightUnit = x.WeightUnit,
                Name = x.Name,
                Notes = x.Notes
            }).ToList(),
            Instructions = request.Instructions.Select(x => new Instructions {
                RecipeID = id,
                Step = x.Step,
                Body = x.Body,
            }).ToList(),
            Servings = request.Servings,
            Calories = request.Calories,
            Carbs = request.Carbs,
            Fat = request.Fat, 
            Protein = request.Protein,
            Bookmarked = request.Bookmarked,
        };
    }
}