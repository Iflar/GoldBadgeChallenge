using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsurance_MethodReposotory
{
    public enum BadHabit
    {
        FollowTooClose,
        Speed,
        SwerveOutOfLane,
        RollThroughStopSign,
        None
    }

    public enum GoodHabit
    {
        SafeDistance,
        FollowSpeedLimit,
        StayInLane,
        FullStopAtSign,
        None
    }
    public class Driver
    {
        public int DriverID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Premium {get; set;}
        public List<GoodHabit> GoodHabits { get; set; }
        public List<BadHabit> BadHabits { get; set; }

        public Driver()
        {
            GoodHabits = new List<GoodHabit>();
            BadHabits = new List<BadHabit>();
        }

        public Driver(int driverID, string firstName, string lastName, double premium)
        {
            DriverID = driverID;
            FirstName = firstName;
            LastName = lastName;
            Premium = premium;

            GoodHabits = new List<GoodHabit>();
            BadHabits = new List<BadHabit>();
        }
    }
}
