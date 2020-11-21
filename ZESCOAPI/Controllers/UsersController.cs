using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZESCOAPI.Models;

namespace ZESCOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

///11111-  https://localhost:44362/api/users
        [HttpPost]
        public ActionResult<User> Post(User studentY)
        {
            _context.Users.Add(studentY);
            _context.SaveChanges();
            return Ok(studentY);
        }

//2222/-  https://localhost:44362/api/users
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(_context.Users.ToList());
        }

///2222- https://localhost:44362/api/users/1
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var studX = _context.Users.FirstOrDefault(a => a.id == id);
            return Ok(studX);
        }

///33333-  https://localhost:44362/api/users/1

         [HttpPut("{id}")]
        public ActionResult<User> Put(User studentY)
        {
            var studX = _context.Users.FirstOrDefault(a => a.id == studentY.id);
            studX.Name = studentY.Name;
            studX.Email = studentY.Email;
            studX.Document = studentY.Document;
            studX.Phone = studentY.Phone;
        _context.SaveChanges();
            return Ok(studentY);
        }

////44444-  https://localhost:44362/api/users/1

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var studeZ = _context.Users.FirstOrDefault(a => a.id == id);
            _context.Users.Remove(studeZ);
            _context.SaveChanges();
            return Ok(studeZ);
        }
    }
}
