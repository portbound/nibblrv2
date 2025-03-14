namespace Shared.Models;

public class Ingredients {
    public int ID { get; init; }
    public int RecipeID { get; init; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    public string Name { get; set; }
    public string? Notes { get; set; }
}

