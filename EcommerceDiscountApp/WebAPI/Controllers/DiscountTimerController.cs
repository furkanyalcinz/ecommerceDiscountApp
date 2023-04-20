using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Timers;
using Timer = System.Timers.Timer;
using Business.Abstact;
using System.ComponentModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountTimerController:ControllerBase
    {
        private Timer _timer;
        private IDiscountService _discountService;

        public DiscountTimerController(IDiscountService discountService)
        {
            _discountService = discountService;
            _timer = new Timer(TimeSpan.FromSeconds(60));
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
            _timer.AutoReset = false;
            _timer.Start();
            _timer.Start();
        }
        private async void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            await _discountService.ApplayDiscounts();
        }
       

        [HttpGet]
        public IActionResult StartTimer()
        {
            return Ok();
        }

    }
}
