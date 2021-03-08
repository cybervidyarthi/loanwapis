using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LoanWAPIs.ConcreteRepositories;
using LoanWAPIs.ConcreteRepositories.Interfaces;
using LoanWAPIs.Models;

namespace LoanWAPIs.DependencyInjection
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            DomainContextConfigurations(services, configuration);
            ContentContextConfigurations(services, configuration);
        }

        private static void DomainContextConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            //Repositories
            services.AddScoped<IEntityRepository<ContactDetails>, ContactRepository>();
            services.AddScoped<IEntityRepository<LeadInformation>, LeadInformationRepository>();
            services.AddScoped<IEntityRepository<UserInfo>, UserInfoRepository>();
        }

        private static void ContentContextConfigurations(IServiceCollection services, IConfiguration configuration)
        {
            //To be used as necessary.
        }
    }
}
