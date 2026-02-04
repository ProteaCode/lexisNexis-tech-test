namespace LexisNexis.Application.DTOs;

public record CategoryDto (Guid Id,
string Name,
string Description,
string ParentCategoryId);

public record CategoryTreeDto(Guid Id,
    string Name,
    string Description,
    Guid? ParentCategoryId,
    IEnumerable<CategoryTreeDto> categories);