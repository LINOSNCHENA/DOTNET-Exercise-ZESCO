using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZESCOAPI.Models
{
     public class User
    {
      //  internal readonly object id;

        //// public int id { get; set; }
        public int id { get; internal set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
    }
}
