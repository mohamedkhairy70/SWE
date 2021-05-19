using System;
using System.Collections.Generic;

namespace SWE.UI.Models.Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsDelete { get; set; }
        public DateTime BDate { get; set; }
        public Department DepartmentProfessor { get; set; }
        public int? ProfessorManageId { get; set; }
        public Professor ProfessorManage { get; set; }
        public int? DepartmentsId { get; set; }
        public Department Department { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
