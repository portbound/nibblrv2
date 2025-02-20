using OpenAI.Chat;
using Shared.DTOs;

namespace Server.Services.Ai;

public class OpenAiService {
    private readonly ChatClient _client;
    private readonly string? key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
    private const string? ChatModel = "gpt-4o";
    private const float temperature = (float)0.3;
    
    public OpenAiService() {
        _client = new ChatClient(ChatModel, key);
    }
    
    public async Task<RecipeDTO> ExtractRecipe(string url) {
        const string systemMessage = "Extract recipe details from HTML content. If there are no nutrition facts available in the HTML, use USDA database for nutrition calculations instead.";
        string content = HtmlScraperService.GetRecipe(url);
        return await GetRecipe(systemMessage, content);
    }
    public async Task<RecipeDTO> CreateRecipe(string content) {
        const string systemMessage = "Create a recipe using these ingredients. Use the USDA database for approximate nutrition calculations based on the ingredients and their respective measurements.";
        return await GetRecipe(systemMessage, content);
    }
    private  async Task<RecipeDTO> GetRecipe(string systemMessage, string content) {
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
        
        RecipeDTO recipeDto = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipeDTO>(response)!;
        return recipeDto;
    }
    private static BinaryData GetRecipeSchema() {
        return BinaryData.FromString(
            """
                {
              "type": "object",
              "required": ["Name", "Category", "Ingredients", "Instructions", "Macros"],
              "properties": {
                "Name": {
                  "type": "string"
                },
                "Category": {
                  "type": "object",
                  "required": ["Name"],
                  "properties": {
                    "Name": {
                      "type": "string"
                    }
                  }
                },
                "Description": {
                  "type": "string"
                },
                "URL": {
                  "type": "string"
                },
                "Ingredients": {
                  "type": "array",
                  "items": {
                    "type": "object",
                    "required": ["Name"],
                    "properties": {
                      "Name": {
                        "type": "string"
                      },
                      "Quantity": {
                        "type": "number"
                      },
                      "Weight": {
                        "type": "number"
                      },
                      "WeightUnit": {
                        "type": "string"
                      },
                      "Description": {
                        "type": "string"
                      }
                    }
                  }
                },
                "Instructions": {
                  "type": "array",
                  "items": {
                    "type": "object",
                    "required": ["Step", "Body"],
                    "properties": {
                      "Step": {
                        "type": "integer"
                      },
                      "Body": {
                        "type": "string"
                      }
                    }
                  }
                },
                "Macros": {
                  "type": "object",
                  "required": ["Calories", "Fat", "Carbs", "Protein"],
                  "properties": {
                    "Calories": {
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
                    }
                  }
                }
              }
            }
            """);
    }
}