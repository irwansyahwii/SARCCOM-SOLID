using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARCCOM.SOLID.Repositories;
using SARCCOM.SOLID.DomainModels;
using System.Threading;
using System.Threading.Tasks;

namespace SARCCOM.SOLID.Repositories.Tests
{
    [TestClass]
    public class CustomerRepositoryToHashtableTests
    {
        [TestMethod]
        public async Task TestInsert()
        {
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            Customer c = new Customer(1, "irwan", "012121", "irwan@gmail.com");
            CustomerRepositoryToHashtable repo = new CustomerRepositoryToHashtable();
            await repo.Insert(c, cancellationToken);

            Customer storedCustomer = repo.Hashtable[c.Id.Value];

            Assert.IsNotNull(storedCustomer, "storedCustomer");
            Assert.AreEqual(storedCustomer.Name, c.Name, "name");
            Assert.AreEqual(storedCustomer.Email, c.Email, "email");
            Assert.AreEqual(storedCustomer.PhoneNo, c.PhoneNo, "phoneno");
        }

    }
}
