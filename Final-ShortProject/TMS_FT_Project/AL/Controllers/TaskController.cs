using AL.Auth;
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
    [Logged]
    [RoutePrefix("api/Task")]
    public class TaskController : ApiController
    {
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get ()
        {
            try
            {
                var data = TaskService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch(Exception ex)
             {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = TaskService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public HttpResponseMessage Create(TaskDTO obj)
        {
            try
            {
                obj.UserEmail = HttpContext.Current.Session["UserEmail"] as string;
                var data = TaskService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]

        public HttpResponseMessage Update(TaskDTO obj)
        {
            try
            {
                var data = TaskService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]

        public HttpResponseMessage Delete (int id)
        {
            try
            {
                var data = TaskService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Complete/{id}")]

        public HttpResponseMessage MarkComplete(int id)
        {
            try
            {
                var data = TaskService.UpdateTaskStatus(id, "Complete");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Incomplete/{id}")]

        public HttpResponseMessage MarkIncomplete(int id)
        {
            try
            {
                var data = TaskService.UpdateTaskStatus(id, "Incomplete");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("filter/{status}")]
        
        public HttpResponseMessage GetTaskByStatus(string status)
        {
            try
            {
                var data = TaskService.GetTasksByStatus(status);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("filter/category/{cat}")]

        public HttpResponseMessage GetTaskByCat(string cat)
        {
            try
            {
                var data = TaskService.GetTaskByCat(cat);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("upcoming/{days}")]

        public HttpResponseMessage GetUpcomingTasks(int days)
        {
            try
            {
                var data = TaskService.GetUpcomingTasks(days);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }

            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
