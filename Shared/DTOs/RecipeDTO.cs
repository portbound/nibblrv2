namespace Shared.DTOs;

public class RecipeDTO {
    public int ID { get; set; }
    public string Name { get; set; }
    public CategoryDTO Category { get; set; }
    public string? Description { get; set; }
    public string? URL { get; set; }
    public IEnumerable<IngredientsDTO> Ingredients { get; set; }
    public IEnumerable<InstructionsDTO> Instructions { get; set; }
    public MacrosDTO Macros { get; set; }
    public bool Bookmarked { get; set; } = false;
}