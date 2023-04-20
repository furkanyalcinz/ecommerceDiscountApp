using Business.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("/AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDTO _product)
        {
            var product = new Product();
            product.ProductName = _product.ProductName;
            product.Price = _product.Price;
            product.SellingPrice = _product.Price;
            product.Stock = _product.Stock;
            product.CategoryId = _product.CategoryId;
            

            var result = await _productService.AddProduct(product);
            return Ok(result);
        }
        [HttpGet("/GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }
    }
}
