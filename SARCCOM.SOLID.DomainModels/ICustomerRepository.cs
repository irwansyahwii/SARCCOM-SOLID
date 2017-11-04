using System;
using System.Threading;
using System.Threading.Tasks;

namespace SARCCOM.SOLID.DomainModels
{
    public interface ICustomerRepository
    {
        Task Insert(Customer customer, CancellationToken cancellationToken);
    }
}
