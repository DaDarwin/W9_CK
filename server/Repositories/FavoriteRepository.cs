namespace W9_CK.Repositories;

public class FavoriteRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal FavoriteRecipe CreateFavorite(Favorite data)
    {
        string sql = @"
        INSERT INTO
        favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);
        
        SELECT
        recipe.*
        favorites.*
        from recipes
        JOIN favorites ON favorites.recipeId = recipes.id
        WHERE favorites.id = LAST_INSERT_ID();";
        return db.Query<FavoriteRecipe, Favorite, FavoriteRecipe>(sql, (recipe, favorite) =>
        {
            recipe.FavoriteId = favorite.Id;
            return recipe;
        },
        data).FirstOrDefault();
    }

    internal void DeleteFavorite(int id)
    {
        string sql = @"
        DELETE FROM
        favorites
        WHERE favorites.id = @id;";
        db.Query(sql, new { id });
    }

    internal Favorite GetFavorite(int id)
    {
        string sql = @"
        SELECT
        *
        FROM favorites
        WHERE favorites.id = @id;";
        return db.Query<Favorite>(sql, new { id }).FirstOrDefault();
    }
}