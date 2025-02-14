namespace Nibblr;

public class Macros {
    public int ID { get; set; }
    public int Calories { get; set; }
    public double Fat { get; set; }
    public double Carbs { get; set; }
    public double Protein { get; set; } 
    
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}