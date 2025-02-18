using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext) : IRepository<TEntity> where TEntity : class {
    public async Task<IEnumerable<TEntity>> GetAllAsync() {
        return await dbContext.Set<TEntity>().ToListAsync<TEntity>();
    }
    public async Task<TEntity?> GetByIdAsync(int id) {
        return await dbContext.Set<TEntity>().FindAsync(id);
    }
    public async Task AddAsync(TEntity entity) {
        dbContext.Set<TEntity>().Add(entity);
        await dbContext.SaveChangesAsync();    
    }
    public async Task UpdateAsync(TEntity entity) {
        dbContext.Set<TEntity>().Update(entity);
        // dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();    
    }
    public async Task RemoveAsync(TEntity entity) {
        dbContext.Set<TEntity>().Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}