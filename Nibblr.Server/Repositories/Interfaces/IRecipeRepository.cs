using Shared.Models;

namespace Server.Repositories.Interfaces;

public interface IRecipeRepository {
    Task<bool> CreateAsync(Recipe recipe);
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Recipe recipe);
    Task<bool> DeleteAsync(Guid id);
}