namespace Shared.Contracts.Responses;

public class RecipesResponse {
    public IEnumerable<RecipeResponse> Items { get; set; } = [];
}