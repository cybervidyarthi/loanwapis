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
    public class UserInfoRepository : IEntityRepository<UserInfo>
    {
        private readonly UserInfoContext _context;

        public UserInfoRepository(UserInfoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserInfo entity)
        {
            _context.UserInfos.Add(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<RepositoryResultTypes> UpdateAsync(int id, UserInfo user)
        {
            if (id != user.Id)
            {
                return RepositoryResultTypes.BadRequest;
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
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

        private bool UserInfoExists(int id)
        {
            return _context.UserInfos.Any(e => e.Id == id);
        }

        public async Task<RepositoryResultTypes> DeleteAsync(int id)
        {
            var userDetails = await _context.UserInfos.FindAsync(id);

            if (userDetails == null)
            {
                return RepositoryResultTypes.NotFound;
            }

            _context.UserInfos.Remove(userDetails);
            await _context.SaveChangesAsync();

            return RepositoryResultTypes.NoContent;
        }

        public async Task<ActionResult<IEnumerable<UserInfo>>> GetAsync()
        {

            return await _context.UserInfos.ToListAsync();
        }

        public async Task<ActionResult<UserInfo>> GetAsync(int id)
        {
            return await _context.UserInfos.FindAsync(id);
        }


    }

}

