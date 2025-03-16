namespace Shared.Models;

public class Tag {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();}