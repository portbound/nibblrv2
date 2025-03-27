namespace Shared.Models;

public class Pantry {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public FoodTypes Category { get; set; }
    public int Usage { get; set; } = 0;
}