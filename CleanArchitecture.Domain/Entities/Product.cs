using CleanArchitecture.Domain.Entities.Common;

namespace CleanArchitecture.Domain.Entities;

public class Product : BaseEntity<Guid>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}