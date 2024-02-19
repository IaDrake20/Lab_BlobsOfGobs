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
    public class GobFlavorsController : ControllerBase
    {
        private readonly BlobsOfGobsContext _context;

        public GobFlavorsController(BlobsOfGobsContext context)
        {
            _context = context;
        }

        // GET: api/GobFlavors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GobFlavors>>> GetGob()
        {
            return await _context.Gob.ToListAsync();
        }

        // GET: api/GobFlavors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GobFlavors>> GetGobFlavors(Guid id)
        {
            var gobFlavors = await _context.Gob.FindAsync(id);

            if (gobFlavors == null)
            {
                return NotFound();
            }

            return gobFlavors;
        }

        // PUT: api/GobFlavors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGobFlavors(Guid id, GobFlavors gobFlavors)
        {
            if (id != gobFlavors.FlavorID)
            {
                return BadRequest();
            }

            _context.Entry(gobFlavors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GobFlavorsExists(id))
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

        // POST: api/GobFlavors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GobFlavors>> PostGobFlavors(GobFlavors gobFlavors)
        {
            _context.Gob.Add(gobFlavors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGobFlavors", new { id = gobFlavors.FlavorID }, gobFlavors);
        }

        // DELETE: api/GobFlavors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGobFlavors(Guid id)
        {
            var gobFlavors = await _context.Gob.FindAsync(id);
            if (gobFlavors == null)
            {
                return NotFound();
            }

            _context.Gob.Remove(gobFlavors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GobFlavorsExists(Guid id)
        {
            return _context.Gob.Any(e => e.FlavorID == id);
        }
    }
}
