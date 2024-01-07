using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Exceptions
{
    public class OrganisatorException : Exception
    {
        public OrganisatorException(string? message) : base(message)
        {
        }

        public OrganisatorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
