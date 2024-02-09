namespace W9_CK.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(AccountService accountService, Auth0Provider auth0Provider) : ControllerBase
{
  private readonly AccountService _accountService = accountService;
  private readonly Auth0Provider _auth0Provider = auth0Provider;

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("/favorites")]
  [Authorize]
  public async Task<ActionResult<List<FavoriteRecipe>>> GetAccountFavorites()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetAccountFavorites(userInfo.Id));
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
