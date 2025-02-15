using System.Collections;
using System.Collections.Generic;

namespace Nibblr;

public class Recipe {
    public int ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? URL { get; set; }
    public ICollection<Ingredients> Ingredients { get; set; }
    public ICollection<Instructions> Instructions { get; set; }
    public Category Category { get; set; }
    public Macros Macros { get; set; }
}

