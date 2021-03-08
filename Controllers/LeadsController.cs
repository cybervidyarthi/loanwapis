using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanWAPIs.Models;
using LoanWAPIs.DbContexts;

namespace LoanWAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly LeadInformationContext _context;

        public LeadsController(LeadInformationContext context)
        {
            _context = context;
        }

        // GET: api/Leads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadInformation>>> GetLeads()
        {
            return await _context.Leads.ToListAsync();
        }

        // GET: api/Leads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeadInformation>> GetLeadInformation(int id)
        {
            var leadInformation = await _context.Leads.FindAsync(id);

            if (leadInformation == null)
            {
                return NotFound();
            }

            return leadInformation;
        }

        // PUT: api/Leads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadInformation(int id, LeadInformation leadInformation)
        {
            if (id != leadInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(leadInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadInformationExists(id))
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

        // POST: api/Leads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeadInformation>> PostLeadInformation(LeadInformation leadInformation)
        {
            _context.Leads.Add(leadInformation);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetLeadInformation", new { id = leadInformation.Id }, leadInformation);
            return CreatedAtAction(nameof(GetLeadInformation), new {id = leadInformation.Id}, leadInformation);
        }

        // DELETE: api/Leads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadInformation(int id)
        {
            var leadInformation = await _context.Leads.FindAsync(id);
            if (leadInformation == null)
            {
                return NotFound();
            }

            _context.Leads.Remove(leadInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeadInformationExists(int id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }
    }
}
