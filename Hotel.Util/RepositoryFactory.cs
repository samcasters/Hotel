using Hotel.Domain.Interfaces;
using Hotel.Persistence.Repositories;
using System.Configuration;

namespace Hotel.Util
{
    public static class RepositoryFactory
    {
        public static IActivityRepository ActivityRepository { get { return new ActivityRepository(ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString); } }
        public static ICustomerRepository CustomerRepository { get { return new CustomerRepository(ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString); } }
        public static IOrganisatorRepository organisatorRepository { get { return new OrganisatorRepository(ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString); } }
        public static IRegistrationRepository registrationRepository { get { return new RegistrationRepository(ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString); } }
    }
}