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
    
    public class GroupController : ApiController
    {
        /// <summary>
        /// Gets all groups from the server
        /// </summary>
        /// <returns>All groups</returns>
        [HttpGet]
        [Route("Groups")]
        public IHttpActionResult getGroups()
        {
            List<Group> groups = Connector.getGroups();
            if (groups == null)
            {
                return null;
            }

            return Ok(groups);
        }

        /// <summary>
        /// Gets all group from an specific semester
        /// </summary>
        /// <param name="year">Year of the semester</param>
        /// <param name="period">Period of the semester</param>
        /// <returns>All groups in the semester</returns>
        [HttpGet]
        [Route("Groups/{year}/{period}")]
        public IHttpActionResult getGroupsBySemester(int year, string period)
        {
            if(!(period.Equals("1") || period.Equals("2") || period.Equals("V")))
            {
                return BadRequest();
            }

            List<Group> groups = Connector.getGroupsBySemester(year, period);
            if (groups == null)
            {
                return null;
            }

            return Ok(groups);
        }

        /// <summary>
        /// Gets the groups from a professor
        /// </summary>
        /// <param name="professorSSN">Professors SSN</param>
        /// <returns>Groups by chosen professor</returns>
        [HttpGet]
        [Route("Groups/{professorSSN}")]
        public IHttpActionResult getGroupsByProfessor(string professorSSN)
        {
            List<Group> groups = Connector.getGroupsByProfesor(professorSSN);
            if (groups == null)
            {
                return null;
            }

            return Ok(groups);
        }

        /// <summary>
        /// Generates the folder from the server's groups
        /// </summary>
        /// <returns>ResponseCode</returns>
        [HttpPost]
        [Route("Groups/GenerateDatabase")]
        public IHttpActionResult generateDatabase()
        {
            bool done = DocumentManager.startBuildUp();
            
            if(done)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
