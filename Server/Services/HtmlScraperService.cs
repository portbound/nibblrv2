using HtmlAgilityPack;

namespace Server.Services;

public static class HtmlScraperService {
    public static string? URL { get; set; }
    public static string? Name { get; set; }
    public static string? Ingredients { get; set; } 
    public static string? Instructions { get; set; }
    public static string? Nutrition { get; set; } 
    
    public static string GetRecipe(string url) {
        HtmlDocument? document = ParseUrl(url);
        URL = url;
        Name = ParseNodes(document.DocumentNode.SelectNodes("//div[contains(@class, 'title')]"));
        Ingredients = ParseNodes(document.DocumentNode.SelectNodes("//div[contains(@class, 'ingredients')]"));
        Instructions = ParseNodes(document.DocumentNode.SelectNodes("//div[contains(@class, 'instructions')]"));
        Nutrition = ParseNodes(document.DocumentNode.SelectNodes("//div[contains(@class, 'nutrition')]"));
        return string.Join(" ", URL, Name, Ingredients, Instructions, Nutrition);
    }
    
    private static HtmlDocument? ParseUrl(string url) {
        HtmlWeb web = new HtmlWeb();
        return web.Load(url);
    }

    private static string ParseNodes(HtmlNodeCollection? nodes) {
        return nodes != null 
            ? string.Join("", nodes.Select(node => node.InnerHtml)) 
            : string.Empty;
    }
}