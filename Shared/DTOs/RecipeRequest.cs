namespace Nibblr.DTOs;

public class RecipeRequest {
    public string Name { get; set; }
    public CategoryRequest Category { get; set; }
    public string? Description { get; set; }
    public string? URL { get; set; }
    public IEnumerable<IngredientsRequest> Ingredients { get; set; }
    public IEnumerable<InstructionsRequest> Instructions { get; set; }
    public MacrosRequest Macros { get; set; }
}