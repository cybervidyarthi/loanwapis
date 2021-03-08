
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
    public class ContactRepository: IEntityRepository<ContactDetails>
    {
        private readonly ContactDetailsContext _context;

        public ContactRepository(ContactDetailsContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ContactDetails contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

        }

        public async Task<RepositoryResultTypes> UpdateAsync(int id, ContactDetails contact)
        {
            if (id != contact.Id)
            {
                return RepositoryResultTypes.BadRequest;
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailsExists(id))
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

        private bool ContactDetailsExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }

        public async Task<RepositoryResultTypes> DeleteAsync(int id)
        {
            var contactDetails = await _context.Contacts.FindAsync(id);

            if (contactDetails == null)
            {
                return RepositoryResultTypes.NotFound;
            }

            _context.Contacts.Remove(contactDetails);
            await _context.SaveChangesAsync();

            return RepositoryResultTypes.NoContent;
        }

        public async Task<ActionResult<IEnumerable<ContactDetails>>>  GetAsync()
        {

            return await _context.Contacts.ToListAsync();
        }

        public async Task<ActionResult<ContactDetails>> GetAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }


    }
}