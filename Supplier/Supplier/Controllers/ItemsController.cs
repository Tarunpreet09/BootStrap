using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supplier.Models;

namespace Supplier.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Item1()
        {
            return View();
        }

        public IActionResult red(string id)
        {
            Items gg = new Items();
            if (id != "0")
            {
                var students = HttpContext.Session.Get<List<Items>>("item");
                gg = students.Find(x => Convert.ToString(x.Gi) == id);

            }
            return View(gg);
        }
        public JsonResult Reload()
        {
            List<Items> gg = new List<Items>();
            gg = HttpContext.Session.Get<List<Items>>("item");
            return Json(gg);
        }

        public JsonResult View_Item(Items ss)
        {
            List<Items> student = new List<Items>();

            if (ss.Gi == null)
            {
                Guid guid = Guid.NewGuid();
                ss.Gi = guid;
                if (HttpContext.Session.Get<List<Items>>("item") != null)
                {
                    student = HttpContext.Session.Get<List<Items>>("item");
                    student.Add(ss);
                    HttpContext.Session.Set<List<Items>>("item", student);
                }
                else
                {
                    student.Add(ss);
                    HttpContext.Session.Set<List<Items>>("item", student);
                }
            }
            else
            {
                student = HttpContext.Session.Get<List<Items>>("item");
                var res = student.Find(x => x.Gi == ss.Gi);
                res.Item_Name = ss.Item_Name;
                res.Notes = ss.Notes;
                HttpContext.Session.Set<List<Items>>("item", student);
            }
            return Json(student);
        }

        public JsonResult Del(string guid)
        {
            List<Items> students = HttpContext.Session.Get<List<Items>>("item");
            var res = students.Find(x => Convert.ToString(x.Gi) == guid);
            students.Remove(res);

            HttpContext.Session.Set<List<Items>>("item", students);
            return Json(students);
        }

    }
}
