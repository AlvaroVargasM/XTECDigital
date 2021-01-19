using RelationalDB_RESTAPI.Models;
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
        /// <summary>
        /// Uploads a file to the specified path
        /// </summary>
        /// <param name="semester">Year of the semester</param>
        /// <param name="period">Period of the semester</param>
        /// <param name="groupCode">Code of the group</param>
        /// <param name="groupNumber">Number of the group</param>
        /// <param name="folder">folder hierarchy</param>
        /// <returns>Boolean whether or not it was uploaded</returns>
        [HttpPost]
        [Route("upload/{semester}/{period}/{groupCode}/{groupNumber}/{folder}")]
        public bool upload(string semester, string period, string groupCode, string groupNumber, string folder)
        {
            DocumentManager.startBuildUp();
            
            var file = HttpContext.Current.Request.Files["file"];
            string[] filesHierachy = folder.Split('~');

            bool succesful = DocumentManager.saveToGroupFolder(file, groupCode, groupNumber, semester, period, filesHierachy);

            return succesful;
        }

        /// <summary>
        /// Provides the ability to download a field from the database
        /// </summary>
        /// <param name="semester">Year of the semester</param>
        /// <param name="period">Period of the semester</param>
        /// <param name="groupCode">Code of the group</param>
        /// <param name="groupNumber">Number of the group</param>
        /// <param name="folder">folder hierarchy</param>
        /// <param name="filename">name of the file</param>
        /// <param name="format">format of the file requested</param>
        /// <returns>Provides a filestream to download</returns>
        [HttpGet]
        [Route("download/{semester}/{period}/{groupCode}/{groupNumber}/{folder}/{filename}/{format}")]
        public HttpResponseMessage download(string semester, string period, string groupCode, string groupNumber, string folder, string filename, string format)
        {
            DocumentManager.startBuildUp();

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

        [HttpPost]
        [Route("LoadExcelToSQL")]
        public bool saveExcelToSQL()
        {
            var file = HttpContext.Current.Request.Files["file"];

            XlslToCSVService excelToCSVServ = new XlslToCSVService();
            bool response = excelToCSVServ.SaveExcelToSQL(file);

            return response;
        }

    }
}
