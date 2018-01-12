using CarrollUniversityWebApp.server.Models;
using CarrollUniversityWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarrollUniversityWebApp.server.Controllers
{
    public class SectionController : ApiController
    {
        // POST api/section
        [HttpPost]
        public void Post([FromBody]SectionModel section)
        {
            var dbm = new DatabaseManager();
            dbm.AddSection(section.Section_Name, section.Course_Database_ID, section.Building_ID, section.Time);
        }


        // GET api/section/Course_Database_ID
        [HttpGet]
        public SectionModel[] Get(int id)
        {
            var dbm = new DatabaseManager();
            var sectionList = dbm.GetSections(id);

            return sectionList.ToArray();
        }


    }
}