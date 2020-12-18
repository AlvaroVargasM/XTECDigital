using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{
    public class Run
    {
        static public void Main(String[] args)
        {
            XlslToCSVService xlstToCSV = new XlslToCSVService();
            xlstToCSV.convertToCsv("C:/Users/SMZ19/Downloads/SemestreData.xlsx");
        }
    }
}