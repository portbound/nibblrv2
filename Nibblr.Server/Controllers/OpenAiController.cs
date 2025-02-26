using Microsoft.AspNetCore.Mvc;
using Server.Mapping;
using Server.Services;
using Server.Services.Ai;
using Server.Services.Interfaces;
using Shared.Contracts.Requests;
using Shared.Models;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController(IRecipeService _recipeService) : ControllerBase {

    [HttpGet("/api/AI/extract/")]
    public async Task<IActionResult> ExtractRecipe(string url) {
        Recipe? recipe = await new OpenAiService().ExtractRecipe(url);
        return (recipe != null)
            ? Ok(recipe)
            : NotFound();
    }
    
    [HttpGet("/api/AI/create")]
    public async Task<IActionResult> CreateRecipe(string ingredients) {
        Recipe? recipe = await new OpenAiService().CreateRecipe(ingredients);
        return (recipe != null) 
            ? Ok(recipe)
            : NotFound();
    }
}