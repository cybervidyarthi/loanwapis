using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanWAPIs.ConcreteRepositories.Interfaces;
using LoanWAPIs.DbContexts;
using LoanWAPIs.Models;

namespace LoanWAPIs.ConcreteRepositories
{
    public class LeadInformationRepository : IEntityRepository<LeadInformation>
    {
        private readonly LeadInformationContext _context;

        public LeadInformationRepository(LeadInformationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LeadInformation entity)
        {
            _context.Leads.Add(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<RepositoryResultTypes> UpdateAsync(int id, LeadInformation lead)
        {
            if (id != lead.Id)
            {
                return RepositoryResultTypes.BadRequest;
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadInformationExists(id))
                {
                    return RepositoryResultTypes.NotFound;
                }
                else
                {
                    return RepositoryResultTypes.Error;
                }
            }

            return RepositoryResultTypes.NoContent;
        }

        private bool LeadInformationExists(int id)
        {
            return _context.Leads.Any(e => e.Id == id);
        }

        public async Task<RepositoryResultTypes> DeleteAsync(int id)
        {
            var leadDetails = await _context.Leads.FindAsync(id);

            if (leadDetails == null)
            {
                return RepositoryResultTypes.NotFound;
            }

            _context.Leads.Remove(leadDetails);
            await _context.SaveChangesAsync();

            return RepositoryResultTypes.NoContent;
        }

        public async Task<ActionResult<IEnumerable<LeadInformation>>> GetAsync()
        {

            return await _context.Leads.ToListAsync();
        }

        public async Task<ActionResult<LeadInformation>> GetAsync(int id)
        {
            return await _context.Leads.FindAsync(id);
        }


    }

}

