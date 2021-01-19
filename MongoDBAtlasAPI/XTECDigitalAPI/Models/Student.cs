using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XTECDigitalAPI.Models
{
    public class Student
    {
        public string _id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int telephoneNumber { get; set; }

        public string password { get; set; }
    }
}