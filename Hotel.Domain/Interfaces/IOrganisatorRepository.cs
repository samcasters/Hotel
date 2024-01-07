using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IOrganisatorRepository
    {
        public void AddOrganisator(Organisator organisator);
        public IReadOnlyList<Organisator> GetOrganisators(string filter);
        public Organisator GetOrganisatorById(int id);
        public Organisator UpdateOrganisator(Organisator organisator);
        public void DeleteOrganisator(int id);
    }
}
