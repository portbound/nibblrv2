using Shared.Models;

namespace Server.Repositories.Interfaces;

public interface IRecipeRepository {
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int id);
    Task AddAsync(Recipe recipe);
    Task UpdateAsync(Recipe recipe);
    Task RemoveAsync(Recipe recipe);
    
    Task<IEnumerable<Recipe>> GetByCategoryAsync(string category);
}