namespace Shared.Models;

public class Ingredients {
    public int ID { get; init; }
    public int RecipeID { get; init; }
    public double? Quantity { get; set; }
    public double? Weight { get; set; }
    public string? WeightUnit { get; set; }
    public string Name { get; set; }
    public string? Notes { get; set; }
}