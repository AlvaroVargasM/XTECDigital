using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Models
{
    public class Run
    {
        public static string connectionString = "Data Source=dxnium.database.windows.net,1433; " +
            "Network Library = DBMSSOCN; Initial Catalog = XTECDigital; " +
            "User ID = dxnium; Password=Dumanamonge9921";
        static public void Main(String[] args)
        {
            XlslToCSVService xlstToCSV = new XlslToCSVService();
            xlstToCSV.convertToCsv("C:/Users/SMZ19/Downloads/SemestreData.xlsx");
            
            var lineNumber = 0;
            using (SqlConnection conn = new SqlConnection(connectionString)) {
               
                conn.Open();
                using (StreamReader reader = new StreamReader(@"C:\Users\SMZ19\OneDrive\Documentos\GitHub\XTECDigital\XTECDigital-RelationalDB-RESTAPI\RelationalDB_RESTAPI\Cache\Transformed.csv")) {
                    while (!reader.EndOfStream) { 
                        var line =  reader.ReadLine();
                        if (lineNumber != 0) {
                            var values = line.Split(',');
                            Console.WriteLine("Hello");
                            Console.WriteLine(values[12]);
                            Console.ReadLine();
                            var sql = "INSERT INTO XTECDigital.dbo.TEMPSEMESTRE VALUES ('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','"+ values[4] + "','" + values[5] + "','" + values[6] + "','"+ values[7] + "','" + values[8] + "','" + values[9] + "','" + values[10] + "','" + values[11] + "','" + values[12] + "')";
                            var cmd = new SqlCommand();
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;
                       
                    }
                }
                conn.Close();
            }
            Console.WriteLine("Successfully imported");
            Console.ReadLine();
            
            
            
        }
    }
}