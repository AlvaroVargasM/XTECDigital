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
        [Route("Semesters/{year}/{period}")]
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
    }
}
