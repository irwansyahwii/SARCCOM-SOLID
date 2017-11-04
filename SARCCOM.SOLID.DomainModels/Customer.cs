using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace SARCCOM.SOLID.DomainModels
{
    public enum EmployeeType{
        JenisnyaA,
        JenisnyaB
    }
    public class Employee{
        public EmployeeType EmployeeType { get; }
        public bool IsPPh21 { get; }
        public Employee(EmployeeType employeeType, bool isPPh21){
            if(employeeType == EmployeeType.JenisnyaA){
                if(!isPPh21){
                    throw new DomainException("Employee yang jenisnya A harus PPH 21");
                }
            }
        }
    }

    public class Customer
    {
        public int? Id { get; }

        public string Name { get; }

        public string PhoneNo { get; }

        public string Email { get; private set; }

        public void ChangeEmail(string newEmail){
            if(isValidEmail(newEmail)){
                this.Email = newEmail;
            }
        }

        public Customer(int? id, string name, string phoneNo, string email){
            if(string.IsNullOrWhiteSpace(name)){
                throw new DomainException("Failed to create Customer, name is required");
            }

            if(!isValidPhone(phoneNo)){
                throw new DomainException("Failed to create Customer, invalid phone number");
            }

            if(!isValidEmail(email)){
                throw new DomainException("Failed to create Customer, invalid email");
            }

            this.Id = id;
        }

        private bool isValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool isValidPhone(string phoneNo)
        {
            return Regex.Match(phoneNo, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").Success;
        }

        protected bool ValidatePhoneNumber(string phone, bool IsRequired)
        {
            if (string.IsNullOrEmpty(phone) & !IsRequired)
                return true;

            if (string.IsNullOrEmpty(phone) & IsRequired)
                return false;

            var cleaned = RemoveNonNumeric(phone);
            if (IsRequired)
            {
                if (cleaned.Length == 10)
                    return true;
                else
                    return false;
            }
            else
            {
                if (cleaned.Length == 0)
                    return true;
                else if (cleaned.Length > 0 & cleaned.Length < 10)
                    return false;
                else if (cleaned.Length == 10)
                    return true;
                else
                    return false; // should never get here
            }
        }

        protected string RemoveNonNumeric(string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }        
    }
}
