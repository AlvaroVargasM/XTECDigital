using RelationalDB_RESTAPI.DataAccess;
using RelationalDB_RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RelationalDB_RESTAPI.Controllers
{
    public class SubmissionsController : ApiController
    {
        public readonly SQLContext _context = new SQLContext();
        public SubmissionsController()
        {

        }

        [HttpPost]
        [Route("Submissions/Create")]
        public IHttpActionResult Create([FromBody] Submissions submissions)
        {
            if (ModelState.IsValid)
            {
                _context.submissions.Add(submissions);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
