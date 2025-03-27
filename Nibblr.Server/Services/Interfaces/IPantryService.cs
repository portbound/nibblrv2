using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Services.Interfaces;

public interface IPantryService {
    public Task<(bool status, List<Pantry> items)> CreateAsync(List<CreatePantryRequest> request);
    public Task<FullPantryResponse> GetAllAsync();
    public Task<bool> UpdateAsync(List<Guid> ids, List<UpdatePantryRequest> request);
    public Task<bool> DeleteByIdAsync(Guid id);
}