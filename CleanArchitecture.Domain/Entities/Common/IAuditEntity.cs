namespace CleanArchitecture.Domain.Entities.Common;

public interface IAuditEntity
{
    DateTime CreatedDate { get; set; }
    DateTime? UpdatedDate { get; set; }
}