using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class Department : BaseClass
    {
        public string Name { get; set; }
        public Facultie Facultie { get; set; }
        public HashSet<List<Professor>> Professores { get; set; } = new ();
        public HashSet<List<Course>> Courses { get; set; } = new();
    }
}
