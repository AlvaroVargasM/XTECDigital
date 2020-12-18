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
    public class SemesterController : ApiController
    {
        [HttpGet]
        [Route("Semesters")]
        public IHttpActionResult getSemesters()
        {
            List<Semester> semesters = Connector.getSemesters();
            if(semesters == null)
            {
                return null;
            }

            return Ok(semesters);
        }

        [HttpGet]
        [Route("Semester/{year}/{period}/Courses")]
        public IHttpActionResult getCoursesforSemester(int year, string period)
        {

            /*List<Course> courses = Connector.getCoursesBySemester(year, period);
            if(courses == null)
            {
                return null;
            }

            return courses;*/
            return null;
        }

        [HttpGet]
        [Route("Semester/{year}/{period}/{courseCode}/Groups")]
        public IHttpActionResult getGroupsByCourse(int year, string period, string courseCode)
        {

            /*List<Group> groups = Connector.getGroupsBySemesterANDCourse(year, period, courseCode);
            if(groups == null)
            {
                return null;
            }

            return groups;*/
            return null;
        }
    }
}
