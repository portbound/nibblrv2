namespace Shared.Models;

public class Recipe {
    public int ID { get; init; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Category { get; set; }
    public string? URL { get; set; }
    

    public int Servings { get; set; }
    public int Calories { get; set; }
    public double Fat { get; set; }
    public double Carbs { get; set; }
    public double Protein { get; set; }
    
    public string IngredientsJson { get; set; } = string.Empty;
    public string InstructionsJson { get; set; } = string.Empty;
    
    public bool Bookmarked { get; set; } = false;
}

