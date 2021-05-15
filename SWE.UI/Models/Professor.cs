﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWE.UI.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BDate { get; set; }
        public Department Department { get; set; }
        public List<Course> Course { get; set; }
    }
}
