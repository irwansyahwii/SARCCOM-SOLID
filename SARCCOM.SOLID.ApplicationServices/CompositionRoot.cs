using System;
using Microsoft.Extensions.DependencyInjection;
using SARCCOM.SOLID.DomainModels;
using SARCCOM.SOLID.Repositories;

namespace SARCCOM.SOLID.ApplicationServices
{
    public class CompositionRoot
    {
        public static void ComposeApplication(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICustomerRepository>(serviceProvider =>
            {
                return new CustomerRepositoryDecorateWithLogging(
                    new CustomerRepositoryDecorateWithMemcache(new CustomerRepositoryToHashtable()));
            });

            serviceCollection.AddTransient<CustomerRegistrationService>();
        }
    }
}
