using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using Nibblr;
using Server.Data;
using Server.Repositories;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController(IRecipeService _recipeService) : ControllerBase {
    
    
    [HttpGet("/api/recipes")]
    public async Task<IResult> GetAllRecipes() {
        IResult foo = await _recipeService.GetAllRecipes();
        return Results.Ok(foo);
    }
    
    // [HttpGet("/api/recipes/{recipeName}")]
    // public async Task<IResult> Get(string recipeName) {
    //     return await new RecipeService().Get(recipeName: recipeName);
    // }
    //
    // [HttpGet("/api/recipes/categories/{categoryName}")]
    // public async Task<IResult> GetRecipeByCategory(string categoryName) {
    //     return await new RecipeService().Get(categoryName: categoryName);
    // }
}