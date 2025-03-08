using Server.Repositories.Interfaces;
using Server.Services.Interfaces;
using Shared.Models;

namespace Server.Services;

public class TagsService(ITagsRepository _tagsRepository) : ITagsService {
    public async Task<IEnumerable<Tag>> GetAllAsync() {
        return await _tagsRepository.GetAllAsync();
    }
}