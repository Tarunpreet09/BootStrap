using asssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace asssignment.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult data()
        {
            return View();
        }

        public JsonResult Reload()
        {
            List<students> obj = HttpContext.Session.Get<List<students>>("Name");
            return Json(obj);
        }
     
        public JsonResult data1(students ss)
        {            
            List<students> student = new List<students>();
            Guid guid = Guid.NewGuid();
            ss.Guid = guid;
            

            if (HttpContext.Session.Get<List<students>>("Name") != null)
            {
                student = HttpContext.Session.Get<List<students>>("Name");

                var emp = student.Find(x => x.Subject == ss.Subject);
                if(emp == null)
                {
                    student.Add(ss);
                }             
                HttpContext.Session.Set<List<students>>("Name", student);
            }

            else
            {
                student.Add(ss);
                HttpContext.Session.Set<List<students>>("Name", student);
            }
            return Json(student);
        }

        public JsonResult Del(string guid)
        {
            List<students> update = HttpContext.Session.Get<List<students>>("Name");
            var res= update.Find(x => Convert.ToString(x.Guid) == guid);
            update.Remove(res);

            HttpContext.Session.Set<List<students>>("Name", update);
            return Json(update);
        }

        public JsonResult Edit1(string guid, students first)
        {
            List<students>edit = HttpContext.Session.Get<List<students>>("Name");
            var res = edit.Find(x => Convert.ToString(x.Guid) == guid);
            res.Subject = first.Subject;
            res.Marks = first.Marks;

            HttpContext.Session.Set<List<students>>("Name", edit);
            return Json(edit);
        }
     

    }
}

