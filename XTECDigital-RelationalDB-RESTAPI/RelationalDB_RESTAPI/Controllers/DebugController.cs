using RelationalDB_RESTAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

        [HttpPost]
        [Route("uploadFile")]
        public string uploadFile()
        {
            var request = HttpContext.Current.Request;
            var file = request.Files["image"];

            if (file != null)
            {
                DocumentManager.saveToTempFolder(file);
            }
            else
            {
                return "Key doesn't match or file was empty";
            }

            return "image uploaded successfully";
        }
    }
}
