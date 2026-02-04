namespace LexisNexis.Application.DTOs
{
    public record ProductDto(Guid Id,
        string Name,
        string Description,
        Guid CategoryId,
        decimal UnitPrice,
        string SKU,
        DateTime CreatedAt,
        DateTime UpdatedAt);
}
