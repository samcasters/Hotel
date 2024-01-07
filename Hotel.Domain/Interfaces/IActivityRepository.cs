using Hotel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Interfaces
{
    public interface IActivityRepository
    {
        public void AddActivity(Activity activity);
        //public IReadOnlyList<Activity> GetActivitys(string filter);
        public IReadOnlyList<Activity> GetActivitysByOrganisatorId(int id);
        public Activity GetActivityById(int id);
        public Activity UpdateActivity(Activity activity);
        public void DeleteActivity(int id);
    }
}
