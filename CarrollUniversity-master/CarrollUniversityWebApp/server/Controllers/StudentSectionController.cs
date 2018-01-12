using CarrollUniversityWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarrollUniversityWebApp.server.Controllers
{
    public class StudentSectionController : ApiController
    {
        // POST api/studentsection/StudentID/SectionID
        [HttpPost]
        public void Post(int id, int id2)
        {
            {
                var dbm = new DatabaseManager();
                dbm.SignUp(id, id2);
            }
        }
    }
}