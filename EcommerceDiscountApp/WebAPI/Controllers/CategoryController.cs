using Business.Abstact;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("/AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryDTO categoryDTO)
        {
            var result = await _categoryService.AddCategory(categoryDTO);
            return Ok(result);
        }
        [HttpPut("/UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var result = await _categoryService.UpdateCategory(category);
            return Ok(result);
        }
        [HttpGet("/GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(_categoryService.GetAllCategories());
        }
    }
}
