using Microsoft.AspNetCore.Mvc;

namespace ItemManagement.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
        }

        [HttpGet("")]
        public IActionResult Get() => Content("ItemManagement " + _configuration["APP_VERSION"]  + " is working!");
    }
}