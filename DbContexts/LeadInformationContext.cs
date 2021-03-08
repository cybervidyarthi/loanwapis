using Microsoft.EntityFrameworkCore;

using LoanWAPIs.Models;

namespace LoanWAPIs.DbContexts
{
    public class LeadInformationContext : DbContext
    {
        public LeadInformationContext(DbContextOptions<LeadInformationContext> options): base(options)
        {
        }

        public DbSet<LeadInformation> Leads { get; set; }
    }
}
