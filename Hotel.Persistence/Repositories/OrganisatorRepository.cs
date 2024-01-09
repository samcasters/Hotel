using Hotel.Domain.Interfaces;
using Hotel.Domain.Model;
using Hotel.Persistence.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Persistence.Repositories
{
    public class OrganisatorRepository : IOrganisatorRepository
    {
        private string connectionString;

        public OrganisatorRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddOrganisator(Organisator organisator)
        {
            try
            {
                string sql = "INSERT INTO Organisator(name,email,phone,address,status) " +
                         "output INSERTED.ID VALUES(@name,@email,@phone,@address,@status)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction sqlTransaction = conn.BeginTransaction();
                    try
                    {
                        cmd.Transaction = sqlTransaction;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@name", organisator.Name);
                        cmd.Parameters.AddWithValue("@email", organisator.Contact.Email);
                        cmd.Parameters.AddWithValue("@phone", organisator.Contact.Phone);
                        cmd.Parameters.AddWithValue("@address", organisator.Contact.Address);
                        cmd.Parameters.AddWithValue("@status", 1);
                        

                        cmd.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex) { sqlTransaction.Rollback(); throw; }
                }
            }
            catch (Exception ex)
            {

                throw new ActivityRepositoryException("AddActivity", ex);
            }
        }
        public Organisator GetOrganisatorById(int id)
        {
            try
            {
                Organisator organisator = new Organisator(int.MaxValue,"",new ContactInfo("","",new Address("")));
                string sql = "select org.name,org.email,org.phone,org.address,org.status from Organisator org where id = @id";
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
                            var sqlid = (string)reader["id"];
                            var name = (string)reader["name"];
                            var email = (string)reader["email"];
                            var phone = (string)reader["phone"];
                            var addres = (string)reader["addres"];
                            var status = (string)reader["status"];
                            organisator = new Organisator(int.Parse(sqlid),name,new ContactInfo(email,phone,new Address(addres)));
                        }
                    }
                }
                return organisator;
            }
            catch (Exception ex)
            {
                throw new ActivityRepositoryException("GetActivityById", ex);
            }
        }
        public IReadOnlyList<Organisator> GetOrganisators(string filter)
        {
            try
            {
                Dictionary<int, Organisator> organisators = new Dictionary<int, Organisator>();
                string sql = "select org.id,org.name,org.email,org.phone,org.address,org.status from Organisator org where status=1";
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    sql += " and (org.id like @filter or org.name like @filter or org.email like @filter)";
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    if (!string.IsNullOrWhiteSpace(filter)) cmd.Parameters.AddWithValue("@filter", $"%{filter}%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            if (!organisators.ContainsKey(id))
                            {
                                var sqlid = (string)reader["id"];
                                var name = (string)reader["name"];
                                var email = (string)reader["email"];
                                var phone = (string)reader["phone"];
                                var addres = (string)reader["addres"];
                                var status = (string)reader["status"];
                                Organisator organisator = new Organisator(int.Parse(sqlid), name, new ContactInfo(email, phone, new Address(addres)));
                                organisators.Add(id, organisator);
                            }
                        }
                    }
                }
                return organisators.Values.ToList();
            }
            catch (Exception ex)
            {
                throw new OrganisatorRepositoryException("GetOrganisators", ex);
            }
        }
        public void DeleteOrganisator(int id)
        {
            try
            {
                string sql = "update Organisator set status=0 where customerid = @id";
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
                throw new OrganisatorRepositoryException("DeleteOrganisator", ex);
            }
        }
        public Organisator UpdateOrganisator(Organisator organisator)
        {
            try
            {
                string sql = "update Organisator set name=@name,email=@email,phone=@phone,address=@address,status=@status where id = @id";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction sqlTransaction = conn.BeginTransaction();
                    try
                    {
                        cmd.Transaction = sqlTransaction;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@id", organisator.Id);
                        cmd.Parameters.AddWithValue("@name", organisator.Name);
                        cmd.Parameters.AddWithValue("@email", organisator.Contact.Email);
                        cmd.Parameters.AddWithValue("@phone", organisator.Contact.Phone);
                        cmd.Parameters.AddWithValue("@address", organisator.Contact.Address);
                        cmd.Parameters.AddWithValue("@status", 1);


                        cmd.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex) { sqlTransaction.Rollback(); throw; }
                }
                return organisator;
            }
            catch (Exception ex)
            {

                throw new ActivityRepositoryException("AddActivity", ex);
            }
        }
    }
}
