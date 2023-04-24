using Microsoft.AspNetCore.Mvc;


namespace Supplier.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Itemdata()
        {
            return View();
        }

        public IActionResult Itemdetail() 
        {
            return Itemdetail();
        }
    }
}
