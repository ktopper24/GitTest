using CarrollUniversityWebApp.server.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarrollUniversityWebApp.Utils
{
    public class DatabaseManager
    {
        SqlConnection sqlConnection1;

        public DatabaseManager()
        {
            sqlConnection1 = new SqlConnection("Data Source=KAYLA\\SQLEXPRESS;Initial Catalog=Carroll_University;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        private SqlDataReader GetDatabaseResults(string query)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.
            return reader;
        }

        private void PostDatabaseResult(string update)
        {
            SqlCommand cmd = new SqlCommand(update, sqlConnection1);
            sqlConnection1.Open();
            cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }
        public IEnumerable<StudentModel> GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            sqlConnection1.Open();
            var reader = GetDatabaseResults("SELECT * FROM STUDENTS");
            
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    var First_Name = reader.GetString(0);
                    var Last_Name = reader.GetString(1);
                    var User = reader.GetString(3);
                    var Password = reader.GetString(4);
                    var student = new StudentModel { First_Name = First_Name, Last_Name = Last_Name, User = User, Password = Password };
                    students.Add(student);
                }
            }

            sqlConnection1.Close();

            return students;
        }

        public IEnumerable<CourseModel> GetAllCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            sqlConnection1.Open();
            var reader = GetDatabaseResults("SELECT Courses.Course_Name, Professors.Professor_Name, Courses.Course_Database_ID FROM Courses JOIN Professors ON Professors.Professor_ID = Courses.Professor_ID");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Course_Name = reader.GetString(0);
                    var Professor_Name = reader.GetString(1);
                    var Course_Database_ID = reader.GetInt32(2);
                    var course = new CourseModel { Course_Name = Course_Name, Professor_Name = Professor_Name, Course_Database_ID = Course_Database_ID};
                    courses.Add(course);
                }
            }

            sqlConnection1.Close();

            return courses;
        }

        public IEnumerable<SectionModel> GetSections(int Course_Database_ID)
        {
            List<SectionModel> sections = new List<SectionModel>();
            sqlConnection1.Open();
            var reader = GetDatabaseResults("SELECT Sections.Section_Name, Sections.Section_ID, Sections.Time, Buildings.Building_Name FROM Sections JOIN Buildings ON Sections.Building_ID = Buildings.Building_ID WHERE Course_Database_ID='" + Course_Database_ID + "'");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Section_Name = reader.GetString(0);
                    var Section_ID = reader.GetInt32(1);
                    var Time = reader.GetTimeSpan(2);
                    var Building_Name = reader.GetString(3);
                    var section = new SectionModel { Section_Name = Section_Name, Section_ID = Section_ID, Time = Time, Building_Name = Building_Name };
                    sections.Add(section);
                }
            }

            sqlConnection1.Close();

            return sections;
        }

        public void AddStudent(string First_Name, string Last_Name, string User, string Password)
        {
            var queryString = string.Format("INSERT INTO Students (First_Name, Last_Name, username, password) VALUES('{0}', '{1}', '{2}', '{3}')",
                First_Name, Last_Name, User, Password);

            PostDatabaseResult(queryString);
        }

        public void AddCourse(string Course_Name, string Course_Catalog_ID, int Professor_ID)
        {
            var queryString = string.Format("INSERT INTO Courses (Course_Name, Course_Catalog_ID, Professor_ID) VALUES('{0}', '{1}', '{2}')",
                Course_Name, Course_Catalog_ID, Professor_ID);

            PostDatabaseResult(queryString);
        }

        public void AddProfessor(string Name, string username, string password)
        {
            var queryString = string.Format("INSERT INTO Professors (Professor_Name, username, password) VALUES('{0}', '{1}', '{2}')",
                Name, username, password);

            PostDatabaseResult(queryString);
        }

        public void AddBuilding(string Building_Name)
        {
            var queryString = string.Format("INSERT INTO Buildings (Building_Name) VALUES('{0}')",
                Building_Name);

            PostDatabaseResult(queryString);
        }

        public void SignUp(int id, int id2)
        {
            var queryString = string.Format("INSERT INTO Student_Sections (Student_ID, Section_ID) VALUES('{0}', '{1}')",
                id, id2);

            PostDatabaseResult(queryString);
        }

        public StudentModel GetStudentUser(string username)
        {
            var queryString = string.Format("SELECT First_Name, Last_Name, Student_ID, username, password FROM Students WHERE username = '{0}'", username);
            var student = new StudentModel();
           
            sqlConnection1.Open();

            var reader = GetDatabaseResults(queryString);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var First_Name = reader.GetString(0);
                    var Last_Name = reader.GetString(1);
                    var Student_ID = reader.GetInt32(2);
                    var User = reader.GetString(3);
                    var Password = reader.GetString(4);
                    student = new StudentModel { First_Name = First_Name, Last_Name = Last_Name, Student_ID = Student_ID, User = User, Password = Password };
                }
            }

            sqlConnection1.Close();

            return student;
        }

        public IEnumerable<SectionModel> GetStudentCourses(int id)
        {
            List<SectionModel> studentSections = new List<SectionModel>();
            var queryString = string.Format("SELECT Courses.Course_Name, Professors.Professor_Name, Sections.Section_Name, Sections.Time, Buildings.Building_Name FROM Sections JOIN Buildings ON Sections.Building_ID = Buildings.Building_ID JOIN Courses ON Sections.Course_Database_ID = Courses.Course_Database_ID JOIN Professors ON Professors.Professor_ID = Courses.Professor_ID JOIN Student_Sections ON Sections.Section_ID = Student_Sections.Section_ID WHERE Student_Sections.Student_ID = {0}", id);
            sqlConnection1.Open();
            var reader = GetDatabaseResults(queryString);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Course_Name = reader.GetString(0);
                    var Professor_Name = reader.GetString(1);
                    var Section_Name = reader.GetString(2);
                    var Time = reader.GetTimeSpan(3);
                    var Building_Name = reader.GetString(4);
                    var section = new SectionModel { Course_Name = Course_Name, Professor_Name = Professor_Name, Section_Name = Section_Name, Time = Time, Building_Name = Building_Name };
                    studentSections.Add(section);
                }
            }

            sqlConnection1.Close();

            return studentSections;
        }

        public IEnumerable<BuildingModel> GetAllBuildings()
        {
            List<BuildingModel> buildings = new List<BuildingModel>();
            sqlConnection1.Open();
            var reader = GetDatabaseResults("SELECT Building_Name, Building_ID FROM Buildings");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Building_Name = reader.GetString(0);
                    var Building_ID = reader.GetInt32(1);
                    var building = new BuildingModel { Building_Name = Building_Name, Building_ID = Building_ID };
                    buildings.Add(building);
                }
            }

            sqlConnection1.Close();

            return buildings;
        }

        public void AddSection(string Section_Name, int Course_Database_ID, int Building_ID, TimeSpan Time)
        {
            var queryString = string.Format("INSERT INTO Sections (Section_Name, Course_Database_ID, Building_ID, Time) VALUES('{0}', {1}, {2}, '{3}')",
                Section_Name, Course_Database_ID, Building_ID, Time);

            PostDatabaseResult(queryString);
        }

        public IEnumerable<ProfessorModel> GetAllProfessors()
        {
            List<ProfessorModel> professors = new List<ProfessorModel>();
            sqlConnection1.Open();
            var reader = GetDatabaseResults("SELECT Professor_Name, Professor_ID FROM Professors");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Professor_Name = reader.GetString(0);
                    var Professor_ID = reader.GetInt32(1);
                    var professor = new ProfessorModel { Professor_Name = Professor_Name, Professor_ID = Professor_ID };
                    professors.Add(professor);
                }
            }

            sqlConnection1.Close();

            return professors;
        }

        public ProfessorModel GetProfessorUser(string username)
        {
            var queryString = string.Format("SELECT Professor_Name, Professor_ID, username, password FROM Professors WHERE username = '{0}'", username);
            var professor = new ProfessorModel();

            sqlConnection1.Open();

            var reader = GetDatabaseResults(queryString);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Professor_Name = reader.GetString(0);
                    var Professor_ID = reader.GetInt32(1);
                    var user = reader.GetString(2);
                    var password = reader.GetString(3);
                    professor = new ProfessorModel { Professor_Name = Professor_Name, Professor_ID = Professor_ID, username = user, password = password};
                }
            }

            sqlConnection1.Close();

            return professor;
        }

        public IEnumerable<SectionModel> GetProfessorCourses(int id2)
        {
            List<SectionModel> professorSections = new List<SectionModel>();
            var queryString = string.Format("SELECT Courses.Course_Name, Professors.Professor_Name, Sections.Section_Name, Sections.Time, Buildings.Building_Name FROM Sections JOIN Buildings ON Sections.Building_ID = Buildings.Building_ID JOIN Courses ON Sections.Course_Database_ID = Courses.Course_Database_ID JOIN Professors ON Professors.Professor_ID = Courses.Professor_ID WHERE Professors.Professor_ID = {0}", id2);
            sqlConnection1.Open();
            var reader = GetDatabaseResults(queryString);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var Course_Name = reader.GetString(0);
                    var Professor_Name = reader.GetString(1);
                    var Section_Name = reader.GetString(2);
                    var Time = reader.GetTimeSpan(3);
                    var Building_Name = reader.GetString(4);
                    var section = new SectionModel { Course_Name = Course_Name, Professor_Name = Professor_Name, Section_Name = Section_Name, Time = Time, Building_Name = Building_Name };
                    professorSections.Add(section);
                }
            }

            sqlConnection1.Close();

            return professorSections;
        }
    }
}