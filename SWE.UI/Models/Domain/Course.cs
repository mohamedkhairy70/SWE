using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class Course
    {
        public Course()
        {
            Professores = new List<Professor>();
            Students = new List<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public Department Department { get; set; }
        public ICollection<Professor> Professores { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
