using Server.Services.Interfaces;
using Server.Validators;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Mapping;

public static class ContractMapping {
    public static Recipe MapToRecipe(this CreateRecipeRequest request, IEnumerable<Tag> existingTags = null) {
        List<Tag> sortedTags = [];
        if (existingTags != null) {
            foreach (Tag incomingTag in request.Tags) {
                Tag? existingTag = existingTags
                    .FirstOrDefault(t => t.Name == incomingTag.Name);
                sortedTags.Add(existingTag ?? incomingTag);
            }
        }
        return new Recipe {
            Name = request.Name,
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
            Tags = sortedTags,
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
            Tags = recipe.Tags.Select(x => new Tag {
                ID = x.ID,
                Name = x.Name,
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

    public static async Task<Recipe> MapToRecipe(this UpdateRecipeRequest request, int id, IEnumerable<Tag> existingTags) {
        List<Tag> sortedTags = [];
        foreach (Tag incomingTag in request.Tags) {
            Tag? existingTag = existingTags
                .FirstOrDefault(t => t.Name == incomingTag.Name);
            sortedTags.Add(existingTag ?? incomingTag);
        }
        return new Recipe {
            ID = id,
            Name = request.Name,
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
            Tags = sortedTags,
            Servings = request.Servings,
            Calories = request.Calories,
            Carbs = request.Carbs,
            Fat = request.Fat, 
            Protein = request.Protein,
            Bookmarked = request.Bookmarked,
        };
    }
}