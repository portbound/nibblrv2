using Microsoft.AspNetCore.Mvc;
using Server.Services.Interfaces;
using Shared.DTOs;

namespace Server.Controllers.Core;

[ApiController]
[Route("[controller]")]
public class RecipeController(IRecipeService _recipeService) : ControllerBase {

    [HttpGet("/api/recipes")]
    public async Task<IEnumerable<RecipeDTO>> GetAllRecipes() {
        return await _recipeService.GetAllRecipes();
    }
    [HttpGet("/api/recipes/categories/{category}")]
    public async Task<IEnumerable<RecipeDTO>> GetRecipesByCategory(string category) {
        return await _recipeService.GetRecipesByCategory(category);
    }
    
    [HttpGet("/api/recipes/{id:int}")]
    public async Task<RecipeDTO> GetRecipeById(int id) {
        return await _recipeService.GetRecipeById(id);
    }

    [HttpPut("/api/recipes/{id:int}")]
    public async Task<IResult> UpdateRecipe(int id, RecipeDTO recipeDto) {
        await _recipeService.UpdateRecipe(id, recipeDto);
        return Results.Ok();
    }

    [HttpPost("/api/recipes/")]
    public async Task<IResult> AddRecipe(RecipeDTO recipeDto) {
        await _recipeService.AddRecipe(recipeDto);
        return Results.Ok();
    }

    [HttpDelete("/api/recipes/{id:int}")]
    public async Task<IResult> DeleteRecipe(int id) {
        await _recipeService.RemoveRecipe(id);
        return Results.Ok();
    }
}