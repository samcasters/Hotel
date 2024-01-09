using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation.Customer.Model
{
    public class RegistrationUI : INotifyPropertyChanged
    {
        public RegistrationUI(int activityId, int customerId, int participating)
        {
            ActivityId = activityId;
            CustomerId = customerId;
            Participating = participating;
        }

        public int _activityId;
        public int ActivityId { get { return _activityId; } set { _activityId = value; OnPropertyChanged(); } }

        public int _customerId;
        public int CustomerId { get { return _customerId; } set {_customerId = value; OnPropertyChanged(); } }

        public int _participating;
        public int Participating { get { return _participating; } set {_participating = value; OnPropertyChanged(); } }


        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
