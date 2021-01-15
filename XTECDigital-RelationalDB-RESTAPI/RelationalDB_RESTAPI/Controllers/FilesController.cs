using RelationalDB_RESTAPI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RelationalDB_RESTAPI.Controllers
{
    [RoutePrefix("Files")]
    public class FilesController : ApiController
    {
        [HttpPost]
        [Route("upload/{semester}/{period}/{groupCode}/{groupNumber}/{folder}")]
        public bool upload(string semester, string period, string groupCode, string groupNumber, string folder)
        {
            var file = HttpContext.Current.Request.Files["file"];
            string[] filesHierachy = folder.Split('~');

            bool succesful = DocumentManager.saveToGroupFolder(file, groupCode, groupNumber, semester, period, filesHierachy);

            return succesful;
        }

        [HttpGet]
        [Route("download/{semester}/{period}/{groupCode}/{groupNumber}/{folder}/{filename}/{format}")]
        public HttpResponseMessage download(string semester, string period, string groupCode, string groupNumber, string folder, string filename, string format)
        {
            string[] filesHierachy = folder.Split('~');

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                result.Content = new StreamContent(DocumentManager.getFileFromGroupFolder(groupCode, groupNumber, semester, period, filesHierachy, filename + '.' + format));
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/" + format);
                return result;
            }
            catch (Exception)
            {
                result = new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            return result;
        }
    }
}
