namespace LexisNexis.Application.Categories.Commands;

public class CreateCategoryCommand
{
    public string Name { get; set; }  
    public string Description { get; set; }
    public string? ParentCategoryId { get; set; }
}