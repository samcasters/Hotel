using Hotel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Managers
{
    public class OrganisatorManager
    {
        private IOrganisatorRepository _organisatorRepository;

        public OrganisatorManager(IOrganisatorRepository organisatorRepository)
        {
            _organisatorRepository = organisatorRepository;
        }
    }
}
