using System.Collections;
using System.Collections.Generic;

namespace Nibblr;

public class Recipe {
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? URL { get; set; }
    public List<string> Ingredients { get; set; } = [];
    public List<string>? Instructions { get; set; } = [];
    public List<string>? Nutrition { get; set; } = [];
}