namespace W9_CK.Models;

public abstract class RepoItem<T>
{
    public T Id { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }


}

public abstract class RepoUserContent<T> : RepoItem<T>
{
    public string CreatorId { get; set; }

    public Profile Creator { get; set; }
}