using System;
using System.Threading;
using System.Threading.Tasks;
using SARCCOM.SOLID.DomainModels;

namespace SARCCOM.SOLID.Repositories
{
    public class CustomerRepositoryDecorateWithLogging : ICustomerRepository
    {
        protected ICustomerRepository decoratee;
        public CustomerRepositoryDecorateWithLogging(ICustomerRepository decoratee)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public Task Insert(Customer customer, CancellationToken cancellationToken)
        {
            Console.WriteLine("Logging to file, ada yang insert ke DB");
            this.decoratee.Insert(customer, cancellationToken);

            return Task.FromResult("");
        }

    }
}
