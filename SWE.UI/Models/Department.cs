using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Facultie Facultie { get; set; }
        public List<Professor> Professores { get; set; } = new ();
        public List<Course> Courses { get; set; } = new();
    }
}
