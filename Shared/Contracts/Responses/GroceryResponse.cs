using Shared.Models;

namespace Shared.Contracts.Responses;

public class GroceryResponse {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public FoodTypes Category { get; set; }
}