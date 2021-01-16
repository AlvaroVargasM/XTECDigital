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
    }
}
