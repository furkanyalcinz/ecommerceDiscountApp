using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Timers;
using Timer = System.Timers.Timer;
using Business.Abstact;
using System.ComponentModel;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountTimerController:ControllerBase
    {
        private Timer _timer;

        public DiscountTimerController()
        {
            _timer = new Timer(TimeSpan.FromSeconds(60));
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
            _timer.AutoReset = false;
            _timer.Start();
            _timer.Start();
        }
        private async void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            using (DiscountContext context= new DiscountContext())
            {
                var discounts = await context.Discounts.AsQueryable().ToListAsync();
                foreach (var discount in discounts)
                {
                    var products = await context.Products.Where(x=> x.CategoryId == discount.CategoryId).AsQueryable().ToListAsync();
                    DateTime currentTime = DateTime.UtcNow;
                    if (discount.StartDate < currentTime && discount.EndDate > currentTime)
                    {
                        discount.IsActive = true;
                        
                        foreach (var product in products)
                        {
                            var discountprice = product.Price * discount.Rate;
                            product.SellingPrice = product.Price - discountprice;
                            
                        }
                    }
                    if (discount.EndDate < currentTime)
                    {
                        discount.IsActive = false;
                        
                        foreach (var product in products)
                        {
                            product.SellingPrice = product.Price;
                            
                        }

                    }
                }
                await context.SaveChangesAsync();
            }
        }
       

        [HttpGet]
        public IActionResult StartTimer()
        {
            return Ok();
        }

    }
}
