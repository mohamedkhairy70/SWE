using System;
using System.Collections.Generic;

namespace SWE.UI.Models.Domain
{
    public class Professor
    {
        public Professor()
        {
            Courses = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsDelete { get; set; }
        public DateTime BDate { get; set; }
        public Professor ProfessorManage { get; set; }
        public Department DepartmentProfessor { get; set; }
        public Department Department { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
