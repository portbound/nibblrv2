using OpenAI.Chat;
using Server.Mapping;
using Server.Services.Ai;
using Shared.Contracts.Requests;
using Shared.Models;

namespace Server.Services;

public class OpenAiService {
    private readonly ChatClient _client;
    private readonly string? key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    private const string? ChatModel = "gpt-4o";
    private const float temperature = (float)0.3;
    
    public OpenAiService() {
        _client = new ChatClient(ChatModel, key);
    }
    
    public async Task<Recipe?> ExtractRecipe(string url) {
        const string systemMessage = "Extract recipe details from HTML content. If there are no nutrition facts available in the HTML, use USDA database for nutrition calculations instead.";
        string html = HtmlScraperService.GetRecipe(url);
        CreateRecipeRequest request = await GetRecipe(systemMessage, html);
        return request.MapToRecipe();
    }
    
    public async Task<Recipe?> CreateRecipe(string ingredients) {
        const string systemMessage = "Create a recipe using these ingredients. Use the USDA database for approximate nutrition calculations based on the ingredients and their respective measurements.";
        CreateRecipeRequest request = await GetRecipe(systemMessage, ingredients);
        return request.MapToRecipe();
    }
    
    private  async Task<CreateRecipeRequest> GetRecipe(string systemMessage, string content) {
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
        string body = completion.Content[0].Text;

        return Newtonsoft.Json.JsonConvert.DeserializeObject<CreateRecipeRequest>(body)!;
    }
    
    private static BinaryData GetRecipeSchema() {
        return BinaryData.FromString(
            """
            {
                "type": "object",
                "required": ["Name", "Description", "Category", "URL", "Servings", "Calories", "Carbs", "Fat", "Protein", "IngredientsJson", "InstructionsJson"],
                "properties": {
                    "Name": {
                      "type": "string"
                    },
                    "Description": {
                      "type": "string"
                    },
                    "Category": {
                      "type": "string"
                    },
                    "URL": {
                      "type": "string"
                    },
                    "Calories": {
                      "type": "integer"
                    },
                    "Servings": {
                      "type": "integer"
                    },
                    "Fat": {
                      "type": "number"
                    },
                    "Carbs": {
                      "type": "number"
                    },
                    "Protein": {
                      "type": "number"
                    },
                    "IngredientsJson": {
                      "type": "string",
                      "description": "JSON string of ingredients following the format: Quantity (weight weight units) Name (Description if applicable)"
                    },
                    "InstructionsJson": {
                      "type": "string",
                      "description": "JSON string of instructions following the format: Step number Body"
                    }
                }
            }
            """
        );
    }
}