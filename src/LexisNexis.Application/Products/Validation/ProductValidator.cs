using LexisNexis.Application.Products.Commands;
using LexisNexis.Application.Products.Queries;

namespace LexisNexis.Application.Products.Validation;

public static class ProductValidator
{
    public static (bool, string) ValidateCreate(CreateProductCommand command)
        => command switch
        {
            null
                => (false, "Request cannot be null"),

            { Name: null or "" }
                => (false, "Product name is required"),

            { UnitPrice: <= 0 }
                => (false, "Unit price must be greater than zero"),

            { SKU: null or "" }
                => (false, "Product SKU is required"),

            _ => (true,  null)
        };
    
    public static (bool, string) ValidateSearch(SearchProductQuery command)
        => command switch
        {
            { SearchTerm: null or "" }
                => (false, "Search term is required"),

            _ => (true,  null)
        };
}