﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public List<Professor> Professores { get; set; }
        public List<Student> Students { get; set; }
    }
}
