using LexisNexis.Application.DTOs;
using LexisNexis.Application.Repositories;
using LexisNexis.Domain.Entities;

namespace LexisNexis.Application.Categories.Queries;

public class GetCategoryHierarchyTreeHandler
{
    private readonly ICategoryRepository _categoryRepository;
    
    public GetCategoryHierarchyTreeHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IEnumerable<CategoryTreeDto> Handle()
    {
        var categories = _categoryRepository.GetAll();
        
        return BuildTree(categories, null);
    }

    private IEnumerable<CategoryTreeDto> BuildTree(IEnumerable<Category> categories, Guid? parentId)
    {
        return categories
            .Where(c => c.ParentCategoryId == parentId)
            .Select(c => new CategoryTreeDto (c.Id, c.Name, c.Description, parentId, (BuildTree(categories, c.Id))))
            .ToList();
    }
}