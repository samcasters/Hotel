using Hotel.Domain.Exceptions;

namespace Hotel.Domain.Model
{
    public class Member
    {
        public Member(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }
        private string _name;
        public string Name { get { return _name; } set { if (string.IsNullOrWhiteSpace(value)) throw new CustomerException("member"); _name = value; } }
        private DateTime _birthday;
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (DateTime.Now > value) throw new CustomerException("member");
                _birthday = value;
            }
        }
        public override bool Equals(object? obj)
        {
            return obj is Member member &&
                   _name == member._name &&
                   _birthday.Equals(member._birthday);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _birthday);
        }
    }
}