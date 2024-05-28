
namespace WebApi.Domains.Entities.Common;

public abstract class AuditableBaseEntity<TId> : BaseEntity<TId>, IAuditableBaseEntity
{
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedIn { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedIn { get; set; }

    protected AuditableBaseEntity() { }

    protected AuditableBaseEntity(TId id) : base(id) { }
}
