namespace Shared.Models;

public class Grocery {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public FoodTypes Category { get; set; }
    public bool IsInCart { get; set; } = false;
}
