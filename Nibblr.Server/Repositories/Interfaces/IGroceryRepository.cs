using Shared.Contracts.Requests;
using Shared.Models;

namespace Server.Repositories.Interfaces;

public interface IGroceryRepository {
    Task<bool> CreateAsync(Grocery grocery);
    Task<IEnumerable<Grocery>> GetAllAsync();
    Task<bool> DeleteAsync(Guid id);
} 