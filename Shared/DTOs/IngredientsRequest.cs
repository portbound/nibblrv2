namespace Nibblr.DTOs;

public class IngredientsRequest {
    public string Name { get; set; }
    public double? Quantity { get; set; }
    public double? Weight { get; set; }
    public string? WeightUnit { get; set; }
    public string? Description { get; set; }
}