using FluentValidation;
using Server.Mapping;
using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Services;

public class GroceryService(IGroceryRepository _repository, AbstractValidator<Grocery> validator) : IGroceryService {
    public async Task<(bool status, Grocery grocery)> CreateAsync(CreateGroceryRequest request) {
        Grocery grocery = request.MapToGrocery(); 
        await validator.ValidateAndThrowAsync(grocery);
        var status = await _repository.CreateAsync(grocery);
        return (status, grocery);    
    }
    public async Task<GroceriesResponse> GetAllAsync() {
        IEnumerable<Grocery> groceries = await _repository.GetAllAsync();
        GroceriesResponse response = groceries.MapToResponse();
        return response;
    }
    public async Task<bool> DeleteByIdAsync(Guid id) {
        return await _repository.DeleteAsync(id);
    }
}