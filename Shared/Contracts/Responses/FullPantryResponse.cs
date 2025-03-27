namespace Shared.Contracts.Responses;

public class FullPantryResponse {
    public IEnumerable<PantryResponse> Items { get; set; } = [];
}