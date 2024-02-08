namespace W9_CK.Repositories;

public class RecipeRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    public List<Recipe> GetRecipes()
    {
        string sql = @"
            SELECT recipes.*, 
            accounts.id, name, picture
            FROM recipes
            JOIN accounts ON accounts.id = recipes.creatorId;";
        List<Recipe> recipes = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();

        return recipes;
    }

    public Recipe GetRecipe(int id)
    {
        string sql = @"
        SELECT 
            *
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @id;";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        },
            new { id }
        ).FirstOrDefault();
        if (recipe == null)
        {
            throw new Exception($"No Recipe with Id: {id}");
        }
        return recipe;
    }

    public Recipe CreateRecipe(Recipe data)
    {
        string sql = @"
            INSERT INTO recipes 
            (title, instructions, img, category, creatorId)
            VALUES 
            (@title, @instructions, @img, @category, @creatorId);

            SELECT 
                recipes.*,
                accounts.*
            FROM recipes
            JOIN accounts ON recipes.creatorId = accounts.id 
            WHERE recipes.id = LAST_INSERT_ID();";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        },
        data
        ).FirstOrDefault();

        return recipe;

    }

    internal Recipe EditRecipe(Recipe recipe)
    {
        string sql = @"
        UPDATE recipes SET
        title = @title,
        img = @img,
        category = @category,
        instructions = @instructions
        WHERE id = @id;
        
        SELECT 
            *
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @id;";
        return db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        },
        recipe
        ).FirstOrDefault();
    }

    internal void DeleteRecipe(int id)
    {
        string sql = @"
        DELETE FROM recipes
        WHERE id = @id;";
        db.Query(sql, new { id });
    }
}
