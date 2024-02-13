namespace W9_CK.Models;

public class Recipe : RepoUserContent<int>
{
    public string Title { get; set; }
    public string Instructions { get; set; }
    public string Img { get; set; }
    public string Category { get; set; }
}

public class FavoriteRecipe : Recipe
{
    public int FavoriteId { get; set; }
}
