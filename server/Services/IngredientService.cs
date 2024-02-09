
namespace W9_CK.Services;

public class IngredientService(IngredientRepository repo, RecipeService recipeService)
{
    private readonly IngredientRepository repo = repo;
    private readonly RecipeService recipeService = recipeService;


    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
        return repo.GetRecipeIngredients(recipeId);
    }

    internal Ingredient CreateIngredient(Ingredient data, string userId)
    {
        Recipe recipe = recipeService.GetRecipe(data.RecipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception("Na");
        }
        return repo.CreateIngredient(data);
    }

    internal IngredientCreator GetIngredient(int id)
    {
        return repo.GetIngredient(id) ?? throw new Exception($"No Ingredient with Id: {id}");
    }

    internal string DeleteIngredient(int id, Account user)
    {
        IngredientCreator ingredient = this.GetIngredient(id);
        if (ingredient.CreatorId != user.Id)
        {
            throw new Exception("Na");
        }
        repo.DeleteIngredient(id);
        return $"Deleted Ingredient {id}";
    }

}