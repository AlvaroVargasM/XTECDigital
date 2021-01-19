using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{
    public class Semester
    {
        public int year { get; set; }
        public string period { get; set; }

        public Semester(int year, string period)
        {
            this.year = year;
            this.period = period;
        }
}
}