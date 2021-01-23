using RelationalDB_RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Utils
{
    public static class Connector
    {
        public static string connectionString = "Data Source=dxnium.database.windows.net,1433; " +
            "Network Library = DBMSSOCN; Initial Catalog = XTECDigital; " +
            "User ID = dxnium; Password=Dumanamonge9921";

        /// <summary>
        /// Gets all the semester
        /// </summary>
        /// <returns>Gets all semesters</returns>
        public static List<Semester> getSemesters()
        {
            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command =
                            new SqlCommand("GetAllSemesters", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Semester> semesters = new List<Semester>();

                    while (reader.Read())
                    {
                        semesters.Add(new Semester((int)reader["year"], (string)reader["period"]));
                    }

                    connection.Close();

                    return semesters;
                }
                catch (Exception)
                {
                    connection.Close();
                    return null;
                }
            }


        }

        /// <summary>
        /// Gets all courses
        /// </summary>
        /// <returns>All courses</returns>
        public static List<Course> getCourses()
        {
            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command =
                            new SqlCommand("GetAllCourses", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Course> courses = new List<Course>();

                    while (reader.Read())
                    {
                        courses.Add(new Course((string)reader["code"], (string)reader["name"], (int)reader["credits"], (string)reader["school"]));
                    }

                    connection.Close();

                    return courses;
                }
                catch (Exception)
                {
                    connection.Close();
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets all groups
        /// </summary>
        /// <returns>All groups</returns>
        public static List<Group> getGroups()
        {
            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command =
                            new SqlCommand("GetAllGroups", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Group> groups = new List<Group>();

                    while (reader.Read())
                    {
                        groups.Add(new Group((int)reader["number"], (int)reader["year_semester"], (string)reader["period_semester"], (string)reader["code_course"],
                            (string)reader["path"]));
                    }

                    connection.Close();

                    return groups;
                }
                catch (Exception)
                {
                    connection.Close();
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets all groups belonging to semester
        /// </summary>
        /// <param name="year">Semester year</param>
        /// <param name="period">Semester Period</param>
        /// <returns>All groups belonging to a semester</returns>
        public static List<Group> getGroupsBySemester(int year, string period)
        {
            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command =
                            new SqlCommand("GetAllGroupsBySemester", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("year", year);
                    command.Parameters.AddWithValue("period", period);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Group> groups = new List<Group>();

                    while (reader.Read())
                    {
                        groups.Add(new Group((int)reader["number"], (int)reader["year_semester"], (string)reader["period_semester"], (string)reader["code_course"],
                            (string)reader["path"]));
                    }

                    connection.Close();

                    return groups;
                }
                catch (Exception)
                {
                    connection.Close();
                    return null;
                }
            }
        }

        /// <summary>
        /// GetsGroupsByProfessor
        /// </summary>
        /// <param name="ssn">Professor's SSN</param>
        /// <returns>All groups by professor</returns>
        public static List<Group> getGroupsByProfesor(string ssn)
        {
            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command =
                            new SqlCommand("GetGroupsByProfessor", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("professorSSN", ssn);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Group> groups = new List<Group>();

                    while (reader.Read())
                    {
                        groups.Add(new Group((int)reader["number_group"], (int)reader["year_semester"], (string)reader["period_semester"], (string)reader["code_course"],
                            "None"));
                    }

                    connection.Close();

                    return groups;
                }
                catch (Exception)
                {
                    connection.Close();
                    return null;
                }
            }
        }

        /// <summary>
        /// Creates a course in the database
        /// </summary>
        /// <param name="code">Code for course</param>
        /// <param name="name">Name for course</param>
        /// <param name="credits">Credits for course</param>
        /// <param name="school">School for course</param>
        /// <returns>Whether or not successful</returns>
        public static bool createCourse(string code, string name, int credits, string school)
        {
            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command =
                                        new SqlCommand("CreateCourse", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("code", code);
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("credits", credits);
                    command.Parameters.AddWithValue("school", school);
                    connection.Open();

                    bool result = (bool)command.ExecuteScalar();

                    return result;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Initializes semester based on a semester object and data table containing data for completion
        /// </summary>
        /// <param name="semester">Semester Object for year and period</param>
        /// <param name="initialization">Datatable containing semester information</param>
        /// <returns>bool whether or not the server completed the request successfully</returns>
        public static bool SemesterInitialization(Semester semester, DataTable initialization)
        {
            using (SqlConnection connection =
                  new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command =
                                        new SqlCommand("InitializeSemester", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("year", semester.year);
                    command.Parameters.AddWithValue("period", semester.period);
                    command.Parameters.AddWithValue("data", initialization);
                    connection.Open();

                    bool result = (bool)command.ExecuteScalar();

                    return result;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}