using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Repositories.Interfaces;
using Shared.Models;

namespace Server.Repositories;

public class PantryRepository(NibblrDbContext _dbContext) : IPantryRepository {
    public async Task<bool> CreateAsync(IEnumerable<Pantry> items) {
        foreach (Pantry item in items) {
            _dbContext.Add(item);
        }
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    
    public async Task<IEnumerable<Pantry>> GetAllAsync() {
        return await _dbContext.Pantry.AsNoTracking().ToListAsync();
    }
    
    public async Task<bool> UpdateAsync(IEnumerable<Pantry> items) {
        foreach (Pantry item in items) {
            Pantry? existing = await _dbContext.Pantry.FirstOrDefaultAsync(x => x.ID == item.ID);
            if (existing == null) {
                continue;
            }
            existing.Usage = item.Usage;
            _dbContext.Update(existing);
        }
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    
    public async Task<bool> DeleteAsync(Guid id) {
        Pantry? item = await _dbContext.Pantry.FindAsync(id);
        if (item == null) {
            return await Task.FromResult(false);
        }
        _dbContext.Pantry.Remove(item);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
}