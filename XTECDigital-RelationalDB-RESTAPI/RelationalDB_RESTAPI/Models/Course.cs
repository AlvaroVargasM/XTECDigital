using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{
    public class Course
    {
        public string code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string degree { get; set; }
    }
}