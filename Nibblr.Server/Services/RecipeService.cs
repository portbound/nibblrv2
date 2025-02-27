using FluentValidation;
using Server.Mapping;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Server.Validations;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.DTOs;
using Shared.Models;

namespace Server.Services;

public class RecipeService(IRecipeRepository _recipeRepository) : IRecipeService {
    
    public async Task<bool> CreateAsync(CreateRecipeRequest request) {
        Recipe recipe = request.MapToRecipe(); 
        return await _recipeRepository.CreateAsync(recipe);
    }
    
    public async Task<RecipeResponse?> GetByIdAsync(int id) {
        Recipe? recipe = await _recipeRepository.GetByIdAsync(id);
        RecipeResponse? response = recipe?.MapToResponse();
        return response;
    }

    public async Task<RecipesResponse> GetAllAsync() {
        IEnumerable<Recipe> recipes = await _recipeRepository.GetAllAsync();
        RecipesResponse response = recipes.MapToResponse();
        return response;
    }
    
    public async Task<bool> UpdateAsync(int id, UpdateRecipeRequest request) {
        Recipe recipe = request.MapToRecipe(id);
        return await _recipeRepository.UpdateAsync(recipe);
    }
    
    public async Task<bool> DeleteByIdAsync(int id) {
        return await _recipeRepository.DeleteAsync(id);
    }

    public bool Validate(RecipeDTO dto) {
        RecipeValidator validator = new();
        validator.ValidateAndThrow(dto);
        return true;
    }
}

