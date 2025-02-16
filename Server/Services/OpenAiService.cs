using System.Text.Json;
using Nibblr;
using OpenAI.Chat;

namespace Server.Services;

public class OpenAiService {
    private readonly ChatClient _client;
    private const string? ChatModel = "gpt-4o";
    private const float temperature = (float)0.3;

    public OpenAiService(IConfiguration config) {
        string? apiKey = config["OpenAI:ApiKey"] ?? throw new ArgumentNullException(nameof(config));
        _client = new ChatClient(ChatModel, apiKey);
    }
    

    public async Task<Recipe> ExtractRecipe(string url) {
        const string systemMessage = "Extract recipe details from HTML content. If there are no nutrition facts available in the HTML, use USDA database for nutrition calculations instead.";
        string content = HtmlScraperService.GetRecipe(url);
        return await GetRecipe(systemMessage, content);
    }
    public async Task<Recipe> CreateRecipe(List<string> ingredients) {
        const string systemMessage = "Create a recipe using these ingredients. If there are no nutrition facts available in the HTML, use USDA database for nutrition calculations instead.";
        string content = string.Join(",", ingredients);
        return await GetRecipe(systemMessage, content);
    }
    private  async Task<Recipe> GetRecipe(string systemMessage, string content) {
        List<ChatMessage> prompt = [
            new SystemChatMessage(systemMessage),
            new UserChatMessage(content)

        ];
        ChatCompletionOptions options = new() {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                jsonSchemaFormatName: "recipe",
                jsonSchema: GetRecipeSchema(),
                jsonSchemaIsStrict: false),
            Temperature = temperature
        };
        
        ChatCompletion completion = await _client.CompleteChatAsync(prompt, options);
        string response = completion.Content[0].Text;
        Console.WriteLine(response);
    
        Recipe recipe = JsonSerializer.Deserialize<Recipe>(response)!;
        return recipe;
    }
    private static BinaryData GetRecipeSchema() {
        return BinaryData.FromString(
            """
                {
                  "type": "object",
                  "properties": {
                      "Name": {
                          "type": "string"
                      },
                      "Description": {
                          "type": "string"
                      },
                      "Ingredients": {
                          "type": "array",
                          "items": { "type": "string" }
                      },
                      "Instructions": {
                          "type": "array", 
                          "items": { "type": "string" }
                      },
                      "Nutrition": {
                          "type": "array",
                          "items": { "type": "string" }
                      }
                  }
                }
            """);
    }
}