using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IRegistrationRepository
    {
        public void AddRegistration(Registration registration);
        public IReadOnlyList<Registration> GetRegistrationsByCustomerId(int id);
        public IReadOnlyList<Registration> GetRegistrations(string filter);
        public Registration GetRegistrationById(int id);
        public Registration UpdateRegistration(Registration registration);
        public void DeleteRegistration(int id);
    }
}
