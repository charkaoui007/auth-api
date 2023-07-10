using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthenticationAndAuthorization.DBModels;

namespace AuthenticationAndAuthorization
{
    [Authorize]
    [Route("api/categories")]
    [ApiController]
    public class CatContr : ControllerBase
    {
        private readonly ProductDataContext _context;

        public CatContr(ProductDataContext context)
        {
            _context = context;
        }

        // GET: api/CatContr
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCategory>>> GetTblCategories()
        {
          if (_context.TblCategories == null)
          {
              return NotFound();
          }
            return await _context.TblCategories.ToListAsync();
        }

        // GET: api/CatContr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCategory>> GetTblCategory(decimal id)
        {
          if (_context.TblCategories == null)
          {
              return NotFound();
          }
            var tblCategory = await _context.TblCategories.FindAsync(id);

            if (tblCategory == null)
            {
                return NotFound();
            }

            return tblCategory;
        }

        // PUT: api/CatContr/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCategory(decimal id, TblCategory tblCategory)
        {
            if (id != tblCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCategoryExists(id))
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

        // POST: api/CatContr
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCategory>> PostTblCategory(TblCategory tblCategory)
        {
          if (_context.TblCategories == null)
          {
              return Problem("Entity set 'ProductDataContext.TblCategories'  is null.");
          }
            _context.TblCategories.Add(tblCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCategory", new { id = tblCategory.Id }, tblCategory);
        }

        // DELETE: api/CatContr/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCategory(decimal id)
        {
            if (_context.TblCategories == null)
            {
                return NotFound();
            }
            var tblCategory = await _context.TblCategories.FindAsync(id);
            if (tblCategory == null)
            {
                return NotFound();
            }

            _context.TblCategories.Remove(tblCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCategoryExists(decimal id)
        {
            return (_context.TblCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
