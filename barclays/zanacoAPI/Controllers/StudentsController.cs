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
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {    private readonly DatabaseContext _context;
        public StudentsController(DatabaseContext context)
        {
            _context = context;
        }

// POST #1
//https://localhost:44357/Students/studentAddition

        [Route("StudentAddition")]
        [HttpPost]
        public ActionResult<Student> Post(Student employee)
        {
            _context.Students.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

//  GET #2
// https://localhost:44357/students/studentdetails

        [Route("StudentDetails")]
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            var b = _context.Students.ToList();
            return Ok(b);
        }

//  GET ONE #3
//  https://localhost:44357/students/StudentDetailById
       
     //   [Route("StudentDetailById")]
     //     https://localhost:44357/students/studentdetails/4

         [Route("StudentDetails/{id}")]
        [HttpGet]
        public ActionResult<List<Student>> Get(int id)
        {
            var zed3 = _context.Students.FirstOrDefault(x => x.id == id);
            return Ok(zed3);
        }

/// https://localhost:44357/students/1
// DELETE #4
            [HttpDelete("StudentDelete/{id}")]
        public ActionResult<Student> Delete(int id)
        {
            var employeeInDb = _context.Students.FirstOrDefault(a => a.id == id);
            _context.Students.Remove(employeeInDb);
            _context.SaveChanges();
            return Ok(employeeInDb);
        }

//  https://localhost:44357/students/DeleteStudent
//  DELETE #5
 
        [Route("StudentUpdate")]
        [HttpPut]
        public ActionResult<Student> Put(Student employee)
        {
            var employeeInDb = _context.Students.FirstOrDefault(a => a.id == employee.id);
            employeeInDb.Name = employee.Name;
            employeeInDb.Rollno = employee.Rollno;
            employeeInDb.Class = employee.Class;
            employeeInDb.Address = employee.Address;                       
        _context.SaveChanges();
            return Ok(employee);
        }
////////////////////////////////////////////////////////////////////////////////////////////
    }
}
