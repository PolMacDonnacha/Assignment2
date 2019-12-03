using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Activity :IComparable
    {
        
        public enum ActivityType { All, Air, Water, Land };
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public ActivityType _ActivityType { get; set; }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public Activity(string _name, ActivityType _activity, DateTime _activitydate, decimal _cost, string description)
        {
            Name = _name;
            _ActivityType = _activity;
            ActivityDate = _activitydate;
            Cost = _cost;
            _description = description;
        }
        public Activity(string _name, ActivityType _activity) :this(_name,_activity, DateTime.Now, 0,"")
        {
            Name = _name;
            _ActivityType = _activity;
        }
        public Activity() :this ("",ActivityType.All, DateTime.Now, 0,"") { }

        public void DisplayActivityList()
        {
           // lstbxActivities.
        }
        public override string ToString()
        {
            return $"{Name},{ActivityDate.ToShortDateString()}"; 
        }
        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;
           return ActivityDate.CompareTo(that.ActivityDate);
        }
    }
}
