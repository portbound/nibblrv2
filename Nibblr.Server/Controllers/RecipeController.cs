using Microsoft.AspNetCore.Mvc;
using Movies.Api;
using Server.Services.Interfaces;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;

namespace Server.Controllers;

[ApiController]
public class RecipeController(IRecipeService _recipeService) : ControllerBase {

    [HttpPost(ApiEndpoints.Recipes.Create)]
    public async Task<IActionResult> Create([FromBody] CreateRecipeRequest request) {
        var created = await _recipeService.CreateAsync(request);
        return !created.status ? 
            BadRequest() :
            Ok(created.recipe);
    }
    
    [HttpGet(ApiEndpoints.Recipes.Get)]
    public async Task<IActionResult> Get(Guid id) {
        RecipeResponse? response = await _recipeService.GetByIdAsync(id);
        return response != null
            ? Ok(response)
            : NotFound();
    }
    
    [HttpGet(ApiEndpoints.Recipes.GetAll)]
    public async Task<IActionResult> GetAll() {
         RecipesResponse response = await _recipeService.GetAllAsync();
         return Ok(response);
    }
    
    [HttpPut(ApiEndpoints.Recipes.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRecipeRequest request) {
        bool updated = await _recipeService.UpdateAsync(id, request);
        return !updated
            ? NotFound()
            : Ok(updated);
    }

    [HttpDelete(ApiEndpoints.Recipes.Delete)]
    public async Task<IActionResult> Delete(Guid id) {
        bool deleted = await _recipeService.DeleteByIdAsync(id);
        return !deleted 
            ? NotFound()
            : Ok();
    }    
}