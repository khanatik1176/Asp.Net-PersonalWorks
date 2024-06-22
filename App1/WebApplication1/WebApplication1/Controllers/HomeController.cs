using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.EF;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {   
           return View();
        }
        [HttpPost]
        public ActionResult Registration(StudentDTO s)
        {
            School_dbEntities2 db = new School_dbEntities2();

            if(ModelState.IsValid)
            {
                var st = new Student()
                {
                    Name = s.FirstName.Trim()+" "+ s.LastName.Trim(),
                    Email = s.Email,
                    Address = s.Address

                };

                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Please fill the data properly";
            }

            return View(s);
        }

        public ActionResult ViewStudents()
        {
            School_dbEntities2 db = new School_dbEntities2();

            var data = db.Students.ToList();
  
            return View(data);
        }

        [HttpGet]
        public ActionResult EditStudents(int id)
        {
            School_dbEntities2 db = new School_dbEntities2();
            var exobj = db.Students.Find(id);
            return View(exobj);
        }

        [HttpPost]

        public ActionResult EditStudents(Student s)
        {
            School_dbEntities2 db = new School_dbEntities2();
            var exobj = db.Students.Find(s.id);
            exobj.Name = s.Name;
            exobj.Email = s.Email;
            exobj.Address = s.Address;

            db.SaveChanges();
            return RedirectToAction("ViewStudents");
        }

        [HttpGet]
        public ActionResult DeleteStudents(Student s)
        {
            School_dbEntities2 db = new School_dbEntities2();
            var exobj = db.Students.Find(s.id);

            if(exobj != null)
            {
                db.Students.Remove(exobj);
                db.SaveChanges();
            }
            return RedirectToAction("ViewStudents");
        }

        public ActionResult Search(string Search)
        {
            School_dbEntities2 db = new School_dbEntities2();

            var data = (from s in db.Students
                        where s.Email.Contains(Search)
                        select s).ToList();

            return View("ViewStudents", data);
        }



    }
}