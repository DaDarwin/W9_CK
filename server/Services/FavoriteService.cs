
namespace W9_CK.Services;

public class FavoriteService(FavoriteRepository repo)
{
    private readonly FavoriteRepository repo = repo;

    internal ActionResult<AccountFavorites> CreateFavorite(Favorite data)
    {
        return repo.CreateFavorite(data);
    }

    internal Favorite GetFavorite(int id)
    {
        return repo.GetFavorite(id) ?? throw new Exception($"No Favorite With Id: {id}");
    }

    internal string DeleteFavorite(int id, string userId)
    {
        Favorite favorite = this.GetFavorite(id);
        if (favorite.AccountId != userId)
        {
            throw new Exception("Na");
        }
        repo.DeleteFavorite(id);
        return $"Favorite with ID: {id} Deleted";
    }
}