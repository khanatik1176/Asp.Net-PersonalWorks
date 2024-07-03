using BlogProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Auth
{
    public class AdminAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User)httpContext.Session["User"];
            if (user != null && user.UserRole.Equals("Admin"))
            {
                return true;
            }

            return false;
        }

    }
}