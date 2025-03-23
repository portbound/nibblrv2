namespace Shared.Models;

public class Grocery {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public FoodTypes Category { get; set; }
}

public enum FoodTypes {
    Produce,
    Protein,
    Grocery,
    Dairy,
    Misc
}