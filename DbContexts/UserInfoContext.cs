using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanWAPIs.Models;


namespace LoanWAPIs.DbContexts
{
    public class UserInfoContext : DbContext
    {
        public UserInfoContext(DbContextOptions<UserInfoContext> userInfo) : base(userInfo) { }

        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
