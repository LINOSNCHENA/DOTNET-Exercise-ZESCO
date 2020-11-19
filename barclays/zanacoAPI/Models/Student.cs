using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zanacoAPI.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Rollno { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public int id { get; internal set; }
    }
}
