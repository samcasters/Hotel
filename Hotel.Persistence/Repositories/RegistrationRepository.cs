using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using Hotel.Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Persistence.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private string connectionString;
        private ActivityRepository activityRepository;
        private CustomerRepository customerRepository;
        public RegistrationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddRegistration(Registration registration)
        {
            try
            {
                string sql = "INSERT INTO registration(activatieId,customerId,participating) " +
                         "output INSERTED.ID VALUES(@activatieId,@customerId,@participating)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction sqlTransaction = conn.BeginTransaction();
                    try
                    {
                        cmd.Transaction = sqlTransaction;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@activatieId", registration.Activatie.Id);
                        cmd.Parameters.AddWithValue("@customerId", registration.Customer.Id);
                        cmd.Parameters.AddWithValue("@participating", registration.Participating);

                        cmd.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex) { sqlTransaction.Rollback(); throw; }
                }
            }
            catch (Exception ex)
            {

                throw new RegistrationRepositoryException("AddRegistration", ex);
            }
        }
        public Registration GetRegistrationById(int id)
        {
            try
            {
                Registration registration = new Registration(new Activity(int.MaxValue,"","","",int.MaxValue,DateTime.MaxValue,int.MaxValue,float.MaxValue,float.MaxValue,new Organisator(int.MaxValue,"",new ContactInfo("","",new Address(""))),false),new Customer("",new ContactInfo("","",new Address(""))),int.MaxValue);
                string sql = "select reg.activatieId,reg.customerId,reg.participating from registration reg where id = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var activatieId = (string)reader["activatieId"];
                            var customerId = (string)reader["customerId"];
                            var participating = (string)reader["participating"];

                            registration = new Registration(activityRepository.GetActivityById(int.Parse(activatieId)),customerRepository.GetCustomerById(int.Parse(customerId)),int.Parse(participating));
                        }
                    }
                }
                return registration;
            }
            catch (Exception ex)
            {
                throw new ActivityRepositoryException("GetActivityById", ex);
            }
        }
        public IReadOnlyList<Registration> GetRegistrationsByCustomerId(int id)
        {
            try
            {
                List<Registration> registrations = new List<Registration>();
                string sql = "select reg.activatieId,reg.customerId,reg.participating from registration reg where customerId = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var activatieId = (string)reader["activatieId"];
                            var customerId = (string)reader["customerId"];
                            var participating = (string)reader["participating"];
                            Registration registration = new Registration(activityRepository.GetActivityById(int.Parse(activatieId)), customerRepository.GetCustomerById(int.Parse(customerId)), int.Parse(participating));
                            registrations.Add(registration);
                        }
                    }
                }
                return registrations;
            }
            catch (Exception ex)
            {
                throw new RegistrationRepositoryException("GetRegistrationsByCustomerId", ex);
            }
        }
        public void DeleteRegistration(int id)
        {
            try
            {
                string sql = "update registration set status=0 where customerid = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new RegistrationRepositoryException("DeleteRegistration", ex);
            }
        }
        public Registration UpdateRegistration(Registration registration)
        {
            try
            {
                string sql = "update registration det activatieId=@activatieId,customerId=@customerId,participating=@participating WHERE activatieId = @activatieId AND customerId = @customerId";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction sqlTransaction = conn.BeginTransaction();
                    try
                    {
                        cmd.Transaction = sqlTransaction;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@activatieId", registration.Activatie.Id);
                        cmd.Parameters.AddWithValue("@customerId", registration.Customer.Id);
                        cmd.Parameters.AddWithValue("@participating", registration.Participating);

                        cmd.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex) { sqlTransaction.Rollback(); throw; }
                }
                return registration;
            }
            catch (Exception ex)
            {

                throw new RegistrationRepositoryException("UpdateRegistration", ex);
            }
        }
    }
}
