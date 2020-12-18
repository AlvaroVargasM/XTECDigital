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
        public static string connectionString = "Data Source=jongs.mynetgear.com,1433; " +
            "Network Library = DBMSSOCN; Initial Catalog = XTecDigital-db; " +
            "User ID = REST-1; Password=fVmOwUzSOd{n4#Ltf";

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
    }
}