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
    public class DesignFormsController : ControllerBase
    {
        private readonly DesignFormContext _context;
        private readonly OwnerContext _ownerContext;

        public DesignFormsController(DesignFormContext context, OwnerContext ownerContext)
        {
            _context = context;
            _ownerContext = ownerContext;
        }

        // GET: api/DesignForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesignForm>>> GetDesignForms()
        {
          if (_context.DesignForms == null)
          {
              return NotFound();
          }
            return await _context.DesignForms.ToListAsync();
        }

        // GET: api/DesignForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignForm>> GetDesignForm(long id)
        {
          if (_context.DesignForms == null)
          {
              return NotFound();
          }
            var designForm = await _context.DesignForms.FindAsync(id);

            if (designForm == null)
            {
                return NotFound();
            }

            return designForm;
        }

        // PUT: api/DesignForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignForm(long id, DesignForm designForm)
        {
            if (id != designForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(designForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignFormExists(id))
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

        // POST: api/DesignForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DesignForm>> PostDesignForm(DesignForm designForm)
        {
          if (_context.DesignForms == null)
          {
              return Problem("Entity set 'DesignFormContext.DesignForms'  is null.");
          }

            // Get the owner object based on its id
            var owner = await _ownerContext.Owners.FindAsync(designForm.OwnerId);

            // If the Owner with the given ID doesn't exist, return a 404 Not Found response
            if (owner == null)
            {
                return BadRequest($"Owner with id {designForm.OwnerId} not found."); ;
            }

            // Set the Owner navigation property of the GIForm object
            designForm.Owner = owner;

            _context.DesignForms.Add(designForm);
            _context.DesignForms.Add(designForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignForm", new { id = designForm.Id }, designForm);
        }

        // DELETE: api/DesignForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesignForm(long id)
        {
            if (_context.DesignForms == null)
            {
                return NotFound();
            }
            var designForm = await _context.DesignForms.FindAsync(id);
            if (designForm == null)
            {
                return NotFound();
            }

            _context.DesignForms.Remove(designForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesignFormExists(long id)
        {
            return (_context.DesignForms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
