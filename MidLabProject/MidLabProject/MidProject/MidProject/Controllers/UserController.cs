using MidProject.Auth;
using MidProject.EF;
using MidProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace MidProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        MiddBEntities db = new MiddBEntities();

        public static User Convert(UserDTO u)
        {
            return new User
            {
                Uid = u.Uid,
                UserName = u.UserName,
                UserEmail = u.UserEmail,
                UserRole = u.UserRole,
                UserStatus = u.UserStatus,
                UserPhoneNumber = u.UserPhoneNumber,
                UserAddress = u.UserAddress,




            };
        }

        public static UserDTO Convert(User ut)
        {
            return new UserDTO
            {
                Uid = ut.Uid,
                UserName = ut.UserName,
                UserEmail = ut.UserEmail,
                UserRole = ut.UserRole,
                UserStatus = ut.UserStatus,
                UserPhoneNumber = ut.UserPhoneNumber,
                UserAddress = ut.UserAddress,

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