using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanWAPIs.Models;

namespace LoanWAPIs.ConcreteRepositories.Interfaces
{
    interface IUserInfoRepository
    {
        public void Add(UserInfo user);
        public void Update(UserInfo user);
        public void Delete(UserInfo user);

        public UserInfo Get(int id);

    }

}
