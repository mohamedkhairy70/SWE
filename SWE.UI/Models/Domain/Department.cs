using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class Department
    {
        public Department()
        {
            Professores = new List<Professor>();
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public Facultie Facultie { get; set; }
        public List<Professor> Professores { get; set; }
        public List<Course> Courses { get; set; }
    }
}
