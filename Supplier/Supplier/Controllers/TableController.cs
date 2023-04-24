using Microsoft.AspNetCore.Mvc;
using Supplier.Models;
using System.Diagnostics;

namespace Supplier.Controllers
{
    public class TableController : Controller
    {
        public IActionResult tabledata()
        {
            return View();
        }
    }
}
