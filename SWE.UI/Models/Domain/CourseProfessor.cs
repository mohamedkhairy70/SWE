using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models.Domain
{
    public class CourseProfessor
    {
        public int CourseId { get; set; }
        public int ProfessorId { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
