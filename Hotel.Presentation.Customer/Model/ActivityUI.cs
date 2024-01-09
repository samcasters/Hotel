using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Presentation.Customer.Model
{
    public class ActivityUI : INotifyPropertyChanged
    {
        public ActivityUI(int id,string name, string discription, string place, int durationMin, DateTime timeOfActivity, int availability, float costAdult, float costChild, int organisatorUI)
        {
            Id = id;
            Name = name;
            Discription = discription;
            Place = place;
            DurationMin = durationMin;
            TimeOfActivity = timeOfActivity;
            Availability = availability;
            CostAdult = costAdult;
            CostChild = costChild;
            OrganisatorId = organisatorUI;
        }

        public ActivityUI(string name, string discription, string place, int durationMin, DateTime timeOfActivity, int availability, float costAdult, float costChild, int organisatorUI)
        {
            Name = name;
            Discription = discription;
            Place = place;
            DurationMin = durationMin;
            TimeOfActivity = timeOfActivity;
            Availability = availability;
            CostAdult = costAdult;
            CostChild = costChild;
            OrganisatorId = organisatorUI;
        }


        public int? Id { get; set; }

        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }

        private string _description;
        public string Discription { get { return _description; } set { _description = value; OnPropertyChanged(); } }

        private string _place;
        public string Place { get { return _place; } set { _place = value; OnPropertyChanged(); } }

        private int _durationMin;
        public int DurationMin { get { return _durationMin; } set { _durationMin = value; OnPropertyChanged(); } }

        private DateTime _timeOfActivity;
        public DateTime TimeOfActivity { get { return _timeOfActivity; } set { _timeOfActivity = value; OnPropertyChanged(); } }
        
        private int _availability;
        public int Availability { get { return _availability; } set { _availability = value; OnPropertyChanged(); } }

        private float _costAdult;
        public float CostAdult { get { return _costAdult; } set { _costAdult = value; OnPropertyChanged(); } }

        private float _costChild;
        public float CostChild { get { return _costChild; } set { _costChild = value; OnPropertyChanged(); } }

        private int _organisatorId;
        public int OrganisatorId { get { return _organisatorId; } set { _organisatorId = value; OnPropertyChanged(); } }



        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
