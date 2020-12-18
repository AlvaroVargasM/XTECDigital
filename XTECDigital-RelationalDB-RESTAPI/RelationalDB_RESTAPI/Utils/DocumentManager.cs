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
        public static string fileDefaults = AppDomain.CurrentDomain.BaseDirectory + "/Configs/defaults.txt";
        public static List<string> templateFolder;
        
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