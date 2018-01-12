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
    public class ProfessorController : ApiController
    {
        // POST api/professor
        [HttpPost]
        public void Post([FromBody]ProfessorModel professor)
        {
            {
                var dbm = new DatabaseManager();
                dbm.AddProfessor(professor.Professor_Name, professor.username, professor.password);
            }
        }

        // GET api/professor
        [HttpGet]
        public ProfessorModel[] Get()
        {
            var dbm = new DatabaseManager();
            var professorList = dbm.GetAllProfessors();

            return professorList.ToArray();

        }

        // GET api/student?username=username
        [HttpGet]
        public ProfessorModel Get(string username)
        {
            var dbm = new DatabaseManager();
            var professor = dbm.GetProfessorUser(username);

            return professor;

        }
    }
}
