using WebApi.Services;

namespace WebApi.Domains.Entities.Common;

public interface IAuditableBaseEntity
{
    string CreatedBy { get; set; }
    DateTimeOffset CreatedIn { get; set; }
    string? LastModifiedBy { get; set; }
    DateTimeOffset? LastModifiedIn { get; set; }
}
