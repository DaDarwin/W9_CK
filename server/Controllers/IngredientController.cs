namespace W9_CK.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientController(Auth0Provider auth, IngredientService ingredientService) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly IngredientService ingredientService = ingredientService;

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient data)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            Ingredient ingredient = ingredientService.CreateIngredient(data, user.Id);
            return Ok(ingredient);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredient(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            string res = ingredientService.DeleteIngredient(id, user);
            return Ok(res);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
