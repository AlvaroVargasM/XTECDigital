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

                return "image uploaded successfully";
            }
            else
            {
                return "Key doesn't match or file was empty";
            }
        }

        [HttpGet]
        [Route("downloadFile/{fileName}/{format}")]
        public HttpResponseMessage getFile(string filename, string format)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(DocumentManager.getFileFromTempFolder(filename, format));
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/" + format);
            return result;
        }
    }
}
