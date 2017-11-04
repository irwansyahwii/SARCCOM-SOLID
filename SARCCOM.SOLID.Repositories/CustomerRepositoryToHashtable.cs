using System;
using SARCCOM.SOLID.DomainModels;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SARCCOM.SOLID.Repositories
{
    public class CustomerRepositoryToHashtable : ICustomerRepository
    {
        public IDictionary<int, Customer> Hashtable { get; }
        public CustomerRepositoryToHashtable(){
            this.Hashtable = new Dictionary<int, Customer>();
        }
        public Task Insert(Customer customer, CancellationToken cancellationToken){
            Console.WriteLine("Inserting to hashtable");

            return Task.FromResult("");
        }
    }
}
