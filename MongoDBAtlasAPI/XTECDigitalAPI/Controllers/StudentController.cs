using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XTECDigitalAPI.Models;

namespace XTECDigitalAPI.Controllers
{
    public class StudentController : ApiController
    {
        private readonly MongoDBAccessProvider _mongoDBAccess = new MongoDBAccessProvider();
        
        
        // GET: api/Student
        public IEnumerable<Student> Get()
        {
            Console.WriteLine("Hola");
            return _mongoDBAccess.Get();
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        [HttpPost]
        public IHttpActionResult CreateAStudent([FromBody] Student student)
        {
            if (ModelState.IsValid) {
                
                Guid obj = Guid.NewGuid();
                student._id = obj.ToString();
                _mongoDBAccess.Create(student);
                return Ok();
            }
            return BadRequest();
            
           
        }

        // PUT: api/Student/5
        [HttpPut]
        public IHttpActionResult Update([FromBody] Student studentIn)
        {
           
            var student = _mongoDBAccess.Get(studentIn._id);
            if (student == null)
            {

                return NotFound();
            }
            _mongoDBAccess.Update(studentIn);
            return Ok();

        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(string id)
        {
            var student = _mongoDBAccess.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            _mongoDBAccess.Remove(id);
            return Ok();
        }
    }
}
