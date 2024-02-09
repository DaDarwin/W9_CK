namespace W9_CK.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoriteController(FavoriteService favoriteService, Auth0Provider auth) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly FavoriteService favoriteService = favoriteService;

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite data)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.AccountId = user.Id;
            return Ok(favoriteService.CreateFavorite(data));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteFavorite(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(favoriteService.DeleteFavorite(id, user.Id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}