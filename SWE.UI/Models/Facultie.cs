using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class Facultie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new ();
    }
}
