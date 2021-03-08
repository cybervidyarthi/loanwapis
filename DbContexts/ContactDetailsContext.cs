using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanWAPIs.Models;

namespace LoanWAPIs.DbContexts
{
    public class ContactDetailsContext: DbContext
    {
        public ContactDetailsContext(DbContextOptions<ContactDetailsContext> contactDetails) : base(contactDetails) { }

        public DbSet<ContactDetails> Contacts { get; set; }
    }
}
