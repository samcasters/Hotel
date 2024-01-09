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
    public class ActivityRepository : IActivityRepository
    {
        private string connectionString;
        private OrganisatorRepository organizationRepository;

        public ActivityRepository(string connectionString)
        {
            this.connectionString = connectionString;
            organizationRepository = new OrganisatorRepository(connectionString);
        }

        public void AddActivity(Activity activity)
        {
            try
            {
                string sql = "INSERT INTO Activatie(name,omvating,place,durationMin,timeOfActivatie,availability,costAdult,costChild,organisatorId,status) " +
                         "output INSERTED.ID VALUES(@name,@omvating,@place,@durationMin,@timeOfActivatie,@availability,@costAdult,@costChild,@organisatorId,@status)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction sqlTransaction = conn.BeginTransaction();
                    try
                    {
                        cmd.Transaction = sqlTransaction;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@name", activity.Name);
                        cmd.Parameters.AddWithValue("@omvating", activity.Description);
                        cmd.Parameters.AddWithValue("@place", activity.Place);
                        cmd.Parameters.AddWithValue("@durationMin", activity.DurationMin);
                        cmd.Parameters.AddWithValue("@timeOfActivatie", activity.TimeOfActivity);
                        cmd.Parameters.AddWithValue("@availability", activity.Availability);
                        cmd.Parameters.AddWithValue("@costAdult", activity.CostAdult);
                        cmd.Parameters.AddWithValue("@costChild", activity.CostChild);
                        cmd.Parameters.AddWithValue("@organisatorId", activity.Organisator.Id);
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
        public Activity GetActivityById(int id)
        {
            try
            {
                Activity activity = new Activity(int.MaxValue, "", "", "", -1, DateTime.MaxValue, int.MaxValue, float.MaxValue, float.MaxValue, new Organisator("", new ContactInfo("", "", new Address(""))));
                string sql = "select act.id, act.name, act.omvating, act.place, act.durationMin, act.timeOfActivatie, act.availability, act.costAdult, act.costChild, act.organisatorId, act.status from Activatie act where id = @id";
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
                            var omvating = (string)reader["omvating"];
                            var place = (string)reader["place"];
                            var durationMin = (string)reader["durationMin"];
                            var timeOfActivatie = (string)reader["timeOfActivatie"];
                            var availability = (string)reader["availability"];
                            var costAdult = (string)reader["costAdult"];
                            var costChild = (string)reader["costChild"];
                            var organisatorId = (string)reader["organisatorId"];
                            var status = (string)reader["status"];
                            activity = new Activity(int.Parse(sqlid), name, omvating, place, int.Parse(durationMin), DateTime.Parse(timeOfActivatie), int.Parse(availability), float.Parse(costAdult), float.Parse(costChild), organizationRepository.GetOrganisatorById(int.Parse(organisatorId)));
                        }
                    }
                }
                return activity;
            }
            catch (Exception ex)
            {
                throw new ActivityRepositoryException("GetActivityById", ex);
            }
        }
        public void DeleteActivity(int id)
        {
            try
            {
                string sql = "update Activatie set status=0 where customerid = @id";
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
                throw new ActivityRepositoryException("DeleteActivity", ex);
            }
        }
        public IReadOnlyList<Activity> GetActivitysByOrganisatorId(int id)
        {
            try
            {
                List<Activity> activitys = new List<Activity>();
                string sql = "select act.id, act.name, act.omvating, act.place, act.durationMin, act.timeOfActivatie, act.availability, act.costAdult, act.costChild, act.organisatorId, act.status from Activatie act where organisatorId = @id";
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
                            var omvating = (string)reader["omvating"];
                            var place = (string)reader["place"];
                            var durationMin = (string)reader["durationMin"];
                            var timeOfActivatie = (string)reader["timeOfActivatie"];
                            var availability = (string)reader["availability"];
                            var costAdult = (string)reader["costAdult"];
                            var costChild = (string)reader["costChild"];
                            var organisatorId = (string)reader["organisatorId"];
                            var status = (string)reader["status"];
                            Activity activity = new Activity(int.Parse(sqlid), name, omvating, place, int.Parse(durationMin), DateTime.Parse(timeOfActivatie), int.Parse(availability), float.Parse(costAdult), float.Parse(costChild), organizationRepository.GetOrganisatorById(int.Parse(organisatorId)));
                            activitys.Add(activity);
                        }
                    }
                }
                return activitys;
            }
            catch (Exception ex)
            {
                throw new ActivityRepositoryException("GetActivitysByOrganisatorId", ex);
            }
        }
        public Activity UpdateActivity(Activity activity)
        {
            try
            {
                string sql = "update Activatie set name=@name,omvating=@omvating,place=@place,durationMin=@durationMin,timeOfActivatie=@timeOfActivatie,availability=@availability,costAdult=@costAdult,costChild=@costChild,organisatorId=@organisatorId,status=@status where id = @id ";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    SqlTransaction sqlTransaction = conn.BeginTransaction();
                    try
                    {
                        cmd.Transaction = sqlTransaction;
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@id", activity.Id);
                        cmd.Parameters.AddWithValue("@name", activity.Name);
                        cmd.Parameters.AddWithValue("@omvating", activity.Description);
                        cmd.Parameters.AddWithValue("@place", activity.Place);
                        cmd.Parameters.AddWithValue("@durationMin", activity.DurationMin);
                        cmd.Parameters.AddWithValue("@timeOfActivatie", activity.TimeOfActivity);
                        cmd.Parameters.AddWithValue("@availability", activity.Availability);
                        cmd.Parameters.AddWithValue("@costAdult", activity.CostAdult);
                        cmd.Parameters.AddWithValue("@costChild", activity.CostChild);
                        cmd.Parameters.AddWithValue("@organisatorId", activity.Organisator.Id);
                        cmd.Parameters.AddWithValue("@status", 1);

                        cmd.ExecuteNonQuery();
                        sqlTransaction.Commit();
                    }
                    catch (Exception ex) { sqlTransaction.Rollback(); throw; }
                }
                return activity;
            }
            catch (Exception ex)
            {

                throw new ActivityRepositoryException("AddActivity", ex);
            }
        }

        public IReadOnlyList<Activity> GetActivitys(string filter)
        {
            try
            {
                List<Activity> activitys = new List<Activity>();
                string sql = "select act.id, act.name, act.omvating, act.place, act.durationMin, act.timeOfActivatie, act.availability, act.costAdult, act.costChild, act.organisatorId, act.status from Activatie act where status = 1";
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    sql += " and (act.id like @filter or act.name like @filter)";
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
                            var sqlid = (string)reader["id"];
                            var name = (string)reader["name"];
                            var omvating = (string)reader["omvating"];
                            var place = (string)reader["place"];
                            var durationMin = (string)reader["durationMin"];
                            var timeOfActivatie = (string)reader["timeOfActivatie"];
                            var availability = (string)reader["availability"];
                            var costAdult = (string)reader["costAdult"];
                            var costChild = (string)reader["costChild"];
                            var organisatorId = (string)reader["organisatorId"];
                            var status = (string)reader["status"];
                            Activity activity = new Activity(int.Parse(sqlid), name, omvating, place, int.Parse(durationMin), DateTime.Parse(timeOfActivatie), int.Parse(availability), float.Parse(costAdult), float.Parse(costChild), organizationRepository.GetOrganisatorById(int.Parse(organisatorId)));
                            activitys.Add(activity);
                        }
                    }
                }
                return activitys;
            }
            catch (Exception ex)
            {
                throw new ActivityRepositoryException("GetActivitys", ex);
            }
        }
    }
}
