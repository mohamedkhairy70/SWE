using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class Evaluation : BaseClass
    {
        public int Id { get; set; }
        public List<StudentLog> StudentLog { get; set; } = new List<StudentLog>();
        public List<Professor> Professors { get; set; } = new List<Professor>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public double Resualt { get; set; }
    }
}
