using Newtonsoft.Json;
using RelationalDB_RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RelationalDB_RESTAPI.Utils
{
    public static class HttpClientConnector
    {

        private static readonly HttpClient client = new HttpClient();

        public async static Task<List<Professor>> getProfessors()
        {
            HttpResponseMessage response = client.GetAsync("https://xtecdigitalapi20201217234131.azurewebsites.net/api/Professor/Get").Result;
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<Professor> professors = JsonConvert.DeserializeObject<List<Professor>>(responseBody);

            return professors;
        }
    }
}