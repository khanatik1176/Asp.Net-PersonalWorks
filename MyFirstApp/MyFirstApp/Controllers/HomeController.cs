using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstApp.Models;


namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HumanDetails Details = new HumanDetails()
            {
                Name = "Khan Atik Faisal",
                Email = "Khanatik1176@gmail.com",
                PhnNumber = "01767159064",
                Degree = "Bachelor",
                Expertise = "Website Development"
            };

            ViewBag.HumanDetails = new HumanDetails[] {Details};

            return View();
        }

        public ActionResult Education()
        {
            EduDetails eduH = new EduDetails()
            {
                CourseTitle = "HSC",
                Year = "2020",
                Group = "Science",
                Institute = "Milestone College"
            };

            EduDetails eduS = new EduDetails()
            {
                CourseTitle = "SSC",
                Year = "2017",
                Group = "Science",
                Institute = "Milestone College"
            };

            ViewBag.EduDetails = new EduDetails[] {eduH, eduS};



            return View();
        }

        public ActionResult Projects()
        {
            ProjectDetails projectDetails1 = new ProjectDetails()
            {
                ProjectTitle = "Parcel Management System",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                PCourse = "Web technologies"
            };
            
            ProjectDetails projectDetails2 = new ProjectDetails()
            {
                ProjectTitle = "Hospital Management System",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                PCourse = "Advanced Web technologies"
            }; 
            
            ProjectDetails projectDetails3 = new ProjectDetails()
            {
                ProjectTitle = "Hotel Management System",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                PCourse = "Object Oriented Programming 2"
            };


            ViewBag.ProjectDetails = new ProjectDetails[] {projectDetails1, projectDetails2, projectDetails3};

            return View();
        }

        public ActionResult Reference()
        {

            Reference refDetails = new Reference()
            {
                RefName = "Ismail Jobi",
                Designation = "Senior Software Engineer",
                Org = "Therap BD"
            };

            ViewBag.Reference = new Reference[] { refDetails };

            return View();

        }
    }
}