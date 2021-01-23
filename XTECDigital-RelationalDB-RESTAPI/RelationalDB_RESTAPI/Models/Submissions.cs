using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationalDB_RESTAPI.Models
{
    [Table("Submissions")]
  
    public class Submissions
    {
        public int number_team { get; set; }
        public int number_group { get; set; }
        public int year_semester { get; set; }
        public string period_semester { get; set; }
        public string code_course { get; set; }
        public string ssn_professor { get; set; }
        [Key]
        public string id_evaluation { get; set; }
        public int score { get; set; }

    }
}