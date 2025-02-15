namespace Nibblr;

public class Instructions {
    public int ID { get; set; }
    public int Step { get; set; }
    public string Body { get; set; }
    
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
}