using System;
using System.Threading;
using SARCCOM.SOLID.DomainModels;

namespace SARCCOM.SOLID.ApplicationServices
{
    public class CustomerDTO{
        
    }

    public class CustomerRegistrationService
    {
        protected ICustomerRepository customerRepository;

        public CustomerRegistrationService(ICustomerRepository customerRepository){
            this.customerRepository = customerRepository ?? throw new ArgumentNullException("customerRepository is null");
        }
        public void Register(CustomerDTO customerDTO){
            Console.WriteLine("Registering customer");

            Employee e = new Employee(EmployeeType.JenisnyaA, false);

            this.customerRepository.Insert(new Customer(1, "adsad", "121212", "abc@gmail.com"), new CancellationTokenSource().Token);
        }
    }
}
