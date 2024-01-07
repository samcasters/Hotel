using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Exceptions
{
    public class ContactInfoManagerException : Exception
    {
        public ContactInfoManagerException(string? message) : base(message)
        {
        }

        public ContactInfoManagerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
