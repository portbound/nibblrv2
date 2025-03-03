using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Server.Services.Interfaces;
using Shared.Contracts.Requests;
using Shared.Models;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController(IRecipeService _recipeService) : ControllerBase {

    [HttpGet("/api/AI/extract/")]
    public async Task<IActionResult> ExtractRecipe(string url) {
        CreateRecipeRequest request = await new OpenAiService().ExtractRecipe(url);
        return (request != null)
            ? Ok(request)
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