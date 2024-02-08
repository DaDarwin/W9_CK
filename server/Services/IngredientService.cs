
namespace W9_CK.Services;

public class IngredientService(IngredientRepository repo)
{
    private readonly IngredientRepository repo = repo;

    internal List<Ingredient> GetRecipeIngredients(int recipeID)
    {
        return repo.GetRecipeIngredients(recipeID);
    }

    internal Ingredient CreateIngredient(Ingredient data)
    {
        return repo.CreateIngredient(data);
    }

    internal IngredientCreator GetIngredient(int id)
    {
        return repo.getIngredient(id) ?? throw new Exception($"No Ingredient with Id: {id}");
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