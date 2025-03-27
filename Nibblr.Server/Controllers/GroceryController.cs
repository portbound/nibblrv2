using Microsoft.AspNetCore.Mvc;
using Movies.Api;
using Server.Services.Interfaces;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Controllers;

[ApiController]
public class GroceryController(IGroceryService _groceryService) : ControllerBase {

    [HttpPost(ApiEndpoints.Groceries.Create)]
    public async Task<IActionResult> Create([FromBody] CreateGroceryRequest request) {
        (bool status, Grocery grocery) created = await _groceryService.CreateAsync(request);
        return !created.status 
            ? BadRequest() 
            : Ok(created.grocery);
    }

    [HttpGet(ApiEndpoints.Groceries.GetAll)]
    public async Task<IActionResult> GetAll() {
        GroceriesResponse response = await _groceryService.GetAllAsync();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Groceries.Delete)]
    public async Task<IActionResult> Delete(Guid id) {
        bool deleted = await _groceryService.DeleteByIdAsync(id);
        return deleted
            ? BadRequest()
            : Ok();
    }
}