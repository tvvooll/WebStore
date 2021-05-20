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
    public class ClothesSizesController : ControllerBase
    {
        private readonly WebStoreContext _context;

        public ClothesSizesController(WebStoreContext context)
        {
            _context = context;
        }

        // GET: api/ClothesSizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothesSizes>>> GetClothesSizes()
        {
            return await _context.ClothesSizes.ToListAsync();
        }

        // GET: api/ClothesSizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesSizes>> GetClothesSizes(int id)
        {
            var clothesSizes = await _context.ClothesSizes.FindAsync(id);

            if (clothesSizes == null)
            {
                return NotFound();
            }

            return clothesSizes;
        }

        // PUT: api/ClothesSizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothesSizes(int id, ClothesSizes clothesSizes)
        {
            if (id != clothesSizes.Id)
            {
                return BadRequest();
            }

            _context.Entry(clothesSizes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothesSizesExists(id))
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

        // POST: api/ClothesSizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothesSizes>> PostClothesSizes(ClothesSizes clothesSizes)
        {
            _context.ClothesSizes.Add(clothesSizes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothesSizes", new { id = clothesSizes.Id }, clothesSizes);
        }

        // DELETE: api/ClothesSizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothesSizes(int id)
        {
            var clothesSizes = await _context.ClothesSizes.FindAsync(id);
            if (clothesSizes == null)
            {
                return NotFound();
            }

            _context.ClothesSizes.Remove(clothesSizes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClothesSizesExists(int id)
        {
            return _context.ClothesSizes.Any(e => e.Id == id);
        }
    }
}
