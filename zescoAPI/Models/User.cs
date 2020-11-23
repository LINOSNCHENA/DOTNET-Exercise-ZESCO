using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZESCOAPI.Models
{
     public class User
    {
       public int id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Stars { get; set; }
    }
}
