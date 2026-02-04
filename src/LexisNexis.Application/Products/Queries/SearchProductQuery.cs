namespace LexisNexis.Application.Products.Queries;

public class SearchProductQuery
{
    public string SearchTerm { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Guid CategoryId { get; set; }
}