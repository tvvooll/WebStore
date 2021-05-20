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
    public class ClothesColorsController : ControllerBase
    {
        private readonly WebStoreContext _context;

        public ClothesColorsController(WebStoreContext context)
        {
            _context = context;
        }

        // GET: api/ClothesColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothesColors>>> GetClothesColors()
        {
            return await _context.ClothesColors.ToListAsync();
        }

        // GET: api/ClothesColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesColors>> GetClothesColors(int id)
        {
            var clothesColors = await _context.ClothesColors.FindAsync(id);

            if (clothesColors == null)
            {
                return NotFound();
            }

            return clothesColors;
        }

        // PUT: api/ClothesColors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothesColors(int id, ClothesColors clothesColors)
        {
            if (id != clothesColors.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothesColors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothesColorsExists(id))
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

        // POST: api/ClothesColors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothesColors>> PostClothesColors(ClothesColors clothesColors)
        {
            _context.ClothesColors.Add(clothesColors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothesColors", new { id = clothesColors.Id }, clothesColors);
        }

        // DELETE: api/ClothesColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothesColors(int id)
        {
            var clothesColors = await _context.ClothesColors.FindAsync(id);
            if (clothesColors == null)
            {
                return NotFound();
            }

            _context.ClothesColors.Remove(clothesColors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothesColorsExists(int id)
        {
            return _context.ClothesColors.Any(e => e.Id == id);
        }
    }
}
