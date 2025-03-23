namespace Shared.Models;

public class Instructions {
    public Guid ID { get; init; }
    public Guid RecipeID { get; init; }
    public int Step { get; set; }
    public string Body { get; set; }
}