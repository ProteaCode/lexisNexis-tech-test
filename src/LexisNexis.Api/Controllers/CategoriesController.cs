using LexisNexis.Application.Categories.Commands;
using LexisNexis.Application.Categories.Queries;
using LexisNexis.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LexisNexis.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : Controller
{
    private readonly CreateCategoryHandler _createCategoryHandler;
    private readonly GetCategoryHierarchyTreeHandler _categoryHierarchyTreeHandler;
    
    public CategoriesController(GetCategoryHierarchyTreeHandler categoryHierarchyTreeHandler, CreateCategoryHandler createCategoryHandler)
    {
        _categoryHierarchyTreeHandler = categoryHierarchyTreeHandler;
        _createCategoryHandler = createCategoryHandler;
    }

    [HttpPost]
    public async Task<IActionResult> SaveCategory([FromBody] CategoryDto request)
    {
        var command = new CreateCategoryCommand()
        {
            Name = request.Name,
            Description = request.Description,
            ParentCategoryId = request.ParentCategoryId
        };
        
        await _createCategoryHandler.Handle(command);
        
        return Ok();
    }
    
    [HttpGet("tree")]
    public IActionResult GetCategoryHierarchy()
    {
         var result = _categoryHierarchyTreeHandler.Handle();
        
        return Ok(result);
    }
}