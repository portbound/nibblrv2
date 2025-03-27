using Shared.Models;

namespace Server.Repositories.Interfaces;

public interface IPantryRepository {
    Task<bool> CreateAsync(IEnumerable<Pantry> items);
    Task<IEnumerable<Pantry>> GetAllAsync();
    Task<bool> UpdateAsync(IEnumerable<Pantry> items);
    Task<bool> DeleteAsync(Guid id);
}