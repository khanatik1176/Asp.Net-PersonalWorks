using CourseProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.DTOs;

namespace CourseProject.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCourses()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddCourses(CourseDto cl)
        {
            LabdBEntities1 db = new LabdBEntities1();

            if(ModelState.IsValid)
            {
                var convertedData = Convert(cl);
                db.Courses.Add(convertedData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cl);
        }

        public ActionResult ViewCourses()
        {
            LabdBEntities1 db = new LabdBEntities1();
            var data = db.Courses.ToList();
            var converted = Convert(data);
            return View(converted);
        }

        [HttpGet]
        public ActionResult DeleteCourses(CourseDto c)
        {
            LabdBEntities1 db = new LabdBEntities1();
            var exobj = db.Courses.Find(c.Id);

            if(exobj != null)
            {
                db.Courses.Remove(exobj);
                db.SaveChanges();
            }
            return RedirectToAction("ViewCourses");
        }


        [HttpGet]
        public ActionResult EditCourses(int id)
        {

            LabdBEntities1 db = new LabdBEntities1();
            var exobj = db.Courses.Find(id);
            var convertData = Convert(exobj);
            return View(convertData);

        }
        [HttpPost]
        public ActionResult EditCourses(CourseDto c)
        {
            LabdBEntities1 db = new LabdBEntities1();
            if (ModelState.IsValid)
            {
                var exobj = db.Courses.Find(c.Id);
                exobj.Title = c.Title;
                exobj.CreditHour = c.CreditHour;
                exobj.Type = c.Type;


                db.SaveChanges();
            }

            //caution in using this method
            //db.Entry(exobj).CurrentValues.SetValues(s);

            //for delete
            //db.Students.Remove(exobj);
            //db.SaveChanges();

            return RedirectToAction("ViewCourses");
        }


        //Converting Cours data to CourseDto data type
        public static CourseDto Convert(Cours c)
        {

            return new CourseDto()
            {
                Title = c.Title,
                CreditHour = c.CreditHour,
                Type = c.Type,
                Id = c.Id
            };
        }

        //converting courseDto to Cours type data
        public static Cours Convert(CourseDto c)
        {

            return new Cours()
            {
                Title = c.Title,
                CreditHour = c.CreditHour,
                Type = c.Type,
                Id = c.Id
            };
        }

        public static List<CourseDto> Convert(List<Cours> courses)
        {
            var list = new List<CourseDto>();
            foreach (var c in courses)
            {
                var ct = Convert(c);
                list.Add(ct);
            }
            return list;
        }





    }

    
}