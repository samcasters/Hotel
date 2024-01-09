using Hotel.Domain.Exceptions;
using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Managers
{
    public class CustomerManager
    {
        private ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _customerRepository.AddCustomer(customer);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("AddCustomer", ex);
            }
        }
        public void AddMember(int? CustomerId, string? MemberName, DateTime? memberBurthday)
        {
            try
            {
                _customerRepository.AddMember(CustomerId, MemberName, memberBurthday);
            }
            catch (Exception ex)
            {
                throw new ActivityManagerException("AddMember", ex);
            }
        }
        public IReadOnlyList<Customer> GetCustomers(string filter)
        {
            try
            {
                return _customerRepository.GetCustomers(filter);
            }
            catch (Exception ex)
            {
                throw new ActivityManagerException("GetActivitys", ex);
            }
        }
        public IReadOnlyList<Member> GetMembers(int customerId)
        {
            try
            {
                return _customerRepository.GetMembers(customerId);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("GetMembers", ex);
            }
        }
        public Customer GetCustomerById(int id)
        {
            try
            {
                return _customerRepository.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("GetCustomerById", ex);
            }
        }
        public Customer UpdateCustomer(Customer customer)
        {
            try
            {
                return _customerRepository.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("UpdateCustomer", ex);
            }
        }
        public void DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("DeleteCustomer", ex);
            }
        }
        
    }
}
