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
    }
}
