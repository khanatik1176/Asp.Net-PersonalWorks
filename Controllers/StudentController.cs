using Students.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Controllers
{
    public class StudentController : ApiController
    {
        private StudentEntities sb = new StudentEntities();

        [HttpGet]
        [Route("api/student/all")]

        public HttpResponseMessage AllStudents()
        {
           

            var data = sb.StudentDetails.ToList();


            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/student/{id}")]

        public HttpResponseMessage SingleStudent(int id)
        {
            var data_id = sb.StudentDetails.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, data_id);
        }

        [HttpPost]
        [Route("api/student/create")]

        public HttpResponseMessage CreateStudent(StudentDetail student)
        {
            sb.StudentDetails.Add(student);
            sb.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Student Created");

        }

        [HttpPatch]
        [Route("api/student/edit/{id}")]

        public HttpResponseMessage UpdateStudent(int id, StudentDetail student) 
        {
            var tempdata = sb.StudentDetails.Find(id);

            tempdata.Name = student.Name;
            tempdata.Email = student.Email;
            tempdata.Address = student.Address;

            sb.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, id + " has Updated");
        }

        [HttpDelete]
        [Route("api/student/delete/{id}")]

        public HttpResponseMessage DeleteStudent(int id)
        {
             var tempData = sb.StudentDetails.Find(id);

            sb.StudentDetails.Remove(tempData);

            sb.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, id  + " is Deleted");
        }
    }
}
