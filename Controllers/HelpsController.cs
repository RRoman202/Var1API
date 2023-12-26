using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using Var1API.Data;

namespace Var1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpsController : ControllerBase
    {
        private readonly DataContext _context;

        public HelpsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Helps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Help>>> GetHelps()
        {
          if (_context.Helps == null)
          {
              return NotFound();
          }
            return await _context.Helps.ToListAsync();
        }

        // GET: api/Helps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Help>> GetHelp(Guid id)
        {
          if (_context.Helps == null)
          {
              return NotFound();
          }
            var help = await _context.Helps.FindAsync(id);

            if (help == null)
            {
                return NotFound();
            }

            return help;
        }

        // PUT: api/Helps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelp(Guid id, Help help)
        {
            if (id != help.Id)
            {
                return BadRequest();
            }

            _context.Entry(help).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HelpExists(id))
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

        // POST: api/Helps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Help>> PostHelp(Help help)
        {
          if (_context.Helps == null)
          {
              return Problem("Entity set 'DataContext.Helps'  is null.");
          }
            _context.Helps.Add(help);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHelp", new { id = help.Id }, help);
        }

        // DELETE: api/Helps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelp(Guid id)
        {
            if (_context.Helps == null)
            {
                return NotFound();
            }
            var help = await _context.Helps.FindAsync(id);
            if (help == null)
            {
                return NotFound();
            }

            _context.Helps.Remove(help);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HelpExists(Guid id)
        {
            return (_context.Helps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
