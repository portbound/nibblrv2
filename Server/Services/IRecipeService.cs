using Nibblr;

namespace Server.Services;

public interface IRecipeService {
    public Task<IResult> GetAllRecipes(); 
    void ValidateRecipe(Recipe recipe);
}