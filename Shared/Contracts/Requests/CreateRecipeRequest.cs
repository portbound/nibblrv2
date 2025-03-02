using Shared.Models;

namespace Shared.Contracts.Requests;

public class CreateRecipeRequest {
    public required string Name { get; set; }
    public required string? Description { get; set; }
    public required string Category { get; set; }
    public required string? URL { get; set; }
    public required int Servings { get; set; }
    public required int Calories { get; set; }
    public required double Fat { get; set; }
    public required double Carbs { get; set; }
    public required double Protein { get; set; }
    public required ICollection<Ingredients> Ingredients { get; set; } = [];
    public required ICollection<Instructions> Instructions { get; set; } = [];
    public required bool Bookmarked { get; set; } = false;
}