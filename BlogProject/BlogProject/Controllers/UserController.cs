using AutoMapper;
using BlogProject.Auth;
using BlogProject.DTOs;
using BlogProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class UserController : Controller
    {

        LabdBEntities1 db = new LabdBEntities1();
        public static User Convert(UserDTO u)
        {
            return new User
            {
              Uid = u.Uid,
              UserName = u.UserName,
              UserRole = u.UserRole,
              UserStatus = u.UserStatus,
              UserRealName = u.UserRealName
              

            };
        }

        public static UserDTO Convert(User ut)
        {
            return new UserDTO
            {
                Uid = ut.Uid,
                UserName = ut.UserName,
                UserRole = ut.UserRole,
                UserStatus = ut.UserStatus,
                UserRealName = ut.UserRealName

            };
        }

        public static List<UserDTO> Convert(List<User> us)
        {
            var list = new List<UserDTO>();
            foreach (var c in us)
            {
                list.Add(Convert(c));
            }
            return list;
        }
        // GET: User
        [UserAccess]
        public ActionResult UserDashboard()
        {
            return View();
        }

        [UserAccess]
        public ActionResult UserDetails()
        {
            var data = db.Users.ToList();
            return View(Convert(data));
           
        }

       
    }
}