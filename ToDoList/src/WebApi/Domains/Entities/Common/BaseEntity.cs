namespace WebApi.Domains.Entities.Common;

public abstract class BaseEntity<TId>
{
    public TId Id { get; private set; }

    protected BaseEntity()
    {

    }

    protected BaseEntity(TId id)
    {
        Id = id;
    }
}
