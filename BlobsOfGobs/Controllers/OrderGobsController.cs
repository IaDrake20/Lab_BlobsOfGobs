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
    public class OrderGobsController : ControllerBase
    {
        private readonly BlobsOfGobsContext _context;

        public OrderGobsController(BlobsOfGobsContext context)
        {
            _context = context;
        }

        // GET: api/OrderGobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGob>>> GetOrderGob()
        {
            return await _context.OrderGob.ToListAsync();
        }

        // GET: api/OrderGobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGob>> GetOrderGob(Guid id)
        {
            var orderGob = await _context.OrderGob.FindAsync(id);

            if (orderGob == null)
            {
                return NotFound();
            }

            return orderGob;
        }

        // PUT: api/OrderGobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderGob(Guid id, OrderGob orderGob)
        {
            if (id != orderGob.OrderGobID)
            {
                return BadRequest();
            }

            _context.Entry(orderGob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderGobExists(id))
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

        // POST: api/OrderGobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderGob>> PostOrderGob(OrderGob orderGob)
        {
            _context.OrderGob.Add(orderGob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderGob", new { id = orderGob.OrderGobID }, orderGob);
        }

        // DELETE: api/OrderGobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderGob(Guid id)
        {
            var orderGob = await _context.OrderGob.FindAsync(id);
            if (orderGob == null)
            {
                return NotFound();
            }

            _context.OrderGob.Remove(orderGob);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderGobExists(Guid id)
        {
            return _context.OrderGob.Any(e => e.OrderGobID == id);
        }
    }
}
