using ExcelDataReader;
using RelationalDB_RESTAPI.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{

    public class XlslToCSVService

    {
        public static string connectionString = "Data Source=dxnium.database.windows.net,1433; " +
            "Network Library = DBMSSOCN; Initial Catalog = XTECDigital; " +
            "User ID = dxnium; Password=Dumanamonge9921";

        /*
         *Description: Converts an excel file to a .csv file
         *Params: Path string
         *Output: None
        */
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
            string output = DocumentManager.testFolderPath+ "/"+"Transformed"+".csv"; // define your own filepath & filename
            StreamWriter csv = new StreamWriter(@output, false);
            csv.Write(csvData);
            csv.Close();

        }
        /*
         *Description: Saves the .csv file to a temporary SQL table
         *Params: File 
         *Output: true or false
        */
        public bool SaveExcelToSQL(HttpPostedFile file) {
            XlslToCSVService xlstToCSV = new XlslToCSVService();
            DocumentManager.saveToTempFolder(file);
            string filename = file.FileName;
            xlstToCSV.convertToCsv(DocumentManager.testFolderPath + "/" + filename);
            
            var lineNumber = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand();
                using (StreamReader reader = new StreamReader(DocumentManager.testFolderPath + "/"+"Transformed.csv"))
                {
                    var sqlCreate = "CREATE TABLE ##TEMPSEMESTRE(Carnet VARCHAR(50),Nombre VARCHAR(50),Apellido1 VARCHAR(50),Apellido2 VARCHAR(50),IdCurso VARCHAR(50),NombreCurso VARCHAR(50),Ano INT,Semestre INT, Grupo INT,IdProfesor VARCHAR(50),NombreProfesor VARCHAR(50),ApellidoProfesor VARCHAR(50),ApellidoProfesor2 VARCHAR(50))";
                    
                    cmd.CommandText = sqlCreate;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();

                    while (!reader.EndOfStream)
                    {

                        try
                        {
                            var line = reader.ReadLine();
                            if (lineNumber != 0)
                            {
                                var values = line.Split(',');
                                var sql = "INSERT INTO ##TEMPSEMESTRE VALUES ('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "','" + values[6] + "','" + values[7] + "','" + values[8] + "','" + values[9] + "','" + values[10] + "','" + values[11] + "','" + values[12] + "')";
                                cmd.CommandText = sql;
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Connection = conn;
                                cmd.ExecuteNonQuery();
                            }
                            lineNumber++;
                        }
                        catch (Exception)
                        {

                            return false;
                        }

                    }
                    
                }
                SqlCommand execSP = new SqlCommand("fillSQLwithExcel", conn);
                execSP.CommandType = CommandType.StoredProcedure;
                execSP.ExecuteNonQuery();
                conn.Close();
            
                return true;
            }
       
        }

    }
}