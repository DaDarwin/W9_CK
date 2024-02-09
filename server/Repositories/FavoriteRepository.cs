

namespace W9_CK.Repositories;

public class FavoriteRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal Favorite CreateFavorite(Favorite data)
    {
        string sql = @"
        INSERT INTO
        favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);
        
        SELECT
        favorites.*
        FROM favorites
        WHERE favorites.id = LAST_INSERT_ID();";
        return db.Query<Favorite>(sql,
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