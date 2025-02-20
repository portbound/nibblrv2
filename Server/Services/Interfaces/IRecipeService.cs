using Shared.DTOs;
using Shared.Models;

namespace Server.Services.Interfaces;

public interface IRecipeService {
    public Task<IEnumerable<RecipeDTO>> GetAllRecipes();
    public Task<IEnumerable<RecipeDTO>> GetRecipesByCategory(string category);
    public Task<RecipeDTO?> GetRecipeById(int id);
    public Task<bool> AddRecipe(RecipeDTO recipe);
    public Task<bool> UpdateRecipe(int id, RecipeDTO recipe);
    public Task<bool> RemoveRecipe(int id);

    // public Recipe MapAndValidate(RecipeDTO recipeDto);
    // public Recipe MapAndValidate(RecipeDTO recipeDto, Recipe existingRecipe);
    public bool Validate(RecipeDTO dto);
}