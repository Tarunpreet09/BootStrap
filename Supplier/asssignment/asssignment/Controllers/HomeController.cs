using asssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace asssignment.Controllers
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

        public IActionResult data()
        {
            return View();
        }
     
        public JsonResult data1(students ss)
        {
            
            List<students> student = new List<students>();
            Guid guid = Guid.NewGuid();
            ss.Guid = guid;

            if (HttpContext.Session.Get<List<students>>("Name") != null)
            {
                student = HttpContext.Session.Get<List<students>>("Name");
                student.Add(ss);
                HttpContext.Session.Set<List<students>>("Name", student);
            }
            else
            {
                student.Add(ss);
                HttpContext.Session.Set<List<students>>("Name", student);
            }
            return Json(student);
        }

        public JsonResult Del(string Guid)
        {
            List<students> update = HttpContext.Session.Get<List<students>>("Name");
            var res = update.Find(x => Convert.ToString(x.Guid) == Guid);
            update.Remove(res);

            HttpContext.Session.Set<List<students>>("Name", update);
            return Json(update);
        }

        public JsonResult Edit1(string ID, students first)
        {
            List<students> student = HttpContext.Session.Get<List<students>>("Name");
            var res = student.Find(x => Convert.ToString(x.Guid) == ID);
            res.Subject = first.Subject;
            res.Marks = first.Marks;
            HttpContext.Session.Set<List<students>>("Name", student);
            return Json(student);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}