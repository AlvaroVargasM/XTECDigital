using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{

    public class XlslToCSVService

    {
        public void convertToCsv(string path)
        {
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            // Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            // DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();

            // Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            result.Tables[0].TableName.ToString(); // to get first sheet name (table name)

            string csvData = "";
            int row_no = 0;

            while (row_no < result.Tables["Data"].Rows.Count) // ind is the index of table
                                                           // (sheet name) which you want to convert to csv
            {
                for (int i = 0; i < result.Tables["Data"].Columns.Count; i++)
                {
                    if (i == 12)
                    {
                        csvData += result.Tables["Data"].Rows[row_no][i].ToString();
                    }
                    else {
                        csvData += result.Tables["Data"].Rows[row_no][i].ToString() + ",";
                    }
                }
                row_no++;
                csvData += "\n";
            }
            string output = "Cache/"+ "Transformed"+".csv"; // define your own filepath & filename
            StreamWriter csv = new StreamWriter(@output, false);
            csv.Write(csvData);
            csv.Close();

        }
    }
}