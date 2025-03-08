using Server.Services.Interfaces;
using Shared.Models;

namespace Server.Validators;

public class TagValidator(ITagsService _tagsService) {
    private IEnumerable<Tag> _existingTags;

    public List<Tag> SortedTags { get; set; }

    public async Task<List<Tag>> SortTagsAsync(IEnumerable<Tag> tags) {
        _existingTags = await _tagsService.GetAllAsync();

        foreach (Tag incomingTag in tags) {
            Tag? existingTag = _existingTags
                .FirstOrDefault(t => t.Name == incomingTag.Name);
            SortedTags.Add(existingTag ?? incomingTag);
        }
        return SortedTags;
    }
}