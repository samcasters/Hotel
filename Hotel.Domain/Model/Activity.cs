using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Model
{
    public class Activity
    {
        private int _id;
        public int Id { get; set; }
        private string _name;
        public string Name { get; set; }
        private string _discription;
        public string Description { get; set; }
        private string _place;
        public string Place { get; set; }
        private int _durationMin;
        public int DurationMin { get; set; }
        private DateTime _timeOfActivity;
        public DateTime TimeOfActivity { get; set; }
        private int _availability;
        public int Availability { get; set; }
        private float _costAdult;
        public float CostAdult { get; set; }
        private float _costChild;
        public float CostChild { get; set; }
        private Organisator _organisator;
        public Organisator Organisator { get; set; }

        public Activity(int id,string name, string description, string place, int durationMin, DateTime timeOfActivity, int availability, float costAdult, float costChild, Organisator organisator)
        {
            Id = id;
            Name = name;
            Description = description;
            Place = place;
            DurationMin = durationMin;
            TimeOfActivity = timeOfActivity;
            Availability = availability;
            CostAdult = costAdult;
            CostChild = costChild;
            Organisator = organisator;
        }

        public Activity(string name, string description, string place, int durationMin, DateTime timeOfActivity, int availability, float costAdult, float costChild, Organisator organisator)
        {
            Name = name;
            Description = description;
            Place = place;
            DurationMin = durationMin;
            TimeOfActivity = timeOfActivity;
            Availability = availability;
            CostAdult = costAdult;
            CostChild = costChild;
            Organisator = organisator;
        }



    }
}
