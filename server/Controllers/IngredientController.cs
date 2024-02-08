namespace W9_CK.Controllers;

[ApiController]
[Route("api/ingredients")]
public class IngredientController : ControllerBase
{
    private readonly Auth0Provider auth;
    private readonly IngredientService ingredientService;

    private readonly RecipeService recipeService;

    public IngredientController(Auth0Provider auth, IngredientService ingredientService, RecipeService recipeService)
    {
        this.auth = auth;
        this.ingredientService = ingredientService;
        this.recipeService = recipeService;
    }

    [HttpGet("{recipeID}")]
    public ActionResult<List<Ingredient>> GetRecipeIngredients(int recipeID)
    {
        try
        {
            List<Ingredient> ingredients = ingredientService.GetRecipeIngredients(recipeID);
            return Ok(ingredients);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient data)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            Recipe recipe = recipeService.GetRecipe(data.RecipeId);
            if (recipe.CreatorId != user.Id)
            {
                throw new Exception("Na");
            }
            Ingredient ingredient = ingredientService.CreateIngredient(data);
            return Ok(ingredient);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> DeleteIngredient(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            String res = ingredientService.DeleteIngredient(id, user);
            return Ok(res);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
