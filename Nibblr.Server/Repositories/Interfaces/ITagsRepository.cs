using Movies.Api;
using Shared.Models;

namespace Server.Repositories.Interfaces;

public interface ITagsRepository {
    Task<IEnumerable<Tag>> GetAllAsync();
}