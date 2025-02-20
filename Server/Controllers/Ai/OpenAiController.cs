using Microsoft.AspNetCore.Mvc;
using Server.Services.Ai;
using Server.Services.Interfaces;
using Shared.DTOs;

namespace Server.Controllers.Ai;

[ApiController]
[Route("[controller]")]
public class OpenAiController(IRecipeService _recipeService) : ControllerBase {

    [HttpGet("/api/AI/extract/")]
    public async Task<IResult> ExtractRecipe(string url) {
        RecipeDTO recipeDto = await new OpenAiService().ExtractRecipe(url);
        return Results.Ok(recipeDto);
    }
    
    [HttpGet("/api/AI/create")]
    public async Task<IResult> CreateRecipe(string ingredients) {
        RecipeDTO recipeDto = await new OpenAiService().CreateRecipe(ingredients);
        return Results.Ok(recipeDto);
    }
}