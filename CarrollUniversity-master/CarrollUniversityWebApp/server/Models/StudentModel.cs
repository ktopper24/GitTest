using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrollUniversityWebApp.server.Models
{
    public class StudentModel
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Student_ID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}