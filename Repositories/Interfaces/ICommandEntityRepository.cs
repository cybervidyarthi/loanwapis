using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanWAPIs.Models;

namespace LoanWAPIs.ConcreteRepositories.Interfaces
{
    public interface ICommandEntityRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<RepositoryResultTypes> UpdateAsync(int id, T entity);

        Task<RepositoryResultTypes> DeleteAsync(int id);

    }
}
