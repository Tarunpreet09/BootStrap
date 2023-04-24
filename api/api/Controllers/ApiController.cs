using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult index()
        {
            
            return View();
        }
    }
}
