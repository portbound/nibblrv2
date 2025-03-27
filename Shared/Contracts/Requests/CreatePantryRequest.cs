using Shared.Models;

namespace Shared.Contracts.Requests;

public class CreatePantryRequest {
    public string Name {get; set;}
    public FoodTypes Category {get; set;}
    public int Usage { get; set; } = 0;
}