using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoanWAPIs.ConcreteRepositories.Interfaces;
using LoanWAPIs.Models;

namespace LoanWAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IEntityRepository<ContactDetails> _contactRepo;

        public ContactsController(IEntityRepository<ContactDetails> contactRepository)
        {
            _contactRepo = contactRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDetails>>> GetContacts()
        {
            return await _contactRepo.GetAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetails>> GetContactDetails(int id)
        {

            var contactDetails = await _contactRepo.GetAsync(id);

            if (contactDetails == null)
            {
                return NotFound();
            }

            return contactDetails;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactDetails(int id, ContactDetails contactDetails)
        {
            var result = (RepositoryResultTypes) (await _contactRepo.UpdateAsync(id, contactDetails));


            switch (result)
            {
                case RepositoryResultTypes.BadRequest: return BadRequest(); 
                case RepositoryResultTypes.NotFound: return NotFound(); 
                case RepositoryResultTypes.Error: throw new DbUpdateConcurrencyException();
                case RepositoryResultTypes.NoContent: return NoContent();
            }

            return NoContent();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactDetails>> PostContactDetails(ContactDetails contactDetails)
        {

            await _contactRepo.AddAsync(contactDetails);
            return CreatedAtAction("GetContactDetails", new { id = contactDetails.Id }, contactDetails);

        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactDetails(int id)
        {

            var result = (RepositoryResultTypes) (await _contactRepo.DeleteAsync(id));

            if (result == RepositoryResultTypes.NotFound) return NotFound();
            return NoContent();
        }
    }
}
