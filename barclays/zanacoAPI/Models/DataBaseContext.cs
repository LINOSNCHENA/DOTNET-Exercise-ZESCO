using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zanacoAPI.Models
{
   

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Student { get; set; }

        internal void SaveChanges1()
        {
            throw new NotImplementedException();
        }
    }


}
