using Microsoft.AspNetCore.Mvc;
using Movies.Api;
using Server.Services.Interfaces;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Controllers;

[ApiController]
public class TagsController(ITagsService _tagsService) : ControllerBase {
    
    [HttpGet(ApiEndpoints.Tags.GetAll)]
    public async Task<IActionResult> GetAll() {
        IEnumerable<Tags> tags = await _tagsService.GetAllAsync();
        return Ok(tags);
    }
}