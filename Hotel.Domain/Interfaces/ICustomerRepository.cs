using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        public void AddCustomer(Customer customer);
        public void AddMember(int? CustomerId, string? MemberName,DateTime? memberBurthday);
        public IReadOnlyList<Customer> GetCustomers(string filter);
        public IReadOnlyList<Member> GetMembers(int customerId);
        public Customer GetCustomerById(int id);
        public Customer UpdateCustomer(Customer customer);
        public void DeleteCustomer(int id);
        
    }
}
