using RelationalDB_RESTAPI.Models;
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
        public List<Semester> getSemesters()
        {
            /*List<Semester> semesters = Connector.getSemesters();
            if(semesters == null)
            {
                return null;
            }

            return semesters;*/
            return null;
        }

        [HttpGet]
        [Route("Semester/{year}/{period}/Courses")]
        public List<Course> getCoursesforSemester(int year, string period)
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
        public List<Group> getGroupsByCourse(int year, string period, string courseCode)
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
