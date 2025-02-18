namespace Shared.Models;

public class Category {
    public int ID { get; set; }
    public string Name { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}