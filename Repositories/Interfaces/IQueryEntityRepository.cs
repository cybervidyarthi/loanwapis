using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanWAPIs.ConcreteRepositories.Interfaces
{
    public interface IQueryEntityRepository<T> where T: class
    {
        Task<ActionResult<IEnumerable<T>>> GetAsync();
        Task<ActionResult<T>> GetAsync(int Id);

    }
}
