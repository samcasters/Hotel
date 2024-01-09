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
    public class RegistrationManager
    {
        private IRegistrationRepository _registrationRepository;

        public RegistrationManager(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public void AddRegistration(Registration registration)
        {
            try
            {
                _registrationRepository.AddRegistration(registration);
            }
            catch (Exception ex)
            {
                throw new RegistrationManagerException("AddRegistration", ex);
            }
        }
        public IReadOnlyList<Registration> GetRegistrationsByCustomerId(int id)
        {
            try
            {
                return _registrationRepository.GetRegistrationsByCustomerId(id);
            }
            catch (Exception ex)
            {
                throw new RegistrationManagerException("AddRegistration", ex);
            }
        }
        public IReadOnlyList<Registration> GetRegistrations(string filter)
        {
            try
            {
                return _registrationRepository.GetRegistrations(filter);
            }
            catch (Exception ex)
            {
                throw new RegistrationManagerException("GetRegistrations",ex);
            }
        }
        public Registration GetRegistrationById(int id)
        {
            try
            {
                return _registrationRepository.GetRegistrationById(id);
            }
            catch (Exception ex)
            {
                throw new RegistrationManagerException("AddRegistration", ex);
            }
        }
        public Registration UpdateRegistration(Registration registration)
        {
            try
            {
                return _registrationRepository.UpdateRegistration(registration);
            }
            catch (Exception ex)
            {
                throw new RegistrationManagerException("AddRegistration", ex);
            }
        }
        public void DeleteRegistration(int id)
        {
            try
            {
                _registrationRepository.DeleteRegistration(id);
            }
            catch (Exception ex)
            {
                throw new RegistrationManagerException("AddRegistration", ex);
            }
        }
    }
}