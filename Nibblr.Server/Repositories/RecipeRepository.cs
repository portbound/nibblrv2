using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repositories.Interfaces;
using Shared.Models;

namespace Server.Repositories;

public class RecipeRepository(NibblrDbContext _dbContext) : IRecipeRepository {
    public async Task<bool> CreateAsync(Recipe recipe) {
        _dbContext.Recipes.Add(recipe);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    
    public async Task<Recipe?> GetByIdAsync(Guid id) {
        return await _dbContext.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Instructions)
            .Include(r => r.Tags)
            .FirstOrDefaultAsync(x => x.ID == id);
    }
    
    public async Task<IEnumerable<Recipe>> GetAllAsync() {
        return await _dbContext.Recipes
            .Include(r => r.Ingredients)
            .Include(r => r.Instructions)            
            .Include(r => r.Tags)
            .ToListAsync();
    }
    
    public async Task<bool> UpdateAsync(Recipe recipe) {
       Recipe? existingRecipe = await _dbContext.Recipes
           .Include(r => r.Ingredients)
           .Include(r => r.Instructions)
           .Include(r => r.Tags)
           .FirstOrDefaultAsync(x => x.ID == recipe.ID);

       if (existingRecipe == null) {
           return await Task.FromResult(false);
       }
       
       existingRecipe.Name = recipe.Name;
       existingRecipe.Description = recipe.Description;
       existingRecipe.URL = recipe.URL;
       existingRecipe.Calories = recipe.Calories;
       existingRecipe.Carbs = recipe.Carbs;
       existingRecipe.Fat = recipe.Fat;
       existingRecipe.Protein = recipe.Protein;
       existingRecipe.Ingredients = recipe.Ingredients;
       existingRecipe.Instructions = recipe.Instructions;
       existingRecipe.Tags = recipe.Tags;
       existingRecipe.Bookmarked = recipe.Bookmarked;
       _dbContext.Update(existingRecipe);
       await _dbContext.SaveChangesAsync(); 
       return await Task.FromResult(true);
    }
    
    public async Task<bool> DeleteAsync(Guid id) {
        Recipe? recipe = await _dbContext.Recipes.FirstOrDefaultAsync(x => x.ID.ToString() == id.ToString());
        if (recipe == null) {
            return await Task.FromResult(false);
        }
        _dbContext.Recipes.Remove(recipe);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
}