using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RelationalDB_RESTAPI.Models;
using RelationalDB_RESTAPI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RelationalDB_RESTAPI.Controllers
{
    [RoutePrefix("Semesters")]
    public class SemesterController : ApiController
    {
        /// <summary>
        /// Gets all the semesters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult getSemesters()
        {
            List<Semester> semesters = Connector.getSemesters();
            if(semesters == null)
            {
                return null;
            }

            return Ok(semesters);
        }

        /// <summary>
        /// Verifies if a semester is created
        /// </summary>
        /// <param name="year">Year of the semester being queried</param>
        /// <param name="period">Period of the semester being queried</param>
        /// <returns>Whether or not the semester exists</returns>
        [HttpGet]
        [Route("{year}/{period}")]
        public bool isSemesterCreated(string year, string period)
        {
            List<Semester> semesters = Connector.getSemesters();
            foreach(Semester semester in semesters)
            {
                if (semester.year.Equals(year) && semester.period.Equals(period))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Initializes Semester
        /// </summary>
        /// <returns>boolean whether or not the server completed the request</returns>
        [HttpPost]
        [Route("Initialize")]
        public bool initializeSemester()
        {
            Semester semester = JsonConvert.DeserializeObject<Semester>(HttpContext.Current.Request.Params["semester"].ToString());
            string[] coursesSelected = Toolkit.separateByDelimiter(HttpContext.Current.Request.Params["coursesSelected"], ',');
            string[] groups = Toolkit.separateByDelimiter(HttpContext.Current.Request.Params["groups"], ',');
            string[] professors = Toolkit.separateByDelimiter(HttpContext.Current.Request.Params["professors"], ';');

            for(int i = 0; i < professors.Length; i++)
            {
                professors[i] = professors[i].Substring(0, professors[i].Length - 1);
            }

            string[] students = Toolkit.separateByDelimiter(HttpContext.Current.Request.Params["students"], ';');

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = students[i].Substring(0, students[i].Length - 1);
            }

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Course", typeof(string));
            dataTable.Columns.Add("Group", typeof(string));
            dataTable.Columns.Add("Professors", typeof(string));
            dataTable.Columns.Add("Students", typeof(string));

            for(int i = 0; i < groups.Length; i++)
            {
                dataTable.Rows.Add(coursesSelected[i], groups[i], professors[i], students[i]);
            }

            return Connector.SemesterInitialization(semester, dataTable);

        }
    }
}
