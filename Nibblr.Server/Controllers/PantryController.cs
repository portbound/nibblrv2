using Microsoft.AspNetCore.Mvc;
using Movies.Api;
using Server.Services.Interfaces;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Controllers;

[ApiController]
public class PantryController(IPantryService _service) : ControllerBase {
    [HttpPost(ApiEndpoints.Pantry.Create)]
    public async Task<IActionResult> Create([FromBody] List<CreatePantryRequest> request) {
        (bool status, List<Pantry> items) created = await _service.CreateAsync(request);
        return !created.status 
            ? BadRequest() 
            : Ok(created.items);
    }

    [HttpGet(ApiEndpoints.Pantry.GetAll)]
    public async Task<IActionResult> GetAll() {
        FullPantryResponse response = await _service.GetAllAsync();
        return Ok(response);
    }
    
    [HttpPost(ApiEndpoints.Pantry.Update)]
    public async Task<IActionResult> Update([FromRoute] List<Guid> ids, [FromBody] List<UpdatePantryRequest> request) {
        bool updated = await _service.UpdateAsync(ids, request);
        return !updated
            ? NotFound() 
            : Ok(updated);
    }

    [HttpDelete(ApiEndpoints.Pantry.Delete)]
    public async Task<IActionResult> Delete(Guid id) {
        bool deleted = await _service.DeleteByIdAsync(id);
        return deleted
            ? BadRequest()
            : Ok();
    }
}