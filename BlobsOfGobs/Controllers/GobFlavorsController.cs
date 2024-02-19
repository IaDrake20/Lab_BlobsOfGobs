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
        public async Task<ActionResult<IEnumerable<GobFlavors>>> GetGobFlavors_1()
        {
            return await _context.GobFlavors.ToListAsync();
        }

        // GET: api/GobFlavors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GobFlavors>> GetGobFlavors(string id)
        {
            var gobFlavors = await _context.GobFlavors.FindAsync(id);

            if (gobFlavors == null)
            {
                return NotFound();
            }

            return gobFlavors;
        }

        // PUT: api/GobFlavors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGobFlavors(string id, GobFlavors gobFlavors)
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
            _context.GobFlavors.Add(gobFlavors);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GobFlavorsExists(gobFlavors.FlavorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGobFlavors", new { id = gobFlavors.FlavorID }, gobFlavors);
        }

        // DELETE: api/GobFlavors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGobFlavors(string id)
        {
            var gobFlavors = await _context.GobFlavors.FindAsync(id);
            if (gobFlavors == null)
            {
                return NotFound();
            }

            _context.GobFlavors.Remove(gobFlavors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GobFlavorsExists(string id)
        {
            return _context.GobFlavors.Any(e => e.FlavorID == id);
        }
    }
}
