using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Model
{
    public class Organisator
    {
        private int _id;
        public int Id { get; set; }
        private string _name;
        public string Name { get; set; }
        private ContactInfo _contact;
        public ContactInfo Contact { get; set; }

        public Organisator(int id, string name, ContactInfo contact)
        {
            Id = id;
            Name = name;
            Contact = contact;
        }

        public Organisator(string name, ContactInfo contact)
        {
            Name = name;
            Contact = contact;
        }

    }
}
