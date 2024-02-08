

namespace W9_CK.Services;

public class RecipeService(RecipeRepository repo)
{
    private readonly RecipeRepository repo = repo;

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = repo.GetRecipes();
        return recipes;
    }

    internal Recipe GetRecipe(int id)
    {
        Recipe recipe = repo.GetRecipe(id) ?? throw new Exception($"No Recipe at id: {id}");
        return recipe;
    }

    internal Recipe CreateRecipe(Recipe data)
    {
        Recipe recipe = repo.CreateRecipe(data);
        return recipe;

    }

    internal Recipe EditRecipe(Recipe data)
    {
        Recipe recipe = this.GetRecipe(data.Id);
        if (recipe.CreatorId != data.CreatorId)
        {
            throw new Exception("Na");
        }
        recipe.Title = data.Title ?? recipe.Title;
        recipe.Img = data.Img ?? recipe.Img;
        recipe.Category = data.Category ?? recipe.Category;
        recipe.Instructions = data.Instructions ?? recipe.Instructions;
        Console.WriteLine(recipe.Instructions);
        Console.WriteLine(data.Instructions);
        return repo.EditRecipe(recipe);
    }

    internal ActionResult<String> DeleteRecipe(int id, string userId)
    {
        Recipe recipe = this.GetRecipe(id);
        if (recipe.CreatorId != userId)
        {
            throw new Exception("Na");
        }
        repo.DeleteRecipe(id);
        return $"Recipe {id} Deleted";
    }
}