using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XTECDigitalAPI.Models;


namespace XTECDigitalAPI.Controllers
{
    public class ProfessorController : ApiController
    {
        public readonly ProfessorDBAccessProvider _professorAccess = new ProfessorDBAccessProvider();
        // GET api/<controller>
        public IEnumerable<Professor> Get()
        {
            return _professorAccess.Get();
        }

        // POST: api/Professor
        [HttpPost]
        public IHttpActionResult CreateAProfessor([FromBody] Professor professor)
        {
            if (ModelState.IsValid)
            {
                
                _professorAccess.Create(professor);
                return Ok();
            }
            return BadRequest();


        }
        // Post: api/Student/LogIn
        [HttpPost]
        public bool LogIn([FromBody] LogInAndOutMessage msg)
        {

            return _professorAccess.verifyCredentials(msg);
        }
    }
}