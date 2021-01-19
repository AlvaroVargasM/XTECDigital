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


        /// <summary>
        /// wipesTheTempFolder
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Saves to temp folder
        /// </summary>
        /// <param name="file">File</param>
        /// <returns>Successful</returns>
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

        /// <summary>
        /// GetsFileFromTempFolder
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <param name="format">File format</param>
        /// <returns></returns>
        public static FileStream getFileFromTempFolder(string filename, string format)
        {
            return File.Open(testFolderPath + '/' + filename + '.' + format, FileMode.Open);
        }

        /// <summary>
        /// Gets a file from a group folder
        /// </summary>
        /// <param name="groupCode">Code for group</param>
        /// <param name="groupNumber">Number for group</param>
        /// <param name="yearSemester">Year for semester</param>
        /// <param name="periodSemester">Period for semester</param>
        /// <param name="subfolders">Folders hierarchy</param>
        /// <param name="filename">Filename</param>
        /// <returns>Filestream to file</returns>
        public static FileStream getFileFromGroupFolder(string groupCode, string groupNumber, string yearSemester, string periodSemester, string[] subfolders, string filename)
        {
            string groupFolder = groupCode + '_' + groupNumber + '_' + yearSemester + '_' + periodSemester;

            foreach (string folder in subfolders)
            {
                groupFolder += '/' + folder;
            }

            return File.Open(fileManagerRoot + '/' + groupFolder + '/' + filename, FileMode.Open);
        }

        /// <summary>
        /// Saves a file to a group folder
        /// </summary>
        /// <param name="file">File</param>
        /// <param name="groupCode">Code for group</param>
        /// <param name="groupNumber">Number for group</param>
        /// <param name="yearSemester">Year for semester</param>
        /// <param name="periodSemester">Period for semester</param>
        /// <param name="subfolders">Folders hierarchy</param>
        /// <returns>Successful</returns>
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
        
        /// <summary>
        /// Builds up the database
        /// </summary>
        /// <returns>Buildup successfully</returns>
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
        
        /// <summary>
        /// checksForExistece of a folder
        /// </summary>
        /// <param name="path">Path to folder</param>
        /// <returns>Whether or not found</returns>
        public static bool checkExistence(string path)
        {
            if (Directory.Exists(fileManagerRoot))
            {
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Creates a new directory for group
        /// </summary>
        /// <param name="groupID"></param>
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
        
        /// <summary>
        /// Creates root folder for a group 
        /// </summary>
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