using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWE.UI.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Leval { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsDelete { get; set; }
        [DataType(DataType.Date)]
        public DateTime BDate { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        [ForeignKey("StudentLog")]
        public string StudentLogUserName { get; set; }
        public StudentLog StudentLog { get; set; }
    }
}
