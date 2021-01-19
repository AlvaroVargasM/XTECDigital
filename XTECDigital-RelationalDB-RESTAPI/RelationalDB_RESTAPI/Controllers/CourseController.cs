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
        /// <summary>
        /// Gets all the courses from the database
        /// </summary>
        /// <returns>All courses from database</returns>
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

        /// <summary>
        /// Creates a new course
        /// </summary>
        /// <param name="code">Code for course</param>
        /// <param name="name">Name of course</param>
        /// <param name="credits">Credits for the course</param>
        /// <param name="school">School for the course</param>
        /// <returns>Whether or not it was successfully created</returns>
        [HttpPost]
        [Route("Courses/{code}/{name}/{credits}/{school}")]
        public bool createCourse(string code, string name, int credits, string school)
        {
            return Connector.createCourse(code, name, credits, school);
        }
    }
}
