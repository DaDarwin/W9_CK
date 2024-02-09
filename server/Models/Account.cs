namespace W9_CK.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
}

public class AccountFavorites : Account
{
  public int FavoriteId { get; set; }
}
