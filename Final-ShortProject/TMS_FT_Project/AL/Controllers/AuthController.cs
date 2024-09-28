using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AL.Controllers
{
    public class AuthController : ApiController
    {
       

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var token = AuthServices.Authenticate(login.Uname, login.Password);
                if (token != null)
                {
                    HttpContext.Current.Session["UserEmail"] = login.Uname;
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
             
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/signup")]
        public HttpResponseMessage SignUp(SignUpDTO signUp)
        {
            try
            {
                var result = AuthServices.SignUp(signUp);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User successfully created.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create user.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var key = Request.Headers.Authorization;
            if (key == null) return Request.CreateResponse(HttpStatusCode.InternalServerError, "You might forgot to supply token to logout");
            try
            {

                var token = AuthServices.LogoutToken(key.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, token);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "You might forgot to supply token to logout");
            }
        }
    }
}
