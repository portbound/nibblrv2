using Shared.Models;

namespace Shared.Contracts.Requests;

public class CreateRecipeRequest {
    public required string Name { get; init; }
    public required string? Description { get; init; }
    public required string Category { get; init; }
    public required string? URL { get; init; }
    public required int Servings { get; init; }
    public required int Calories { get; init; }
    public required double Fat { get; init; }
    public required double Carbs { get; init; }
    public required double Protein { get; init; }
    public required string? IngredientsJson { get; init; }
    public required string? InstructionsJson { get; init; }
    public required bool Bookmarked { get; init; } = false;
}