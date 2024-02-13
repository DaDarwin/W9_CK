namespace W9_CK.Models;

public class Favorite : RepoItem<int>
{
    public string AccountId { get; set; }
    public int RecipeId { get; set; }
}