using CleanArchitecture.Domain.Entities.Common;

namespace CleanArchitecture.Domain.Entities;

public class Category : BaseEntity<Guid>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public ICollection<Product>? Products { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}