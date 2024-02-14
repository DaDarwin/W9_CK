namespace W9_CK.Models;

public class Profile : RepoItem<string>
{
  public string Name { get; set; }
  public string Picture { get; set; }
  public string Bio { get; set; }
  public string CoverImg { get; set; }
  public string GitHub { get; set; }
  public string LinkedIn { get; set; }

}

public class Account : Profile
{
  public string Email { get; set; }
  public string Number { get; set; }
}

public class AccountFavorites : Profile
{
  public int FavoriteId { get; set; }
}
