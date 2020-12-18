using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{
    public class Group
    {
        public int number { get; set; }
        public int year_semester { get; set; }
        public string period_semester { get; set; }
        public string code_course { get; set; }
        public string path { get; set; }

        public Group(int number, int year_semester, string period_semester, string code_course, string path)
        {
            this.number = number;
            this.year_semester = year_semester;
            this.period_semester = period_semester;
            this.code_course = code_course;
            this.path = path;
        }

        
    }
}