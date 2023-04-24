using Microsoft.AspNetCore.Mvc;
using Supplier.Models;
using System.Collections.Generic;

namespace Supplier.Controllers
{
    public class SupplierController : Controller
    {

        public IActionResult Welcome() 
        {
            return View(); 
        }
        public IActionResult tabledata()
        {
         
            return View();
        }
        public IActionResult Index(string id)
        {
            Suppliers gg = new Suppliers();
            if (id != "0")
            {
                var students = HttpContext.Session.Get<List<Suppliers>>("Name");
                gg = students.Find(x => Convert.ToString(x.Gid) == id);

            }
            return View(gg);
        }
        public JsonResult Reload()
        {
          var  students = HttpContext.Session.Get<List<Suppliers>>("Name");
          return Json(students);
        }

        public JsonResult Resultdata(Suppliers ss)
        {
            List<Suppliers> student = new List<Suppliers>();

            if (ss.Gid == null)
            { 
            Guid guid = Guid.NewGuid();
            ss.Gid = guid;
            if (HttpContext.Session.Get<List<Suppliers>>("Name") != null)
            {
                student = HttpContext.Session.Get<List<Suppliers>>("Name");
                student.Add(ss);
                HttpContext.Session.Set<List<Suppliers>>("Name", student);
            }
            else
            {
                student.Add(ss);
                HttpContext.Session.Set<List<Suppliers>>("Name", student);
            }
            }
            else
            {
                student = HttpContext.Session.Get<List<Suppliers>>("Name");
                var res = student.Find(x =>x.Gid == ss.Gid);
                res.Supplier_Name = ss.Supplier_Name;
                res.Mobile_No = ss.Mobile_No;
                res.ZipCode = ss.ZipCode;
                res.City = ss.City;
                res.State = ss.State;
                res.Email = ss.Email;
                HttpContext.Session.Set<List<Suppliers>>("Name", student);


            }
            return Json(student);
        }

       public JsonResult Del(string guid)
        {
            List<Suppliers> students = HttpContext.Session.Get<List<Suppliers>>("Name");
            var res = students.Find(x => Convert.ToString(x.Gid) == guid);
            students.Remove(res);

            HttpContext.Session.Set<List<Suppliers>>("Name", students);
            return Json(students);
        }

    }
}
