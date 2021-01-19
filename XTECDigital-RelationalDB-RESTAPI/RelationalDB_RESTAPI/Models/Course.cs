using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{
    public class Course
    {
        public string code { get; set; }
        public string name { get; set; }
        public int credits { get; set; }
        public string school { get; set; }

        public Course(string code, string name, int credits, string school)
        {
            this.code = code;
            this.name = name;
            this.credits = credits;
            this.school = school;
        }
    }
}