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
    
    [HttpGet("/api/recipe/{recipeID}")]
    public async Task<IResult> GetRecipeByID(int recipeID) {
        return await new RecipeService(db).Get(recipeId: recipeID);
    }
    
    [HttpGet("/api/recipes/category/{categoryID}")]
    public async Task<IResult> GetRecipeByCategoryID(int categoryID) {
        return await new RecipeService(db).Get(categoryId: categoryID);
    }
}