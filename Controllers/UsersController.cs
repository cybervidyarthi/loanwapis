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
    public class UsersController : ControllerBase
    {
        private readonly IEntityRepository<UserInfo> _userRepo;

        public UsersController(IEntityRepository<UserInfo> userRepository)
        {
            _userRepo = userRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetContacts()
        {
            return await _userRepo.GetAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {

            var user = await _userRepo.GetAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInfo user)
        {
            var result = (RepositoryResultTypes)(await _userRepo.UpdateAsync(id, user));


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
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo user)
        {

            await _userRepo.AddAsync(user);
            return CreatedAtAction("GetUserInfo", new { id = user.Id }, user);

        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {

            var result = (RepositoryResultTypes)(await _userRepo.DeleteAsync(id));

            if (result == RepositoryResultTypes.NotFound) return NotFound();
            return NoContent();
        }
    }
}
