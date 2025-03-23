namespace Shared.Contracts.Responses;

public class GroceriesResponse {
    public IEnumerable<GroceryResponse> Items { get; set; } = [];
}