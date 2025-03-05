using Microsoft.EntityFrameworkCore;
using Server.Data;
using Shared.Models;

namespace Server.Repositories.Interfaces;

public class TagsRepository(NibblrDbContext _dbContext) : ITagsRepository {
    public async Task<IEnumerable<Tags>> GetAllAsync() {
        return await _dbContext.Tags.ToListAsync();
    }
}