using Shared.Contracts.Requests;
using Shared.Contracts.Responses;
using Shared.Models;

namespace Server.Mapping;

public static class PantryMapping {
    public static Pantry MapToPantry(this CreatePantryRequest request) {
        Guid newId = Guid.NewGuid();
        return new Pantry {
            ID = newId,
            Name = request.Name,
            Category = request.Category,
            Usage = request.Usage,
            
        };
    }

    public static PantryResponse MapToResponse(this Pantry item) {
        return new PantryResponse {
            ID = item.ID,
            Name = item.Name,
            Category = item.Category,
            Usage = item.Usage,
        };
    }

    public static FullPantryResponse MapToResponse(this IEnumerable<Pantry> items) {
        return new FullPantryResponse {
            Items = items.Select(MapToResponse)
        };
    }    

    public static Pantry MapToPantry(this UpdatePantryRequest item, Guid id) {
        return new Pantry {
            ID = id,
            Name = item.Name,
            Category = item.Category,
            Usage = item.Usage += 1,
        };
    }
}