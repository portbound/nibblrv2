using FluentValidation;
using Server.Mapping;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Services;

public class PantryService(IPantryRepository _repository, AbstractValidator<Pantry> validator) : IPantryService {
    public async Task<(bool status, List<Pantry> items)> CreateAsync(List<CreatePantryRequest> request) {
        List<Pantry> items = [];
        foreach (CreatePantryRequest r in request) {
            Pantry item = r.MapToPantry(); 
            await validator.ValidateAndThrowAsync(item);
            items.Add(item);
        }
        var status = await _repository.CreateAsync(items);
        return (status, items);    
    }
    public async Task<FullPantryResponse> GetAllAsync() {
        IEnumerable<Pantry> items = await _repository.GetAllAsync();
        FullPantryResponse response = items.MapToResponse();
        return response;
    }
    public async Task<bool> UpdateAsync(List<Guid> ids, List<UpdatePantryRequest> request) {
        List<Pantry> items = [];
        foreach (UpdatePantryRequest r in request) {
            Pantry item = r.MapToPantry(r.ID); 
            await validator.ValidateAndThrowAsync(item);
            items.Add(item);
        }
        var status = await _repository.UpdateAsync(items);
        return status;
    }
    public async Task<bool> DeleteByIdAsync(Guid id) {
        return await _repository.DeleteAsync(id);
    }
}