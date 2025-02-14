using Microsoft.AspNetCore.Mvc;
using Nibblr;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController(IConfiguration config) : ControllerBase {

    [HttpGet("ExtractRecipe")]
    public async Task<IResult> ExtractRecipe(string url) {
        // logging
        Recipe recipe = await new OpenAiService(config).ExtractRecipe(url);
        return Results.Ok(recipe);
    }
    
    [HttpGet("CreateRecipe")]
    public async Task<IResult> CreateRecipe(List<string> ingredients) {
        // logging
        Recipe recipe = await new OpenAiService(config).CreateRecipe(ingredients);
        return Results.Ok(recipe);
    }

    [HttpGet("GetRecipes")]
    public async Task<IResult> GetRecipes() {
        // logic to get all recipes 
        return Results.Ok();
    }

    [HttpPut("UpdateRecipe")]
    public async Task<IResult> UpdateRecipe(int id, Recipe recipe) {
        // logic to lookup recipe and overwrite 
        // logging
        return Results.Ok();
    }
    
    [HttpPost("SaveRecipe")]
    public async Task<IResult> SaveRecipe(Recipe recipe) {
        // logic to save to db
        // logging
        return Results.Created();
    }

    [HttpDelete("DeleteRecipe")]
    public async Task<IResult> DeleteRecipe(int id) {
        // logic to remove from db 
        // logging
        return Results.Ok();
    }
}