using Server.Repositories.Interfaces;
using Shared.Models;

namespace Server.Services.Interfaces;

public interface ITagsService {
    public Task<IEnumerable<Tag>> GetAllAsync();
}