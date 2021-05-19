using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public Department Department { get; set; }
        public List<Professor> Professores { get; set; } = new List<Professor>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
