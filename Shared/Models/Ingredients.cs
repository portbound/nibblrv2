namespace Nibblr;

public class Ingredients {
    public int ID { get; set; }
    public string Name { get; set; }
    public double? Quantity { get; set; }
    public double? Weight { get; set; }
    public string? WeightUnit { get; set; }
    public string? Description { get; set; }

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}