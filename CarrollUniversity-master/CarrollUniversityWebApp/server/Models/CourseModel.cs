using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrollUniversityWebApp.server.Models
{
    public class CourseModel
    {
        public string Course_Name { get; set; }
        public string Course_Catalog_ID { get; set; }
        public string Professor_Name { get; set; }
        public int Professor_ID { get; set; }
        public int Course_Database_ID { get; set; }
    }
}