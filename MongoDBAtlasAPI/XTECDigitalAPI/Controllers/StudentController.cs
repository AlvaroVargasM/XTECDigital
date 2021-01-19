using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using XTECDigitalAPI.Models;


namespace XTECDigitalAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentController : ApiController
    {
        private readonly StudentDBAccessProvider _studentDBAccess = new StudentDBAccessProvider();
        private EncryptAndDecryptService encryptandecryptS = new EncryptAndDecryptService();
        
        
        // GET: api/Student
        public IEnumerable<Student> Get()
        {
            return _studentDBAccess.Get();
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

                student.password = encryptandecryptS.encrypts(student.password);
                _studentDBAccess.Create(student);
                return Ok();
            }
            return BadRequest();
            
           
        }

        // PUT: api/Student/5
        [HttpPut]
        public IHttpActionResult Update([FromBody] Student studentIn)
        {
           
            var student = _studentDBAccess.Get(studentIn._id);
            
            if (student == null)
            {

                return NotFound();
            }
            _studentDBAccess.Update(studentIn);
            return Ok();

        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(string id)
        {
            var student = _studentDBAccess.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentDBAccess.Remove(id);
            return Ok();
        }
        // Post: api/Student/LogIn
        [HttpPost]
        public bool LogIn([FromBody] LogInAndOutMessage msg)
        {

            return _studentDBAccess.verifyCredentials(msg);
        }
    }
}
