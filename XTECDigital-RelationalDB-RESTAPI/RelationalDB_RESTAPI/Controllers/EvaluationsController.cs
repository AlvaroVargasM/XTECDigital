using RelationalDB_RESTAPI.DataAccess;
using RelationalDB_RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RelationalDB_RESTAPI.Controllers
{
    public class EvaluationsController : ApiController
    {
        public readonly SQLContext _context = new SQLContext();
        public EvaluationsController( ) {
           
        }
        /*
         *Description: Saves a evaluations object in SQL 
         *Params: Object Evaluations
         *Output: HttpActionResult
        */
        [HttpPost]
        [Route("Evaluations/Create")]
        public IHttpActionResult Create([FromBody] Evaluations eval)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                eval.id = obj.ToString();
                _context.evaluations.Add(eval);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}