using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Services.Interfaces;

public interface IRecipeService {
    public Task<(bool status, Recipe recipe)> CreateAsync(CreateRecipeRequest request);
    public Task<RecipeResponse?> GetByIdAsync(int id);
    public Task<RecipesResponse> GetAllAsync();
    public Task<bool> UpdateAsync(int id, UpdateRecipeRequest request);
    public Task<bool> DeleteByIdAsync(int id);
}