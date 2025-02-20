using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Server.Exceptions.Types;
using Server.Infrastructure;
using Server.Infrastructure.Validations;
using Server.Repositories;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Shared.DTOs;
using Shared.Models;

namespace Server.Services;

public class RecipeService(IRecipeRepository recipeRepository, IMapper mapper) : IRecipeService {
    public async Task<IEnumerable<RecipeDTO>> GetAllRecipes() {
        IEnumerable<Recipe> recipes = await recipeRepository.GetAllAsync();
        return mapper.Map<IEnumerable<RecipeDTO>>(recipes);
    }
    public async Task<IEnumerable<RecipeDTO>> GetRecipesByCategory(string category) {
        IEnumerable<Recipe> recipes = await recipeRepository.GetByCategoryAsync(category);
        return mapper.Map<IEnumerable<RecipeDTO>>(recipes);
    }
    public async Task<RecipeDTO?> GetRecipeById(int id) {
        Recipe? recipe = await recipeRepository.GetByIdAsync(id);
        if (recipe == null) {
            throw new NotFoundException($"Recipe {id} not found");
        }
        return mapper.Map<RecipeDTO>(recipe);
    }
    public async Task<bool> AddRecipe(RecipeDTO recipeDto) {
        Validate(recipeDto);
        Recipe? recipeEntity = mapper.Map<Recipe>(recipeDto);
        await recipeRepository.AddAsync(recipeEntity);
        return true;
    }
    public async Task<bool> UpdateRecipe(int id, RecipeDTO recipeDto) {
        Recipe? existingRecipe = await recipeRepository.GetByIdAsync(id);
        if (existingRecipe == null) {
            throw new NotFoundException($"Recipe {id} not found");        }
        Validate(recipeDto);
        Recipe? recipeEntity = mapper.Map(recipeDto, existingRecipe);
        await recipeRepository.UpdateAsync(recipeEntity);
        return true;
    }
    public async Task<bool> RemoveRecipe(int id) {
        Recipe? recipe = await recipeRepository.GetByIdAsync(id);
        if (recipe == null) {
            throw new NotFoundException($"Recipe {id} not found");
        }
        await recipeRepository.RemoveAsync(recipe);
        return true;
    }
    
    public bool Validate(RecipeDTO dto) {
        RecipeValidator validator = new();
        validator.ValidateAndThrow(dto);
        return true;
    }
}

