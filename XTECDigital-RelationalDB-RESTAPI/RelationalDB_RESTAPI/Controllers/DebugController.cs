using RelationalDB_RESTAPI.Models;
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
        /// <summary>
        /// Gets the path in which the database is being hosted
        /// </summary>
        /// <returns>Returns a string of the path</returns>
        [HttpGet]
        [Route("getPath")]
        public string getPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Uploads a file to the temp folder
        /// </summary>
        /// <returns>returns a confirmation string</returns>
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

        /// <summary>
        /// downloads a file from the temp folder
        /// </summary>
        /// <param name="filename">name of file</param>
        /// <param name="format">format of file</param>
        /// <returns>Filestream for file</returns>
        [HttpGet]
        [Route("downloadFile/{fileName}/{format}")]
        public HttpResponseMessage getFile(string filename, string format)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(DocumentManager.getFileFromTempFolder(filename, format));
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/" + format);
            return result;
        }


        /// <summary>
        /// Gets the professors from the database
        /// </summary>
        /// <returns>All professors</returns>
        [HttpGet]
        [Route("getProfessors")]
        public List<Professor> getProfessor()
        {
            return HttpClientConnector.getProfessors().Result;
        }
    }
}
