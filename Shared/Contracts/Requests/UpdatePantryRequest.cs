using Shared.Models;

namespace Shared.Contracts.Requests;

public class UpdatePantryRequest {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public FoodTypes Category { get; set; }
    public int Usage { get; set; }
}