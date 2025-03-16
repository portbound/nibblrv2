using FluentValidation;
using Server.Mapping;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Server.Validators;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Services;

public class RecipeService(IRecipeRepository _recipeRepository, ITagsService _tagsService, AbstractValidator<Recipe> validator) : IRecipeService {
    
    public async Task<(bool status, Recipe recipe)> CreateAsync(CreateRecipeRequest request) {
        IEnumerable<Tag> tags = await _tagsService.GetAllAsync();
        Recipe recipe = request.MapToRecipe(tags); 
        await validator.ValidateAndThrowAsync(recipe);
        var status = await _recipeRepository.CreateAsync(recipe);
        return (status, recipe);
    }
    
    public async Task<RecipeResponse?> GetByIdAsync(Guid id) {
        Recipe? recipe = await _recipeRepository.GetByIdAsync(id);
        RecipeResponse? response = recipe?.MapToResponse();
        return response;
    }

    public async Task<RecipesResponse> GetAllAsync() {
        IEnumerable<Recipe> recipes = await _recipeRepository.GetAllAsync();
        RecipesResponse response = recipes.MapToResponse();
        return response;
    }
    
    public async Task<bool> UpdateAsync(Guid id, UpdateRecipeRequest request) {
        IEnumerable<Tag> tags = await _tagsService.GetAllAsync();
        Recipe recipe = await request.MapToRecipe(id, tags);
        await validator.ValidateAndThrowAsync(recipe);
        return await _recipeRepository.UpdateAsync(recipe);
    }
    
    public async Task<bool> DeleteByIdAsync(Guid id) {
        return await _recipeRepository.DeleteAsync(id);
    }
}

