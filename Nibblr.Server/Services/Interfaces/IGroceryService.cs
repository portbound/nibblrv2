using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Services.Interfaces;

public interface IGroceryService {
    public Task<(bool status, Grocery grocery)> CreateAsync(CreateGroceryRequest request);
    public Task<GroceriesResponse> GetAllAsync();
    public Task<bool> DeleteByIdAsync(Guid id);
}