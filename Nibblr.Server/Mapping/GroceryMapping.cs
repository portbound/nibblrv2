using System.Collections;
using Movies.Api;
using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Mapping;

public static class GroceryMapping {
    public static Grocery MapToGrocery(this CreateGroceryRequest request) {
        Guid newId = Guid.NewGuid();
        return new Grocery {
            ID = newId,
            Name = request.Name,
            Category = request.Category,
            IsInCart = false
        };
    }

    public static GroceryResponse MapToResponse(this Grocery grocery) {
        return new GroceryResponse {
            ID = grocery.ID,
            Name = grocery.Name,
            Category = grocery.Category,
            IsInCart = grocery.IsInCart
        };
    }
    
    public static GroceriesResponse MapToResponse(this IEnumerable<Grocery> groceries) {
        return new GroceriesResponse {
            Items = groceries.Select(MapToResponse)
        };
    }
}