using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangFire.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IBackgroundJobClient _backgroundJobs;

        public HomeController(IBackgroundJobClient backgroundJobs) => 
            _backgroundJobs = backgroundJobs;

        [HttpGet]
        public IActionResult Index()
        {
            _backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
            return Ok(_backgroundJobs);
        }
    }
}
