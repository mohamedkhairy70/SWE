using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class Facultie
    {
        public Facultie()
        {
            Departments = new List<Department>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
