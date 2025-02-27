using Shared.Models;

namespace Server.Repositories.Interfaces;

public interface IRecipeRepository {
    Task<bool> CreateAsync(Recipe recipe);
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(Recipe recipe);
    Task<bool> DeleteAsync(int id);
    
    // Task<IEnumerable<Recipe>> GetByCategoryAsync(string category);
}