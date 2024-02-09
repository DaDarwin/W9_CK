namespace W9_CK.Controllers;

[ApiController]
[Route("/api/recipes")]
public class RecipesController(Auth0Provider auth, RecipeService recipeService, IngredientService ingredientService) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly RecipeService recipeService = recipeService;
    private readonly IngredientService ingredientService = ingredientService;


    [HttpGet]
    public ActionResult<List<Recipe>> GetRecipes()
    {
        try
        {
            List<Recipe> recipes = recipeService.GetRecipes();
            return Ok(recipes);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetRecipe(int id)
    {
        try
        {
            Recipe recipe = recipeService.GetRecipe(id);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }

    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe data)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = userInfo.Id;
            Recipe recipe = recipeService.CreateRecipe(data);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> EditRecipe([FromBody] Recipe data, int id)

    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = userInfo.Id;
            data.Id = id;
            Recipe recipe = recipeService.EditRecipe(data);
            return recipe;
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<String>> DeleteRecipe(int id)
    {
        Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
        return recipeService.DeleteRecipe(id, userInfo.Id);

    }

    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetRecipeIngredients(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = ingredientService.GetRecipeIngredients(recipeId);
            return Ok(ingredients);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
};