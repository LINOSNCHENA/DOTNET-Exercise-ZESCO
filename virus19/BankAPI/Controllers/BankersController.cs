using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankersController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public BankersController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/Banker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banker>>> GetBankers()
        {
            return await _context.Bankers.ToListAsync();
        }

        // GET: api/Banker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banker>> GetBanker(int id)
        {
            var bankerX = await _context.Bankers.FindAsync(id);

            if (bankerX == null)
            {
                return NotFound();
            }

            return bankerX;
        }

        // PUT: api/Banker/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanker(int id, Banker bankerX)
        {
            bankerX.id = id;

            _context.Entry(bankerX).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Banker
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Banker>> PostBanker(Banker bankerX)
        {
            _context.Bankers.Add(bankerX);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanker", new { id = bankerX.id }, bankerX);
        }

        // DELETE: api/Banker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banker>> DeleteBanker(int id)
        {
            var bankerX = await _context.Bankers.FindAsync(id);
            if (bankerX == null)
            {
                return NotFound();
            }

            _context.Bankers.Remove(bankerX);
            await _context.SaveChangesAsync();

            return bankerX;
        }

        private bool BankerExists(int id)
        {
            return _context.Bankers.Any(e => e.id == id);
        }
    }
}
