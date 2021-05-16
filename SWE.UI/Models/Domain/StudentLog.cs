using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class StudentLog
    {
        public StudentLog()
        {
            Student = new Student();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Student Student { get; set; }
    }
}
