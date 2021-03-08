using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoanWAPIs.Models;

namespace LoanWAPIs.ConcreteRepositories.Interfaces
{
    public interface IEntityRepository<T> : IQueryEntityRepository<T>, ICommandEntityRepository<T> where T : class
    {
    }
}
