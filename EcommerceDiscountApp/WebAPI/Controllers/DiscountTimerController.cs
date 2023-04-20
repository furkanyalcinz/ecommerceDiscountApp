using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Timers;
using System.IO;
using Timer = System.Timers.Timer;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountTimerController:ControllerBase
    {
        string dosyaAdi = "ornek.txt";
        string dosyaYolu = @"C:\Users\furka\Desktop\";
        private Timer _timer;
        public DiscountTimerController()
        {
            _timer = new Timer(TimeSpan.FromSeconds(2));
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
            _timer.AutoReset = true;
            _timer.Start();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(dosyaYolu + dosyaAdi, true))
            {
                // Satırı dosyaya yazın
                sw.WriteLine(DateTime.Now);
            }
        }

        [HttpGet]
        public IActionResult StartTimer()
        {
            return Ok();
        }

    }
}
