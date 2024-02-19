using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_BlobsOfGobs;
using API_BlobsOfGobs.Models;

namespace API_BlobsOfGobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GobsController : ControllerBase
    {
        private readonly BlobsOfGobsContext _context;

        public GobsController(BlobsOfGobsContext context)
        {
            _context = context;
        }

        // GET: api/Gobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gob>>> GetGob()
        {
            return await _context.Gob.ToListAsync();
        }

        // GET: api/Gobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gob>> GetGob(Guid id)
        {
            var gob = await _context.Gob.FindAsync(id);

            if (gob == null)
            {
                return NotFound();
            }

            return gob;
        }

        // PUT: api/Gobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGob(Guid id, Gob gob)
        {
            if (id != gob.Id)
            {
                return BadRequest();
            }

            _context.Entry(gob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GobExists(id))
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

        // POST: api/Gobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gob>> PostGob(Gob gob)
        {
            _context.Gob.Add(gob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGob", new { id = gob.Id }, gob);
        }

        // DELETE: api/Gobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGob(Guid id)
        {
            var gob = await _context.Gob.FindAsync(id);
            if (gob == null)
            {
                return NotFound();
            }

            _context.Gob.Remove(gob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GobExists(Guid id)
        {
            return _context.Gob.Any(e => e.Id == id);
        }
    }
}
