using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesOrdersController : ControllerBase
    {
        private readonly WebStoreContext _context;

        public ClothesOrdersController(WebStoreContext context)
        {
            _context = context;
        }

        // GET: api/ClothesOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothesOrders>>> GetClothesOrders()
        {
            return await _context.ClothesOrders.ToListAsync();
        }

        // GET: api/ClothesOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesOrders>> GetClothesOrders(int id)
        {
            var clothesOrders = await _context.ClothesOrders.FindAsync(id);

            if (clothesOrders == null)
            {
                return NotFound();
            }

            return clothesOrders;
        }

        // PUT: api/ClothesOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothesOrders(int id, ClothesOrders clothesOrders)
        {
            if (id != clothesOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothesOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothesOrdersExists(id))
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

        // POST: api/ClothesOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothesOrders>> PostClothesOrders(ClothesOrders clothesOrders)
        {
            _context.ClothesOrders.Add(clothesOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothesOrders", new { id = clothesOrders.Id }, clothesOrders);
        }

        // DELETE: api/ClothesOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothesOrders(int id)
        {
            var clothesOrders = await _context.ClothesOrders.FindAsync(id);
            if (clothesOrders == null)
            {
                return NotFound();
            }

            _context.ClothesOrders.Remove(clothesOrders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothesOrdersExists(int id)
        {
            return _context.ClothesOrders.Any(e => e.Id == id);
        }
    }
}
