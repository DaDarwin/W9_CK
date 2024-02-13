namespace W9_CK.Models;

public class Ingredient : RepoItem<int>
{
    public string Name { get; set; }
    public string Quantity { get; set; }
    public int RecipeId { get; set; }
}

public class IngredientCreator : Ingredient
{
    public string CreatorId { get; set; }
}