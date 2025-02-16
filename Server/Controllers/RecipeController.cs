using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using Nibblr;
using Server.Data;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController(ApplicationDbContext db) : ControllerBase {
    [HttpGet("/api/recipes")]
    public async Task<IResult> GetAllRecipes() {
        return await new RecipeService(db).Get();
    }
    
    [HttpGet("/api/recipes/{recipeName}")]
    public async Task<IResult> Get(string recipeName) {
        return await new RecipeService(db).Get(recipeName: recipeName);
    }
    
    [HttpGet("/api/recipes/categories/{categoryName}")]
    public async Task<IResult> GetRecipeByCategory(string categoryName) {
        return await new RecipeService(db).Get(categoryName: categoryName);
    }
}