namespace LexisNexis.Application.Products.Commands;

public class CreateProductCommand
{
    public string Name { get; set; }  
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public decimal UnitPrice { get; set; }
    public string SKU { get; set; }
}