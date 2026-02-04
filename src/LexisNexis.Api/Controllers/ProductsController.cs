using LexisNexis.Application.Products.Commands;
using LexisNexis.Application.Products.Queries;
using LexisNexis.Application.DTOs;
using LexisNexis.Application.Products.Validation;
using Microsoft.AspNetCore.Mvc;

namespace LexisNexis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // Could use mediatr
        //
        private readonly CreateProductHandler _createProductHandler;
        private readonly UpdateProductHandler _updateProductHandler;
        private readonly GetProductByIdHandler _getProductByIdHandler;
        private readonly DeleteProductHandler _deleteProductHandler;
        private readonly SearchProductHandler _searchProductHandler;

        public ProductsController(CreateProductHandler createProductHandler,
            GetProductByIdHandler getProductByIdHandler, 
            UpdateProductHandler updateProductHandler, 
            DeleteProductHandler deleteProductHandler, 
            SearchProductHandler searchProductHandler)
        {
            _createProductHandler = createProductHandler;
            _getProductByIdHandler = getProductByIdHandler;
            _updateProductHandler = updateProductHandler;
            _deleteProductHandler = deleteProductHandler;
            _searchProductHandler = searchProductHandler;
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody] ProductDto request)
        {
            var command = new CreateProductCommand
            {
                Name =  request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                UnitPrice =  request.UnitPrice,
                SKU =  request.SKU
            };
            
            (var isSuccess, var message) = ProductValidator.ValidateCreate(command);

            if (!isSuccess)
                return BadRequest(message);
            
             await _createProductHandler.Handle(command);
             
             return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            return Ok(_getProductByIdHandler.Handle(new GetProductByIdQuery { Id = id }));
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] ProductDto request)
        {
            var command = new UpdateProductCommand()
            {
                Id = request.Id,
                Name =  request.Name,
                Description = request.Description,
                CategoryId = request.CategoryId,
                UnitPrice =  request.UnitPrice,
                SKU =  request.SKU
            }; 
            
            return Ok(_updateProductHandler.Handle(command));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _deleteProductHandler.Handle(new DeleteProductCommand() {  Id = id });

            return Ok();
        }
        
        [HttpGet]
        public IActionResult SearchProducts(SearchProductQuery request)
        {
            (var isSuccess, var message) = ProductValidator.ValidateSearch(request);

            if (!isSuccess)
                return BadRequest(message);
            
            var result =  _searchProductHandler.Handle(request);
            
            return Ok(result);
        }
    }
}
