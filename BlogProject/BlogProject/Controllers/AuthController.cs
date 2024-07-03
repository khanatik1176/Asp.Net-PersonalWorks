using AutoMapper;
using BlogProject.DTOs;
using BlogProject.EF;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth

        LabdBEntities1 db = new LabdBEntities1();

        public static Mapper getMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistrationDTO, User>();
                cfg.CreateMap<User, RegistrationDTO>();
            });

            return new Mapper(config);

        }

        [HttpGet]
        public ActionResult Registration()
        {



            return View(new RegistrationDTO());
        }


        [HttpPost]
        public ActionResult Registration(RegistrationDTO regObj)
        {
            if(ModelState.IsValid)
            {
                var mapper = getMapper();
                var reg = mapper.Map<User>(regObj);

                if (reg.UserPassword == regObj.ConfirmPassword)
                {
                    reg.UserRole = "User";
                    reg.UserStatus = "Activated";
                    db.Users.Add(reg);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }

            }
            return View(regObj);
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult Login(LoginDTO logger)
        {
            if(ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.UserName.Equals(logger.UserName)&& u.UserPassword.Equals(logger.UserPassword) 
                            select u).SingleOrDefault();

                if(user == null)
                {
                    TempData["Msg"] = "User Name or Password is Invald";
                    return RedirectToAction("Login", "Auth");
                }

                Session["User"] = user;
                TempData["Msg"] = "Login Successfully";

                if(user.UserRole.Equals("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }

                return RedirectToAction("UserDashboard", "User");
            }


            return View(logger);
        }
    }
}