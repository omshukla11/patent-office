using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatentProj.Models;

namespace PatentProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GIFormsController : ControllerBase
    {
        private readonly GIFormContext _context;
        private readonly OwnerContext _ownerContext;

        public GIFormsController(GIFormContext context,OwnerContext ownerContext)
        {
            _context = context;
            _ownerContext = ownerContext;
        }

        // GET: api/GIForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GIForm>>> GetGIForms()
        {
          if (_context.GIForms == null)
          {
              return NotFound();
          }
            return await _context.GIForms.ToListAsync();
        }

        // GET: api/GIForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GIForm>> GetGIForm(long id)
        {
          if (_context.GIForms == null)
          {
              return NotFound();
          }
            var gIForm = await _context.GIForms.FindAsync(id);

            if (gIForm == null)
            {
                return NotFound();
            }

            return gIForm;
        }

        // PUT: api/GIForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGIForm(long id, GIForm gIForm)
        {
            if (id != gIForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(gIForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GIFormExists(id))
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

        // POST: api/GIForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GIForm>> PostGIForm(GIForm gIForm)
        {
          if (_context.GIForms == null)
          {
              return Problem("Entity set 'GIFormContext.GIForms'  is null.");
          }

            // Get the owner object based on its id
            var owner = await _ownerContext.Owners.FindAsync(gIForm.OwnerId);

            // If the Owner with the given ID doesn't exist, return a 404 Not Found response
            if (owner == null)
                {
                    return BadRequest($"Owner with id {gIForm.OwnerId} not found."); ;
                }

                // Set the Owner navigation property of the GIForm object
                gIForm.Owner = owner;

            _context.GIForms.Add(gIForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGIForm", new { id = gIForm.Id }, gIForm);
        }

        // DELETE: api/GIForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGIForm(long id)
        {
            if (_context.GIForms == null)
            {
                return NotFound();
            }
            var gIForm = await _context.GIForms.FindAsync(id);
            if (gIForm == null)
            {
                return NotFound();
            }

            _context.GIForms.Remove(gIForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GIFormExists(long id)
        {
            return (_context.GIForms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
