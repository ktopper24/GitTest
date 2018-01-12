using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarrollUniversityWebApp.server.Models;
using CarrollUniversityWebApp.Utils;

namespace CarrollUniversityWebApp.server.Controllers
{
    public class CourseController : ApiController
    {


        // POST api/course
        [HttpPost]
        public void Post([FromBody]CourseModel course)
        {
            var dbm = new DatabaseManager();
            dbm.AddCourse(course.Course_Name, course.Course_Catalog_ID, course.Professor_ID);
        }

        // GET api/course
        [HttpGet]
        public CourseModel[] Get()
        {
            var dbm = new DatabaseManager();
            var courseList = dbm.GetAllCourses();

            return courseList.ToArray();
        }

        //api/section/studentid
        [HttpGet]
        public SectionModel[] Get(int id)
        {
            var dbm = new DatabaseManager();
            var studentCourses = dbm.GetStudentCourses(id);

            return studentCourses.ToArray();

        }

        //api/section/0/studentid
        [HttpGet]
        public SectionModel[] Get(int id, int id2)
        {
            var dbm = new DatabaseManager();
            var professorCourses = dbm.GetProfessorCourses(id2);

            return professorCourses.ToArray();

        }
    }
}
