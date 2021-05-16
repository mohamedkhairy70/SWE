using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class Evaluation
    {
        public Evaluation()
        {
            StudentLog = new List<StudentLog>();
            Professors = new List<Professor>();
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public ICollection<StudentLog> StudentLog { get; set; }
        public ICollection<Professor> Professors { get; set; }
        public ICollection<Course> Courses { get; set; }
        public double Resualt { get; set; }
    }
}
