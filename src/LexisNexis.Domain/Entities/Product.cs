namespace LexisNexis.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }  
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal UnitPrice { get; set; }
    public string SKU { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}