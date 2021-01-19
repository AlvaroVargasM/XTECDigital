using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{
    [Table("Evaluations")]
    public class Evaluations
    {
        [Key]
        public string id { get; set; }
        public DateTime deadline { get; set; }
        public Decimal value { get; set; }
        public string specification { get; set; }
        public string name_rubric { get; set; }
        public int number_group { get; set; }
        public int year_semester { get; set; }
        public string period_semester { get; set; }
        public string code_course { get; set; }

    }
}