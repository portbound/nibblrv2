using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Services.Interfaces;

public interface IRecipeService {
    public Task<(bool status, Recipe recipe)> CreateAsync(CreateRecipeRequest request);
    public Task<RecipeResponse?> GetByIdAsync(Guid id);
    public Task<RecipesResponse> GetAllAsync();
    public Task<bool> UpdateAsync(Guid id, UpdateRecipeRequest request);
    public Task<bool> DeleteByIdAsync(Guid id);
}