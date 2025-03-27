using Microsoft.EntityFrameworkCore;
using Movies.Api;
using Server.Data;
using Server.Repositories.Interfaces;
using Shared.Models;

namespace Server.Repositories;

public class GroceryRepository(NibblrDbContext _dbContext) : IGroceryRepository {
    public async Task<bool> CreateAsync(Grocery grocery) {
        _dbContext.Add(grocery);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
    
    public async Task<IEnumerable<Grocery>> GetAllAsync() {
        return await _dbContext.Groceries.AsNoTracking().ToListAsync();
    }
    
    public async Task<bool> DeleteAsync(Guid id) {
        Grocery? grocery = await _dbContext.Groceries.FirstOrDefaultAsync(x => x.ID == id);
        if (grocery == null) {
            return await Task.FromResult(false);
        }
        _dbContext.Groceries.Remove(grocery);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }
}