

namespace W9_CK.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name?.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture?.Length > 0 ? editData.Picture : original.Picture;
    original.Bio = editData.Bio?.Length > 0 ? editData.Bio : original.Bio;
    original.CoverImg = editData.CoverImg?.Length > 0 ? editData.CoverImg : original.CoverImg;
    original.GitHub = editData.GitHub?.Length > 0 ? editData.GitHub : original.GitHub;
    original.LinkedIn = editData.LinkedIn?.Length > 0 ? editData.LinkedIn : original.LinkedIn;
    original.Number = editData.Number?.Length > 0 ? editData.Number : original.Number;
    return _repo.Edit(original);
  }

  internal List<FavoriteRecipe> GetAccountFavorites(string id)
  {
    return _repo.GetAccountFavorites(id);
  }

}
