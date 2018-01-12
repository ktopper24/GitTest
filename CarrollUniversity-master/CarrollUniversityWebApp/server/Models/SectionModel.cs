using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrollUniversityWebApp.server.Models
{
    public class SectionModel
    {
        public String Course_Name { get; set; }
        public int Course_Database_ID { get; set; }
        public string Section_Name { get; set; }
        public string Professor_Name { get; set; }
        public TimeSpan Time { get; set; }
        public string Building_Name { get; set; }
        public int Building_ID { get; set; }
        public int Section_ID { get; set; }
    }
}