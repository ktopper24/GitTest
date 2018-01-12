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
    public class StudentController : ApiController
    {
        // POST api/student
        [HttpPost]
        public void Post([FromBody]StudentModel student)
        {
            var dbm = new DatabaseManager();
            dbm.AddStudent(student.First_Name, student.Last_Name, student.User, student.Password);
        }

        // GET api/student
        [HttpGet]
        public StudentModel[] Get()
        {
            var dbm = new DatabaseManager();
            var studentList = dbm.GetAllStudents();

            return studentList.ToArray();

        }

        // GET api/student?username=username
        [HttpGet]
        public StudentModel Get(string username)
        {
            var dbm = new DatabaseManager();
            var student = dbm.GetStudentUser(username);

            return student;

        }


    }
}
