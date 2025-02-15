using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nibblr;
using Nibblr.DTOs;
using Server.Data;
using Server.Services.Logging;

namespace Server.Services;

public class RecipeService(ApplicationDbContext db) {
    private readonly Logger logger = Logger.Default;

    private readonly JsonSerializerOptions options = new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.Preserve
    };    
    
    [HttpGet]
    public async Task<IResult> Get(int? categoryId = null, int? recipeId = null) { 
        IQueryable<Recipe> query = db.Recipes.AsQueryable();

        List<RecipeDto>? recipes = [];

        if (categoryId != null) {
            query = query.Where(x => x.Category.ID == categoryId);
            recipes = await query
                .Include(recipe => recipe.Category)
                .Include(x => x.Ingredients)
                .Include(x => x.Instructions)
                .Include(x => x.Macros)
                .Select(recipe => new RecipeDto {
                    ID = recipe.ID,
                    Name = recipe.Name,
                    Category = new CategoryDto {
                        Name = recipe.Category.Name,
                    },
                    Description = recipe.Description ?? string.Empty,
                    Ingredients = recipe.Ingredients.Select(ingredient => 
                        new IngredientsDto {
                            Name = ingredient.Name,
                            Quantity = ingredient.Quantity,
                            Weight = ingredient.Weight,
                            WeightUnit = ingredient.WeightUnit,
                            Description = ingredient.Description
                        }
                    ),
                    Instructions = recipe.Instructions.Select(instructions => 
                        new InstructionsDto {
                            Step = instructions.Step,
                            Body = instructions.Body,
                        }
                    ),
                    Macros = new MacrosDto {
                        Calories = recipe.Macros.Calories,
                        Carbs = recipe.Macros.Carbs,
                        Fat = recipe.Macros.Fat,
                        Protein = recipe.Macros.Protein,
                    }
                })
                .ToListAsync();

            if (recipes.Count > 0) {
                return Results.Ok(recipes);
            }
        }

        if (recipeId != null) {
            query = query.Where(x => x.ID == recipeId);
            RecipeDto? recipe = await query
                .Include(x => x.Ingredients)
                .Include(x => x.Instructions)
                .Include(x => x.Macros)
                .Select(recipe => new RecipeDto {
                    ID = recipe.ID,
                    Name = recipe.Name,
                    Category = new CategoryDto {
                        Name = recipe.Category.Name,
                    },
                    Description = recipe.Description ?? string.Empty,
                    Ingredients = recipe.Ingredients.Select(ingredient => 
                        new IngredientsDto {
                            Name = ingredient.Name,
                            Quantity = ingredient.Quantity,
                            Weight = ingredient.Weight,
                            WeightUnit = ingredient.WeightUnit,
                            Description = ingredient.Description
                        }
                    ),
                    Instructions = recipe.Instructions.Select(instructions => 
                        new InstructionsDto {
                            Step = instructions.Step,
                            Body = instructions.Body,
                        }
                    ),
                    Macros = new MacrosDto {
                        Calories = recipe.Macros.Calories,
                        Carbs = recipe.Macros.Carbs,
                        Fat = recipe.Macros.Fat,
                        Protein = recipe.Macros.Protein,
                    }
                }).FirstOrDefaultAsync();

            if (recipe != null) {
                return Results.Ok(recipe);
            }
        }
        
        recipes = await query
            .Include(x => x.Ingredients)
            .Include(x => x.Instructions)
            .Include(x => x.Macros)
            .Select(recipe => new RecipeDto {
                ID = recipe.ID,
                Name = recipe.Name,
                Category = new CategoryDto {
                    Name = recipe.Category.Name
                },
                Description = recipe.Description ?? string.Empty,
                Ingredients = recipe.Ingredients.Select(ingredient => 
                    new IngredientsDto {
                        Name = ingredient.Name,
                        Quantity = ingredient.Quantity,
                        Weight = ingredient.Weight,
                        WeightUnit = ingredient.WeightUnit,
                        Description = ingredient.Description
                    }
                ),
                Instructions = recipe.Instructions.Select(instructions => 
                    new InstructionsDto {
                        Step = instructions.Step,
                        Body = instructions.Body,
                    }
                ),
                Macros = new MacrosDto {
                        Calories = recipe.Macros.Calories,
                        Carbs = recipe.Macros.Carbs,
                        Fat = recipe.Macros.Fat,
                        Protein = recipe.Macros.Protein,
                    }
            })
            .ToListAsync();
        
        if (recipes.Count <= 0) {
            return Results.NotFound();
        }
        
        return Results.Ok(recipes);
    }
}