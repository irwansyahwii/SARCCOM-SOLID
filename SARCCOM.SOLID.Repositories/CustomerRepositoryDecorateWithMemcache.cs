using System;
using System.Threading;
using System.Threading.Tasks;
using SARCCOM.SOLID.DomainModels;

namespace SARCCOM.SOLID.Repositories
{
    public class CustomerRepositoryDecorateWithMemcache : ICustomerRepository
    {
        protected ICustomerRepository decoratee;
        public CustomerRepositoryDecorateWithMemcache(ICustomerRepository decoratee)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public Task Insert(Customer customer, CancellationToken cancellationToken)
        {
            this.decoratee.Insert(customer, cancellationToken);
            Console.WriteLine("Inserting to memcache");

            return Task.FromResult("");
        }
    }
}
