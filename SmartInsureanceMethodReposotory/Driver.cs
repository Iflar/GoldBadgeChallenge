using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsurance_MethodReposotory
{
    public enum BadHabbit
    {
        FollowTooClose,
        Speed,
        SwerveOutOfLane,
        RollThroughStopSign,
        None
    }

    public enum GoodHabbit
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
        public List<GoodHabbit> GoodHabbits { get; set; }
        public List<BadHabbit> BadHabbits { get; set; }

        public Driver()
        {
            GoodHabbits = new List<GoodHabbit>();
            BadHabbits = new List<BadHabbit>();
        }

        public Driver(int driverID, string firstName, string lastName, double premium)
        {
            DriverID = driverID;
            FirstName = firstName;
            LastName = lastName;
            Premium = premium;

            GoodHabbits = new List<GoodHabbit>();
            BadHabbits = new List<BadHabbit>();
        }
    }
}
