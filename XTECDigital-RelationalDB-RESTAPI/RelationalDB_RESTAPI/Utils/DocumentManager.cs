using RelationalDB_RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Utils
{
    public static class DocumentManager
    {
        public static string fileManagerRoot = AppDomain.CurrentDomain.BaseDirectory + "/Database";
        public static string fileDefaults = AppDomain.CurrentDomain.BaseDirectory + "/Configurations/defaults.txt";
        public static string testFolderPath = AppDomain.CurrentDomain.BaseDirectory + "/TempFolder";


        public static bool wipeTestFolderContent()
        {
            if (Directory.Exists(testFolderPath))
            {
                Directory.Delete(testFolderPath, true);
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/TempFolder");

                return true;
            }
            return false;
        }

        public static bool saveToTempFolder(HttpPostedFile file)
        {
            try
            {
                string filename = file.FileName;

                file.SaveAs(testFolderPath + "/" +  filename);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static FileStream getFileFromTempFolder(string filename, string format)
        {
            return File.Open(testFolderPath + '/' + filename + '.' + format, FileMode.Open);
        }

        public static FileStream getFileFromGroupFolder(string groupCode, string groupNumber, string yearSemester, string periodSemester, string[] subfolders, string filename)
        {
            string groupFolder = groupCode + '_' + groupNumber + '_' + yearSemester + '_' + periodSemester;

            foreach (string folder in subfolders)
            {
                groupFolder += '/' + folder;
            }

            return File.Open(fileManagerRoot + '/' + groupFolder + '/' + filename, FileMode.Open);
        }

        public static bool saveToGroupFolder(HttpPostedFile file, string groupCode, string groupNumber, string yearSemester, string periodSemester, string[] subfolders)
        {
            try
            {
                string filename = file.FileName;

                string groupFolder = groupCode + '_' + groupNumber + '_' + yearSemester + '_' + periodSemester;

                foreach (string folder in subfolders)
                {
                    groupFolder += '/' + folder;
                }

                file.SaveAs(fileManagerRoot + '/' + groupFolder + '/' + filename);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        
        public static bool startBuildUp()
        {
            try
            {
                List<String> defaults = new List<string>();

                CreateRootFolderForGroup();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool checkExistence(string path)
        {
            if (Directory.Exists(fileManagerRoot))
            {
                return true;
            }

            return false;
        }
        
        public static void createNewGroupDirectory(string groupID)
        {
            string tempDestination = fileManagerRoot + "/" + groupID;


            if (!Directory.Exists(tempDestination))
            {
                Directory.CreateDirectory(tempDestination);
                string[] defaultDirectories = File.ReadAllLines(fileDefaults);

                foreach(string defaultDirectory in defaultDirectories)
                {
                    Directory.CreateDirectory(tempDestination + "/" + defaultDirectory);
                }
            }
        }
        
        public static void CreateRootFolderForGroup()
        {
            List<Group> groups = Connector.getGroups();

            foreach(Group group in groups)
            {
                createNewGroupDirectory(group.code_course + '_' + group.number + '_' + group.year_semester + '_' + group.period_semester);
            }


        }
    }
}