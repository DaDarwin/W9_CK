



namespace W9_CK.Repositories;

public class IngredientRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
        string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE recipeId = @recipeId;";
        return db.Query<Ingredient>(sql, new { recipeId }).ToList();
    }

    internal Ingredient CreateIngredient(Ingredient data)
    {
        string sql = @"
        INSERT INTO ingredients
        (name, quantity, recipeId)
        VALUES
        (@name, @quantity, @recipeId);
        SELECT
        *
        FROM ingredients
        WHERE ingredients.id = LAST_INSERT_ID();";
        return db.Query<Ingredient>(sql, data).FirstOrDefault();
    }

    public IngredientCreator getIngredient(int id)
    {
        string sql = @"
        Select
        ingredients.*,
        recipes.creatorId
        from ingredients
        JOIN recipes ON ingredient.recipeId = recipe.id
        WHERE ingredient.id = @id;";
        IngredientCreator ingredient = db.Query<IngredientCreator, Recipe, IngredientCreator>(sql, (ingredient, recipe) =>
        {
            ingredient.CreatorId = recipe.CreatorId;
            return ingredient;
        }, new { id }).FirstOrDefault();
        return ingredient;
    }

    internal void DeleteIngredient(int id)
    {
        string sql = @"
        DELETE FROM
        ingredients
        WHERE ingredients.id = @id;";
        db.Query(sql, new { id });
    }

}