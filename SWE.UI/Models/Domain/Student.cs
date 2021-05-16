using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SWE.UI.Models.Domain
{
    public class Student : BaseClass
    {
        public string FullName { get; set; }
        public string Leval { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BDate { get; set; }
        public List<Course> Courses { get; set; }
    }
}
