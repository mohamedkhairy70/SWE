using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Facultie Facultie { get; set; }
        public List<Professor> Professor { get; set; } = new ();
        public List<Course> Course { get; set; } = new();
    }
}
