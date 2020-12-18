using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RelationalDB_RESTAPI.Controllers
{
    [RoutePrefix("Debug")]
    public class DebugController : ApiController
    {
        [HttpGet]
        [Route("getPath")]
        public string getPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
