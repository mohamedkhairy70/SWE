using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SWE.Models
{
    public class Student
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Leval { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BDate { get; set; }
        public List<Course> Course { get; set; }
    }
}
