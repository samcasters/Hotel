using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Persistence.Exceptions
{
    public class OrganisatorRepositoryException : Exception
    {
        public OrganisatorRepositoryException(string? message) : base(message)
        {
        }

        public OrganisatorRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
