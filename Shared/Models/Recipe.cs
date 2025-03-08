namespace Shared.Models;

public class Recipe {
    public int ID { get; init; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? URL { get; set; }
    public int Servings { get; set; }
    public int Calories { get; set; }
    public double Fat { get; set; }
    public double Carbs { get; set; }
    public double Protein { get; set; }
    public ICollection<Tag> Tags { get; set; } = [];
    public ICollection<Ingredients> Ingredients { get; set; } = [];
    public ICollection<Instructions> Instructions { get; set; } = [];
    
    public bool Bookmarked { get; set; } = false;
}

