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
    public class OrganisatorManager
    {
        private IOrganisatorRepository _organisatorRepository;

        public OrganisatorManager(IOrganisatorRepository organisatorRepository)
        {
            _organisatorRepository = organisatorRepository;
        }

        public void AddOrganisator(Organisator organisator)
        {
            try
            {
                _organisatorRepository.AddOrganisator(organisator);
            }
            catch (Exception ex)
            {
                throw new OrganisatorManagerException("AddOrganisator", ex);
            }
        }
        public IReadOnlyList<Organisator> GetOrganisators(string filter)
        {
            try
            {
                return _organisatorRepository.GetOrganisators(filter);
            }
            catch (Exception ex)
            {
                throw new OrganisatorManagerException("GetOrganisators", ex);
            }
        }
        public Organisator GetOrganisatorById(int id)
        {
            try
            {
                return _organisatorRepository.GetOrganisatorById(id);
            }
            catch (Exception ex)
            {
                throw new OrganisatorManagerException("GetOrganisatorById", ex);
            }
        }
        public Organisator UpdateOrganisator(Organisator organisator)
        {
            try
            {
                return _organisatorRepository.UpdateOrganisator(organisator);
            }
            catch (Exception ex)
            {
                throw new OrganisatorManagerException("UpdateOrganisator", ex);
            }
        }
        public void DeleteOrganisator(int id)
        {
            try
            {
                _organisatorRepository.DeleteOrganisator(id);
            }
            catch (Exception ex)
            {
                throw new OrganisatorManagerException("DeleteOrganisator", ex);
            }
        }
    }
}
