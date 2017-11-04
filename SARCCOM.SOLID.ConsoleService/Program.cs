using System;
using Microsoft.Extensions.DependencyInjection;
using SARCCOM.SOLID.ApplicationServices;

namespace SARCCOM.SOLID.ConsoleService
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            CompositionRoot.ComposeApplication(serviceCollection);

            IServiceProvider serviceProvider =  serviceCollection.BuildServiceProvider();

            CustomerRegistrationService service = serviceProvider.GetService<CustomerRegistrationService>();

            service.Register(new CustomerDTO());

            Console.ReadLine();

        }
    }
}
