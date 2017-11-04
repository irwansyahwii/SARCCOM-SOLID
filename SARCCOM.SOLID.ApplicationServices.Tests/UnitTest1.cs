using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARCCOM.SOLID.ApplicationServices;
using Moq;
using SARCCOM.SOLID.DomainModels;
using System.Threading;
using System;

namespace SARCCOM.SOLID.ApplicationServices.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<ICustomerRepository> customerRepo = new Mock<ICustomerRepository>();
            bool isInsertCalled = false;
            customerRepo.Setup(x => x.Insert(It.IsAny<Customer>(), It.IsAny<CancellationToken>()))
                        .Callback(() => {
                            isInsertCalled = true;
                Console.WriteLine("Dummy mock");
            });
            CustomerRegistrationService service = new CustomerRegistrationService(customerRepo.Object);
            service.Register(new CustomerDTO());

            Assert.IsTrue(isInsertCalled, "isInsertCalled false");
        }
    }
}
