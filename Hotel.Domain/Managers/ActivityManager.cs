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
    public class ActivityManager
    {
        private IActivityRepository _activityRepository;

        public ActivityManager(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public void AddActivity(Activity activity)
        {
            try
            {
               _activityRepository.AddActivity(activity);
            }
            catch (Exception ex)
            {
                throw new ActivityManagerException("AddActivity",ex);
            }
        }
        public IReadOnlyList<Activity> GetActivitysByOrganisatorId(int id)
        {
            try
            {
                 return _activityRepository.GetActivitysByOrganisatorId(id);
            }
            catch (Exception ex)
            {
                throw new ActivityManagerException("GetActivitysByOrganisatorId", ex);
            }
        }
        public Activity GetActivityById(int id)
        {
            try
            {
                return _activityRepository.GetActivityById(id);
            }
            catch (Exception ex)
            {
                throw new ActivityManagerException("GetActivityById", ex);
            }

        }
        public IReadOnlyList<Activity> GetActivitys(string filter)
        {
            try
            {
                return _activityRepository.GetActivitys(filter);
            }
            catch (Exception ex)
            {
                throw new CustomerManagerException("GetCustomers", ex);
            }
        }
        public Activity UpdateActivity(Activity activity)
        {
            try
            {
                return _activityRepository.UpdateActivity(activity);
            }
            catch (Exception ex)
            {
                throw new ActivityManagerException("UpdateActivity", ex);
            }
        }
        public void DeleteActivity(int id)
        {
            try
            {
                _activityRepository.DeleteActivity(id);
            }
            catch (Exception ex)
            {
                throw new ActivityManagerException("DeleteActivity", ex);
            }
        }
    }
}
