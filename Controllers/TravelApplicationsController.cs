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
    public class TravelApplicationsController : ControllerBase
    {
        private readonly DataContext _context;

        public TravelApplicationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TravelApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelApplication>>> GetTravelApplications()
        {
          if (_context.TravelApplications == null)
          {
              return NotFound();
          }
            return await _context.TravelApplications.ToListAsync();
        }

        // GET: api/TravelApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelApplication>> GetTravelApplication(Guid id)
        {
          if (_context.TravelApplications == null)
          {
              return NotFound();
          }
            var travelApplication = await _context.TravelApplications.FindAsync(id);

            if (travelApplication == null)
            {
                return NotFound();
            }

            return travelApplication;
        }

        // PUT: api/TravelApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelApplication(Guid id, TravelApplication travelApplication)
        {
            if (id != travelApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(travelApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelApplicationExists(id))
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

        // POST: api/TravelApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelApplication>> PostTravelApplication(TravelApplication travelApplication)
        {
          if (_context.TravelApplications == null)
          {
              return Problem("Entity set 'DataContext.TravelApplications'  is null.");
          }
            _context.TravelApplications.Add(travelApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelApplication", new { id = travelApplication.Id }, travelApplication);
        }

        // DELETE: api/TravelApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelApplication(Guid id)
        {
            if (_context.TravelApplications == null)
            {
                return NotFound();
            }
            var travelApplication = await _context.TravelApplications.FindAsync(id);
            if (travelApplication == null)
            {
                return NotFound();
            }

            _context.TravelApplications.Remove(travelApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelApplicationExists(Guid id)
        {
            return (_context.TravelApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
