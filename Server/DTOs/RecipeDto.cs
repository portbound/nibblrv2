namespace Nibblr.DTOs;

public class RecipeDto {
    public int ID { get; set; }
    public string Name { get; set; }
    public CategoryDto Category { get; set; }
    public string Description { get; set; }
    public IEnumerable<IngredientsDto> Ingredients { get; set; }
    public IEnumerable<InstructionsDto> Instructions { get; set; }
    public MacrosDto Macros { get; set; }
}