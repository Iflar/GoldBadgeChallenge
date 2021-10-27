using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Repository
{
    public enum MemberStatus
    {
        Potential,
        Current,
        Past
    }
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateActive { get; set; }
        public MemberStatus MemberStatus
        {
            get
            {
                return CalculateTimeOnTeam(DateActive);
            }
        }

        public Customer() { }

        public Customer(int customerID, string firstName, string lastName, DateTime? dateActive)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            DateActive = dateActive;
        }
        public MemberStatus CalculateTimeOnTeam(DateTime? dateActive)
        {
            if (dateActive == null)
            {
                return MemberStatus.Potential;
            }
            if (dateActive != null)
            {
                DateTime realDate = (DateTime)dateActive;

                TimeSpan timeSpan = DateTime.Now - realDate;
                double timeAsActiveCostomer = timeSpan.TotalDays / 365.25;
                Convert.ToInt32(Math.Floor(timeAsActiveCostomer));
                if (timeAsActiveCostomer > 2)
                {
                    return MemberStatus.Past;
                }
                if (timeAsActiveCostomer < 2)
                {
                    return MemberStatus.Current;
                }
            }
            return MemberStatus.Potential;
        }
    }
}
