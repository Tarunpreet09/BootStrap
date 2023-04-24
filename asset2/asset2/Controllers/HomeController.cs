using asset2.Models;
using Microsoft.AspNetCore.Mvc;


namespace asset2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

       

       
        public IActionResult Save1(social s)
        {
            //List<social> s1=new List<social>();
            return View(s);
        }
    }
}