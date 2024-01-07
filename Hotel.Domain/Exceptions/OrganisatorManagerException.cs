using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Exceptions
{
    public class OrganisatorManagerException : Exception
    {
        public OrganisatorManagerException(string? message) : base(message)
        {
        }

        public OrganisatorManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
