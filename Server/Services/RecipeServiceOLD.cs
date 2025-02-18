// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Nibblr;
// using Nibblr.DTOs;
// using Server.Data;
// using Server.Services.Logging;
//
// namespace Server.Services;
//
// public class RecipeServiceOLD : IRecipeService {
//     private readonly Logger logger = Logger.Default;
//     private readonly ApplicationDbContext _db;
//
//     public RecipeServiceOLD() {
//         
//     }
//     public RecipeServiceOLD(ApplicationDbContext db) {
//         _db = db;
//     }
//
//     public async Task<IResult> Get(string? categoryName = null, string? recipeName = null) { 
//         IQueryable<RecipeRequest> query = _db.Recipes.AsQueryable()
//             .Select(recipe => new RecipeRequest {
//                 Name = recipe.Name,
//                 Category = new CategoryRequest {
//                     Name = recipe.Category.Name,
//                 },
//                 Description = recipe.Description,
//                 URL = recipe.URL,
//                 Ingredients = recipe.Ingredients.Select(ingredient => 
//                     new IngredientsRequest {
//                         Name = ingredient.Name,
//                         Quantity = ingredient.Quantity,
//                         Weight = ingredient.Weight,
//                         WeightUnit = ingredient.WeightUnit,
//                         Description = ingredient.Description
//                     }
//                 ),
//                 Instructions = recipe.Instructions.Select(instructions => 
//                     new InstructionsRequest {
//                         Step = instructions.Step,
//                         Body = instructions.Body,
//                     }
//                 ),
//                 Macros = new MacrosRequest {
//                     Calories = recipe.Macros.Calories,
//                     Carbs = recipe.Macros.Carbs,
//                     Fat = recipe.Macros.Fat,
//                     Protein = recipe.Macros.Protein,
//                 }
//             });
//         
//         List<RecipeRequest>? recipes;
//
//         if (!string.IsNullOrEmpty(categoryName)) {
//             query = query.Where(x => x.Category.Name.Contains(categoryName));
//             recipes = await query.ToListAsync();
//
//             return recipes.Count > 0 
//                 ? Results.Ok(recipes) 
//                 : Results.NotFound();
//         }
//
//         if (recipeName != null) {
//             query = query.Where(x => x.Name.ToLower().Contains(recipeName.ToLower())); // ordinalignorecase not working here -- throwing 500 error we should look into since it's a better comparison but this does work with "ToLower()"
//            
//             recipes = await query.ToListAsync();
//
//             if (recipes.Count <= 0) {
//                 return Results.NotFound();
//             }
//             
//             return recipes.Count > 1 
//                 ? Results.Ok(recipes)
//                 : Results.Ok(recipes[0]); // returning the first item instead of the whole list structure since we'd need to massage this on the frontend anyway 
//         }
//         
//         recipes = await query.ToListAsync();
//         
//         return recipes.Count > 0
//             ? Results.Ok(recipes)
//             : Results.NotFound();
//     }
// }
