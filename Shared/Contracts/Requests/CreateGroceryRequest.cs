using Shared.Models;

namespace Shared.Contracts.Requests;

public class CreateGroceryRequest {
    public string Name {get; set;}
    public FoodTypes Category {get; set;}
    public bool IsInCart { get; set; }
}