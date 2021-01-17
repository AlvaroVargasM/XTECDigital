using RelationalDB_RESTAPI.Models;
using RelationalDB_RESTAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RelationalDB_RESTAPI.Controllers
{
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("Courses")]
        public IHttpActionResult getCourses()
        {
            List<Course> courses = Connector.getCourses();
            if (courses == null)
            {
                return null;
            }

            return Ok(courses);
        }

        [HttpPost]
        [Route("Courses/{code}/{name}/{credits}/{school}")]
        public bool createCourse(string code, string name, int credits, string school)
        {
            return Connector.createCourse(code, name, credits, school);
        }
    }
}
