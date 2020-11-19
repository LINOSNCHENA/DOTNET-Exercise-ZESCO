using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zanacoAPI.Models;

namespace zanacoAPI.Controllers
{

    // [Route("Api/Student")]

    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase

    {
            private readonly DatabaseContext _context;

            public StudentsController(DatabaseContext context)
            {
                _context = context;
            }


       [Route("Studentdetails")]
        [HttpGet]
                 public ActionResult<List<Student>> Get()
        {
      
            var b = _context.Student.ToList();
            return Ok(b);
        }


        [Route("AddotrUpdatestudent")]
        [HttpPost]
        public ActionResult<Student> Post(Student employee)
        {
            _context.Student.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }




        [Route("StudentdetailById")]
        [HttpGet]
         public ActionResult<List<Student>> Get(int id)
        {

            var zed3 = _context.Student.FirstOrDefault(x => x.id == id);
            return Ok(zed3);
        }

        [Route("Deletestudent")]
        [HttpDelete]
        public object Deletestudent(int id)
        {
            var emp4 = _context.Student.FirstOrDefault(a => a.id == id);
            _context.Student.Remove(emp4);
            _context.SaveChanges();

            return new Response
            {
                Status = "Delete",
                Message = "Delete Successfuly"
            };
        }
    }
}
