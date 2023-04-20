using Business.Abstact;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("/AddDiscount")]
        public async Task<IActionResult> AddDiscount(AddDiscountDTO discount)
        {
            return Ok(await _discountService.AddDiscount(discount));
        }
        [HttpGet("/GetDiscountsByCategory")]
        public async Task<IActionResult> GetDiscountsByCategoryId(uint category_id)
        {
            return Ok(_discountService.GetDiscountsByCategoryId(category_id));
        }
    }
}
