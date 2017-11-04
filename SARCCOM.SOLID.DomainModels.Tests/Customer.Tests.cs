using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SARCCOM.SOLID.DomainModels.Tests
{
    public enum CustomerCreation 
    {
        Failed,
        Success
    }

    [TestClass]
    public class CustomerTests
    {
        [DataTestMethod]
        [DataRow(1, "Joko Bodo", "08121212", "", CustomerCreation.Failed, "Failed to create Customer, invalid email")]
        [DataRow(3, "Joko Bodo", "08121212", "a@a.com", CustomerCreation.Success, "")]
        [DataRow(4, "Joko Bodo", "08121212", "a", CustomerCreation.Failed, "Failed to create Customer, invalid email")]
        public void TestCreateNewCustomer(int? id, string name, string phoneNo, 
            string email, CustomerCreation creationResult, string expectedExceptionMessage)
        {
            bool isExceptionThrown = false;
            string exceptionMessage = "";
            try
            {
                Customer c = new Customer(id, name, phoneNo, email);                
            }
            catch (DomainException ex)
            {                
                isExceptionThrown = true;
                exceptionMessage = ex.Message;
            }

            if(creationResult == CustomerCreation.Failed){
                Assert.IsTrue(isExceptionThrown, "isExceptionThrown");
                Assert.AreEqual(expectedExceptionMessage, exceptionMessage, "exceptionMessage");
            }else{
                Assert.IsFalse(isExceptionThrown, "isExceptionThrown");
            }
            
        }
    }
}
