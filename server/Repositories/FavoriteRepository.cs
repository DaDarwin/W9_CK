

namespace W9_CK.Repositories;

public class FavoriteRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal AccountFavorites CreateFavorite(Favorite data)
    {
        string sql = @"
        INSERT INTO
        favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);
        
        SELECT
        accounts.*,
        favorites.id
        FROM accounts
        JOIN favorites ON favorites.accountId = accounts.id
        WHERE favorites.id = LAST_INSERT_ID();";
        return db.Query<AccountFavorites, Favorite, AccountFavorites>(sql, (account, favorite) =>
        {
            account.FavoriteId = favorite.Id;
            return account;
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